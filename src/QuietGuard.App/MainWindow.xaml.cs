using System.Windows;
using System.Windows.Threading;
using Microsoft.Win32;
using QuietGuard;
using Forms = System.Windows.Forms;
using Media = System.Windows.Media;

namespace QuietGuard.App;

public partial class MainWindow : Window
{
    private readonly DefenderEngine _engine = new();
    private readonly EngineBudgetReader _budget = new();
    private readonly DownloadWatchService _watch;
    private readonly DispatcherTimer _timer = new() { Interval = TimeSpan.FromSeconds(4) };
    private readonly DispatcherTimer _scheduleTimer = new() { Interval = TimeSpan.FromMinutes(15) };
    private readonly Forms.NotifyIcon _tray = new();
    private readonly List<ThreatInfo> _threats = [];
    private bool _exitRequested;

    public MainWindow()
    {
        InitializeComponent();
        RestoreButton.Content = ThreatActionLabels.Button(ThreatActionKind.Restore);
        AllowButton.Content = ThreatActionLabels.Button(ThreatActionKind.Allow);
        RemediateButton.Content = ThreatActionLabels.Button(ThreatActionKind.Remediate);
        _watch = new DownloadWatchService(_engine);
        _watch.FileScanned += OnFileScanned;
        _watch.ScanFailed += (_, ex) => Dispatcher.Invoke(() => ActionText.Text = ex.Message);

        _tray.Text = "QuietGuard";
        _tray.Icon = System.Drawing.SystemIcons.Shield;
        _tray.Visible = true;
        _tray.DoubleClick += (_, _) =>
        {
            Show();
            WindowState = WindowState.Normal;
            Activate();
        };
        _tray.ContextMenuStrip = new Forms.ContextMenuStrip();
        _tray.ContextMenuStrip.Items.Add("열기", null, (_, _) =>
        {
            Show();
            WindowState = WindowState.Normal;
            Activate();
        });
        _tray.ContextMenuStrip.Items.Add("종료", null, (_, _) =>
        {
            _exitRequested = true;
            Close();
        });

        _timer.Tick += (_, _) => RefreshAll();
        _timer.Start();
        _scheduleTimer.Tick += async (_, _) => await RunScheduledScanAsync();
        _scheduleTimer.Start();
        WatchToggle.IsChecked = true;
        RefreshAll();
        _ = RunScheduledScanAsync();
    }

    private async void OnQuickScan(object sender, RoutedEventArgs e)
    {
        ActionText.Text = "빠른 검사 중…";
        try
        {
            var code = await _engine.QuickScanAsync();
            ActionText.Text = code == 0 ? "빠른 검사 완료" : $"검사 종료 코드 {code}";
            RefreshAll();
        }
        catch (Exception ex)
        {
            ActionText.Text = ex.Message;
        }
    }

    private async void OnUpdate(object sender, RoutedEventArgs e)
    {
        ActionText.Text = "정의 업데이트 중…";
        try
        {
            var code = await _engine.UpdateSignaturesAsync();
            ActionText.Text = code == 0 ? "정의 업데이트 완료" : $"업데이트 종료 코드 {code}";
            RefreshAll();
        }
        catch (Exception ex)
        {
            ActionText.Text = ex.Message;
        }
    }

    private async void OnRestore(object sender, RoutedEventArgs e) => await ApplySelectedAsync(ThreatActionKind.Restore);

    private async void OnAllow(object sender, RoutedEventArgs e) => await ApplySelectedAsync(ThreatActionKind.Allow);

    private async void OnRemediate(object sender, RoutedEventArgs e) => await ApplySelectedAsync(ThreatActionKind.Remediate);

    private void OnBootChecked(object sender, RoutedEventArgs e) => SetBoot(true);

    private void OnBootUnchecked(object sender, RoutedEventArgs e) => SetBoot(false);

    private async Task ApplySelectedAsync(ThreatActionKind kind)
    {
        var index = ThreatList.SelectedIndex;
        if (!ThreatListPresentation.IsSelectableIndex(index, _threats.Count))
        {
            ActionText.Text = "위협을 먼저 선택하세요.";
            return;
        }

        var threat = _threats[index];
        if (!ThreatListPresentation.AvailableActions(threat).Contains(kind))
        {
            ActionText.Text = "이 항목에는 해당 조치를 쓸 수 없습니다.";
            return;
        }

        try
        {
            var plan = ThreatActions.Plan(kind, threat);
            ActionText.Text = plan.Summary;
            var code = await _engine.ApplyAsync(kind, threat);
            ActionText.Text = code == 0 ? $"{plan.Summary} 완료" : $"{plan.Summary} 코드 {code}";
            if (plan.NotifyUser && code != 0)
                _tray.ShowBalloonTip(4000, "QuietGuard", plan.Summary, Forms.ToolTipIcon.Warning);
            RefreshAll();
        }
        catch (Exception ex)
        {
            ActionText.Text = ex.Message;
        }
    }

