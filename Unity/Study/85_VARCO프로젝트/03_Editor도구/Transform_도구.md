# Transform 도구: 복사·붙이기·초기화

[전체 주제 목차](../../README.md) · [전체 용어 사전](../../90_용어사전/README.md)

## Transform 오버레이

| 조작 | 실제 기준 |
|---|---|
| P | 월드 Position |
| R | 월드 Euler Rotation |
| S | Local Scale |
| 축별 ±90도 버튼 | 해당 월드 Euler 값에 90도 가감 |
| Copy | 현재 활성 선택 하나의 P·R·S를 도구 메모리에 저장 |
| Paste | 저장한 P·R·S를 현재 활성 선택 하나에 적용 |
| Reset | 월드 위치·회전 0, Local Scale 1 |

**Transform 오버레이 Reset과 PrimTools Reset은 기준이 다릅니다.** 부모가 원점에서 떨어져 있으면 두 버튼의 결과도 달라집니다. Inspector Transform 숫자는 보통 부모 기준입니다.

Copy 전에 Paste를 누르면 저장할 값이 아직 준비되지 않았습니다. 특히 copiedScale 기본값이 0이라 물체가 보이지 않을 수 있습니다. Copy → 다른 대상 선택 → Paste 순서로 씁니다.

실습: Cube 위치를 기록하고 Copy → 다른 실습 Cube 선택 → Paste → 두 물체가 겹치는지 확인 → Ctrl+Z. 여러 개를 선택해도 이 오버레이 구현은 activeTransform 하나만 처리합니다.
