using System.Windows;
using System.Windows.Threading;
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
    private readonly Forms.NotifyIcon _tray = new();
    private bool _exitRequested;

    public MainWindow()
    {
        InitializeComponent();
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
        WatchToggle.IsChecked = true;
        RefreshAll();
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

    private void OnWatchChecked(object sender, RoutedEventArgs e) => _watch.Start();

    private void OnWatchUnchecked(object sender, RoutedEventArgs e) => _watch.Stop();

    private void OnFileScanned(string path, int code)
    {
        Dispatcher.Invoke(() =>
        {
            var name = System.IO.Path.GetFileName(path);
            ActionText.Text = code == 0 ? $"다운로드 검사 완료: {name}" : $"다운로드 검사 코드 {code}: {name}";
            if (code != 0)
            {
                _tray.ShowBalloonTip(4000, "QuietGuard", $"{name} 검사 결과 코드 {code}", Forms.ToolTipIcon.Warning);
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

            var threats = _engine.ReadThreats();
            ThreatList.ItemsSource = threats.Count == 0
                ? ["최근 위협 없음"]
                : threats.Select(t => $"{t.DetectedAt:MM-dd HH:mm}  {t.Name}  {t.Path}").ToList();

            var budget = _budget.Read();
            BudgetText.Text =
                $"Defender {budget.DefenderCpuPercent:0.0}% · {ToMb(budget.DefenderWorkingSetBytes)}\n" +
                $"QuietGuard {ToMb(budget.AppWorkingSetBytes)}";
        }
        catch (Exception ex)
        {
            HeadlineText.Text = "상태를 읽을 수 없음";
            HeadlineText.Foreground = (Media.Brush)FindResource("Bad");
            ReasonList.ItemsSource = new[] { ex.Message };
        }
    }

    private static string OnOff(bool value) => value ? "켜짐" : "꺼짐";

    private static string ToMb(long bytes) => $"{bytes / (1024.0 * 1024.0):0} MB";

    private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (_exitRequested)
        {
            _timer.Stop();
            _watch.Dispose();
            _tray.Visible = false;
            _tray.Dispose();
            return;
        }

        e.Cancel = true;
        Hide();
    }
}
