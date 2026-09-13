namespace QuietGuard;

public sealed class DownloadWatchService : IDisposable
{
    private FileSystemWatcher? _watcher;
    private readonly DefenderEngine _engine;
    private readonly HashSet<string> _recent = new(StringComparer.OrdinalIgnoreCase);
    private readonly object _gate = new();

    public event Action<string, int>? FileScanned;
    public event Action<string, Exception>? ScanFailed;

    public DownloadWatchService(DefenderEngine engine)
    {
        _engine = engine;
    }

    public bool IsRunning => _watcher is not null;

    public void Start()
    {
        if (_watcher is not null)
            return;

        var downloads = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "Downloads");
        if (!Directory.Exists(downloads))
            return;

        var watcher = new FileSystemWatcher(downloads)
        {
            IncludeSubdirectories = false,
            NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.CreationTime,
            EnableRaisingEvents = true
        };
        watcher.Created += OnChanged;
        watcher.Renamed += OnRenamed;
        _watcher = watcher;
    }

    public void Stop()
    {
        if (_watcher is null)
            return;
        _watcher.EnableRaisingEvents = false;
        _watcher.Dispose();
        _watcher = null;
    }

    private void OnRenamed(object sender, RenamedEventArgs e) => QueueScan(e.FullPath);

    private void OnChanged(object sender, FileSystemEventArgs e) => QueueScan(e.FullPath);

    private void QueueScan(string path)
    {
        if (!DownloadScanAdvisor.ShouldQueue(path))
            return;

        lock (_gate)
        {
            if (!_recent.Add(path))
                return;
        }

        _ = ScanLater(path);
    }

    private async Task ScanLater(string path)
    {
        try
        {
            await Task.Delay(DownloadScanAdvisor.Debounce).ConfigureAwait(false);
            var code = await _engine.ScanFileAsync(path).ConfigureAwait(false);
            FileScanned?.Invoke(path, code);
        }
        catch (Exception ex)
        {
            ScanFailed?.Invoke(path, ex);
        }
        finally
        {
            await Task.Delay(DownloadScanAdvisor.Cooldown).ConfigureAwait(false);
            lock (_gate)
            {
                _recent.Remove(path);
            }
        }
    }

    public void Dispose() => Stop();
}
