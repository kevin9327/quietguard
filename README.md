# QuietGuard

조용한 Windows 보안 앱. **자체 백신 엔진을 만들지 않고** PC에 이미 있는 Microsoft Defender를 씁니다.

V3 Lite를 디컴파일한 제품이 아닙니다. 안랩 코드·아이콘·이름을 사용하지 않습니다.

## 왜 이 방식인가

시중 오픈소스 “백신”은 대체로 세 가지입니다.

1. **자체 해시/YARA 엔진** — 탐지율이 Defender보다 낮고 오진이 많음
2. **ClamAV GUI** — 메일 서버엔 강하지만 Windows 실시간 보호는 Defender가 더 나음
3. **Defender 끄기 도구** — 보안을 약하게 만듦

QuietGuard는 4번입니다. **Defender는 켜 두고, 무겁고 귀찮은 껍데기만 바꾼다.**

## v0.1이 하는 일

- 보호 상태를 한 줄로 표시: 보호 중 / 조치 필요 / 보호되지 않음
- 빠른 검사, 정의 업데이트 (`MpCmdRun`)
- 다운로드 폴더에서 실행 파일만 조용히 검사
- Defender(`MsMpEng`) CPU·RAM을 같이 보여 줌
- 건강하면 알림을 보내지 않음
- 트레이로 숨김. 광고·업셀 없음

## 벤치마크 10개

자세한 표는 [docs/benchmarks.md](docs/benchmarks.md)에 있습니다. QuietGuard가 이기려는 지점:

| 대상 | 우리가 더 잘하려는 것 |
| --- | --- |
| V3 Lite | 추가 엔진 없음, 광고 없음, 오픈소스 |
| defender-console | 한국어, 다운로드 감시, 리소스 표시, 조용한 상태 |
| ConfigureDefender | 설정만이 아니라 검사·감시·상태 |
| simplewall | 같은 가벼움, 대상은 방화벽이 아니라 백신 상태 |
| ClamAV GUI / Amaru / HawkEye / SimpleAV | Windows에서는 Defender 엔진이 더 강함 |
| Harden-Windows-Security | hardening 200개가 아니라 매일 쓰는 한 화면 |
| Loki / Rustinel / CrowdSec | 전문가 도구는 나중에 선택 기능. 기본은 조용함 |

## 요구 사항

- Windows 10 또는 11
- Microsoft Defender (`WinDefend`)가 켜져 있을 것
- 빌드: .NET 10 SDK

## 빌드

```powershell
dotnet test
dotnet publish src\QuietGuard.App\QuietGuard.App.csproj -c Release -r win-x64 --self-contained false -o publish
```

실행:

```powershell
.\publish\QuietGuard.exe
.\publish\QuietGuard.exe --self-test
```

## 라이선스

MIT. Microsoft·안랩과 무관한 비공식 프론트엔드입니다.
