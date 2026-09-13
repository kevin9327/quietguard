# Security

QuietGuard is a front end for Microsoft Defender. It does not ship malware samples, exploits, kernel drivers, or unsigned filters.

Do not open pull requests that:

- disable, strip, or bypass Defender / tamper protection
- add kernel drivers without Microsoft attestation signing
- include live malware, exploit PoCs, or packed dropper binaries
- scrape or reimplement proprietary antivirus engines (including AhnLab V3)

Report issues in GitHub Issues. This project has no warranty.
