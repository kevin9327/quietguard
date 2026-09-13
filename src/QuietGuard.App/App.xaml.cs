using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using QuietGuard;

namespace QuietGuard.App;

public partial class App : System.Windows.Application
{
    private const int AttachParentProcess = -1;

    [DllImport("kernel32.dll")]
    private static extern bool AllocConsole();

    [DllImport("kernel32.dll")]
    private static extern bool AttachConsole(int dwProcessId);

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        var args = e.Args ?? [];
        if (args.Contains("--self-test", StringComparer.OrdinalIgnoreCase))
        {
            RunSelfTest();
            Shutdown();
            return;
        }

        var window = new MainWindow();
        window.Show();
    }

    private static void RunSelfTest()
    {
        if (!AttachConsole(AttachParentProcess))
            AllocConsole();
        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        Console.SetError(new StreamWriter(Console.OpenStandardError()) { AutoFlush = true });
        try
        {
            var engine = new DefenderEngine();
            var status = engine.ReadStatus();
            var verdict = ProtectionAdvisor.Advise(status);
            Console.WriteLine($"quietguard.self-test=ok");
            Console.WriteLine($"level={verdict.Level}");
            Console.WriteLine($"headline={verdict.Headline}");
            Console.WriteLine($"realtime={status.RealTimeProtectionEnabled}");
            Console.WriteLine($"antivirus={status.AntivirusEnabled}");
            Console.WriteLine($"tamper={status.IsTamperProtected}");
            Console.WriteLine($"engine={status.EngineVersion}");
            Console.WriteLine($"signatures={status.SignatureVersion}");
            Console.WriteLine($"mpcmdrun={DefenderEngine.ResolveMpCmdRun()}");
            Environment.ExitCode = 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"quietguard.self-test=fail {ex.Message}");
            Environment.ExitCode = 1;
        }
    }
}
