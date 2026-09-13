# QuietGuard design

Date: 2026-09-13

## Goal

A small open-source Windows app that is easier to live with than V3 Lite, without cloning V3 and without shipping a third-party antivirus engine.

## Non-goals

- Decompiling or redistributing AhnLab V3
- Unsigned kernel minifilters
- Disabling Microsoft Defender
- VirusTotal-required workflows in v0.1
- Full EDR / Sigma / WFP firewall

## Architecture

```
QuietGuard.App (WPF tray UI)
    -> QuietGuard.Core
         DefenderEngine   CIM + MpCmdRun
         ProtectionAdvisor  quiet / attention / unprotected
         DownloadWatchService  Downloads folder
         EngineBudgetReader  MsMpEng + app RAM/CPU
```

Microsoft Defender remains the only detection engine. QuietGuard only reads status, starts scans, watches Downloads, and shows resource use.

## Components

1. **DefenderEngine** — `root\Microsoft\Windows\Defender` CIM for status/threats; `MpCmdRun.exe` for scan and signature update.
2. **ProtectionAdvisor** — maps status to one headline. Healthy systems stay quiet.
3. **DownloadWatchService** — FileSystemWatcher on `%USERPROFILE%\Downloads`. Scans only risky extensions.
4. **EngineBudgetReader** — process times for `MsMpEng` and the app.
5. **MainWindow** — Korean dashboard, tray hide on close.

## Data flow

Status poll every 4 seconds → advisor → UI tiles.  
User scan/update → MpCmdRun → refresh.  
New download → 1.5s debounce → MpCmdRun custom file scan → tray balloon only on non-zero exit.

## Error handling

- Missing WinDefend: show “상태를 읽을 수 없음” with the exception text.
- Threat CIM denied: empty list, no crash.
- Missing MpCmdRun: throw a clear FileNotFoundException to the action line.

## Testing

- ProtectionAdvisor unit tests for protected / attention / unprotected.
- DownloadWatchFilter unit tests for extensions and temp files.
- `--self-test` talks to the live Defender CIM on a real Windows box.

## License

MIT.
