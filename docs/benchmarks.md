# 오픈소스 벤치마크 (2026-09-13)

 QuietGuard는 아래 10개 공개 저장소를 기준으로 “무엇을 베끼지 않고 무엇을 이길지”를 정한다.
스타 수는 조회 시점 값이다.

| # | 저장소 | 스타 | 역할 | 배울 점 | QuietGuard가 이기려는 점 |
| --- | --- | ---: | --- | --- | --- |
| 1 | [crowdsecurity/crowdsec](https://github.com/crowdsecurity/crowdsec) | 14829 | 커뮤니티 IDS/IPS | 탐지 규칙을 공개하고 네트워크 쪽을 나눔 | v0.1에 네트워크 IDS를 넣지 않음. 소비자 PC 기본 화면을 더 단순하게 |
| 2 | [henrypp/simplewall](https://github.com/henrypp/simplewall) | 8944 | WFP 방화벽 GUI | 1MB급 가벼움, 트레이, 광고 없음 | 백신 상태에 같은 가벼움을 적용. 방화벽 전체 설정은 비움 |
| 3 | [Cisco-Talos/clamav](https://github.com/Cisco-Talos/clamav) | 7235 | OSS 백신 엔진 | 엔진은 공개 프로젝트에 맡긴다 | Windows 실시간 보호는 ClamAV 대신 Defender |
| 4 | [HotCakeX/Harden-Windows-Security](https://github.com/HotCakeX/Harden-Windows-Security) | 4737 | Defender  hardening | 공식 Microsoft 설정만 사용 | 매일 쓰는 한 화면. 200개 토글은 넣지 않음 |
| 5 | [Neo23x0/Loki](https://github.com/Neo23x0/Loki) | 3790 | YARA/IOC 스캐너 | 휴대용 추가 검사 | 기본 제품이 아니라 이후 선택 기능 |
| 6 | [AndyFul/ConfigureDefender](https://github.com/AndyFul/ConfigureDefender) | 1565 | Defender 설정 GUI | 프리셋(Default/High/Max) | 설정만이 아니라 검사·격리 조치·조용한 예약 검사 |
| 7 | [Karib0u/rustinel](https://github.com/Karib0u/rustinel) | 482 | ETW/Sigma EDR | 로컬 탐지, 클라우드 계정 없음 | 소비자용 기본 앱보다 무거움. 이후 계층 |
| 8 | [DivineSoftware/HawkEye](https://github.com/DivineSoftware/HawkEye) | 13 | YARA+Loki+VT GUI | 트레이, 격리, 부팅 시작 | VT 키 없이 격리 복원/허용/치료 + 선택적 부팅 시작 |
| 9 | [CripterHack/Amaru](https://github.com/CripterHack/Amaru) | 8 | ClamAV+YARA+Tauri | 현대 UI | 두 번째 엔진을 상주시키지 않음 |
| 10 | [razgriz-creator/defender-console](https://github.com/razgriz-creator/defender-console) | 0 | Defender CIM/MpCmdRun GUI | 상태·검사·위협 조치 API 맵 | 한국어, 조용한 판정, 다운로드 감시, CPU/RAM, 보호 중이면 예약 검사도 알림 없음 |

## 의도적으로 빼 둔 저장소

- [pgkt04/defender-control](https://github.com/pgkt04/defender-control) — Defender를 끈다. QuietGuard와 반대.
- 자체 해시만 쓰는 토이 AV (예: SimpleAV) — 탐지 품질이 제품이 될 수 없음.
- AhnLab V3 Lite — 상용 바이너리. 디컴파일·파생 금지.

## v0.2 점수표 (목표 대비)

| 기준 | 10개 중 최강 | QuietGuard v0.2 |
| --- | --- | --- |
| Windows 탐지 엔진 | Defender를 쓰는 쪽 (console / ConfigureDefender) | Defender CIM + MpCmdRun |
| 가벼움 | simplewall | 상주 UI + 감시만. 엔진 추가 없음 |
| 한국어 | 없음 | 기본 UI 한국어 |
| 조용함 | Harden/Configure는 설정이 많음 | 건강하면 알림 없음. 예약 검사도 보호 중이면 무음 |
| 다운로드 감시 | ClamAV GUI, Amaru | 실행 파일 확장자만 |
| 격리 조치 | defender-console, HawkEye | 복원 / 허용 / 치료 검사를 Defender로 |
| 리소스 표시 | Defender Performance Tool | MsMpEng CPU/RAM |
| 부팅 시작 | HawkEye | 선택적 HKCU Run, `--tray` |
| 오픈소스 라이선스 | 대체로 MIT/GPL | MIT |

이 표는 기능이 추가될 때마다 고친다.