    private async Task RunScheduledScanAsync()
    {
        try
        {
            var status = _engine.ReadStatus();
            var verdict = ProtectionAdvisor.Advise(status);
            var decision = await _engine.RunScheduledScanIfDueAsync(verdict.Level, DateTime.UtcNow);
            if (!decision.ShouldScan)
                return;
            if (decision.NotifyUser)
                _tray.ShowBalloonTip(4000, "QuietGuard", decision.Reason, Forms.ToolTipIcon.Info);
            else
                ActionText.Text = decision.Reason;
            RefreshAll();
        }
        catch (Exception ex)
        {
            ActionText.Text = ex.Message;
        }
    }

    private static void SetBoot(bool enabled)
    {
        var exe = Environment.ProcessPath ?? "";
        if (!StartupRegistration.IsSafeExePath(exe))
            return;
        if (!StartupRegistration.ShouldEnableAtBoot(enabled, ProtectionLevel.Protected) && enabled)
            return;

        using var key = Registry.CurrentUser.OpenSubKey(StartupRegistration.RunKeyPath, writable: true);
        if (key is null)
            return;
        if (enabled)
            key.SetValue(StartupRegistration.RunValueName, StartupRegistration.FormatLaunchCommand(exe));
        else
            key.DeleteValue(StartupRegistration.RunValueName, throwOnMissingValue: false);
    }

    private void OnWatchChecked(object sender, RoutedEventArgs e) => _watch.Start();

    private void OnWatchUnchecked(object sender, RoutedEventArgs e) => _watch.Stop();

    private void OnFileScanned(string path, int code)
    {
        Dispatcher.Invoke(() =>
        {
            ActionText.Text = DownloadScanAdvisor.FormatResult(path, code);
            if (DownloadScanAdvisor.ShouldNotify(code))
            {
                _tray.ShowBalloonTip(4000, "QuietGuard", ActionText.Text, Forms.ToolTipIcon.Warning);
            }
            RefreshAll();
        });
    }

    private void RefreshAll()
    {
        try
        {
            var status = _engine.ReadStatus();
            var verdict = ProtectionAdvisor.Advise(status);
            HeadlineText.Text = verdict.Headline;
            HeadlineText.Foreground = verdict.Level switch
            {
                ProtectionLevel.Protected => (Media.Brush)FindResource("Ok"),
                ProtectionLevel.Attention => (Media.Brush)FindResource("Warn"),
                _ => (Media.Brush)FindResource("Bad")
            };
            ReasonList.ItemsSource = verdict.Reasons;
            RealtimeText.Text = OnOff(status.RealTimeProtectionEnabled);
            IoavText.Text = OnOff(status.IoavProtectionEnabled);
            TamperText.Text = OnOff(status.IsTamperProtected);
            SignatureText.Text = status.SignatureVersion ?? "-";
            _tray.Text = $"QuietGuard · {verdict.Headline}";

            _threats.Clear();
            _threats.AddRange(_engine.ReadThreats());
            ThreatList.ItemsSource = _threats.Count == 0
                ? new[] { ThreatListPresentation.EmptyListPlaceholder }
                : _threats.Select(ThreatListPresentation.FormatRow).ToList();

            var budget = _budget.Read();
            BudgetText.Text =
                EngineBudgetMath.FormatLine("Defender", budget.DefenderCpuPercent, budget.DefenderWorkingSetBytes) + "\n" +
                EngineBudgetMath.FormatLine("QuietGuard", budget.AppCpuPercent, budget.AppWorkingSetBytes);
            if (EngineBudgetMath.ExceedsQuietBudget(budget.DefenderCpuPercent, budget.DefenderWorkingSetBytes))
                BudgetText.Text += "\n무거움";
        }
        catch (Exception ex)
        {
            HeadlineText.Text = "상태를 읽을 수 없음";
            HeadlineText.Foreground = (Media.Brush)FindResource("Bad");
            ReasonList.ItemsSource = new[] { ex.Message };
        }
    }

    private static string OnOff(bool value) => value ? "켜짐" : "꺼짐";

    private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (_exitRequested)
        {
            _timer.Stop();
            _scheduleTimer.Stop();
            _watch.Dispose();
            _tray.Visible = false;
            _tray.Dispose();
            return;
        }

        e.Cancel = true;
        Hide();
    }
}
