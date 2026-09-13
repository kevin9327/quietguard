# Contributing

1. Read [docs/benchmarks.md](docs/benchmarks.md). New features should beat at least one listed project on a named criterion.
2. Keep Microsoft Defender as the detection engine unless a later spec says otherwise.
3. Do not add unsigned drivers, Defender disablers, or third-party AV binaries.
4. Korean UI strings stay in the WPF project. Core stays language-agnostic except for advisor copy, which is Korean in v0.1.

```powershell
dotnet test
dotnet publish src\QuietGuard.App\QuietGuard.App.csproj -c Release -r win-x64 --self-contained false -o publish
```
