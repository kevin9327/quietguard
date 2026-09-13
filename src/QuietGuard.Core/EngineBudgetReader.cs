using System.Diagnostics;

namespace QuietGuard;

public sealed class EngineBudgetReader
{
    private readonly string _appProcessName;
    private TimeSpan _lastDefenderCpu;
    private TimeSpan _lastAppCpu;
    private DateTime _lastSampleUtc = DateTime.MinValue;

    public EngineBudgetReader(string? appProcessName = null)
    {
        _appProcessName = appProcessName ?? Process.GetCurrentProcess().ProcessName;
    }

    public EngineBudget Read()
    {
        var now = DateTime.UtcNow;
        var defender = Process.GetProcessesByName("MsMpEng").FirstOrDefault();
        var app = Process.GetCurrentProcess();

        float defenderCpu = 0;
        float appCpu = 0;
        long defenderWs = 0;

        if (_lastSampleUtc != DateTime.MinValue)
        {
            var elapsed = (now - _lastSampleUtc).TotalSeconds;
            if (elapsed > 0.2)
            {
                if (defender is { HasExited: false })
                {
                    defenderCpu = CpuPercent(defender.TotalProcessorTime - _lastDefenderCpu, elapsed);
                    defenderWs = defender.WorkingSet64;
                }

                appCpu = CpuPercent(app.TotalProcessorTime - _lastAppCpu, elapsed);
            }
        }

        if (defender is { HasExited: false })
        {
            _lastDefenderCpu = defender.TotalProcessorTime;
            defenderWs = defender.WorkingSet64;
        }

        _lastAppCpu = app.TotalProcessorTime;
        _lastSampleUtc = now;

        return new EngineBudget(defenderCpu, defenderWs, appCpu, app.WorkingSet64);
    }

    private static float CpuPercent(TimeSpan delta, double elapsedSeconds)
    {
        var percent = delta.TotalSeconds / (Environment.ProcessorCount * elapsedSeconds) * 100.0;
        if (percent < 0) return 0;
        if (percent > 100) return 100;
        return (float)percent;
    }
}
