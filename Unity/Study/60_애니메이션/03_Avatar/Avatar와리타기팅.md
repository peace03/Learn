# Avatar와 리타기팅

[전체 주제 목차](../../README.md) · [전체 용어 사전](../../90_용어사전/README.md)

## Generic과 Humanoid

**Generic**은 보통 해당 계층의 Transform 경로를 따라 움직입니다. `skel/Root/Hips/...`라는 주소가 달라지면 같은 클립도 맞지 않을 수 있습니다.

**Humanoid**는 인체 뼈를 표준 의미에 맞춰 변환하여 다른 Humanoid 캐릭터에 동작을 옮길 수 있게 합니다. 이 옮기기를 **Retargeting, 리타기팅**이라고 합니다. 두 모델의 팔 길이가 달라도 같은 걷기 동작을 해석할 수 있지만, 발 미끄러짐·관절 각도까지 자동으로 완벽해지는 것은 아닙니다.

현재 파일 설정:

| 모델 | Rig 설정 | 연결·용도 |
|---|---|---|
| `VARCO_Converted/Streetwear Robot_Walk/Streetwear Robot_Walk.fbx` | Generic, No Avatar | 주 씬에서 Walk Controller로 재생하도록 연결 |
| `VARCO_Converted/Streetwear Robot_Run/Streetwear Robot_Runing.fbx` | Humanoid, Create From This Model | 주 씬의 비활성 Runing 오브젝트가 사용 |
| `VARCO_URP/01.Varco3D/Models/Running.fbx` | Humanoid | `Running.controller`의 Motion 원천 |
| `.../Streetwear Robot/Streetwear Robot_Run.fbx` | Humanoid | 뼈 매핑 저장됨 |
| `.../Streetwear Robot/Streetwear Robot.fbx` | Generic | 같은 이름 계열이라도 설정이 다름 |
| `.../Chibi Robot/Walking.fbx` | Humanoid | 걷기 클립 비교 대상 |

Import 설정만으로 Avatar의 실제 유효성과 재생 모습을 확정할 수 없습니다. Inspector의 Configure·Preview와 Play를 따로 확인합니다.

## 실습 C: Humanoid 리타기팅

기존 연결을 바꾸므로 복사 씬의 별도 인스턴스에서 합니다. FBX 임포트 설정을 변경해야 하면 FBX도 복제합니다.

1. Project에서 `Streetwear Robot_Runing.fbx`를 선택 → Rig 탭.
2. `Animation Type = Humanoid`, `Avatar Definition = Create From This Model`인지 확인합니다.
3. `Configure`로 들어가 필수 뼈 매핑과 T-Pose를 확인합니다. 화면에서 유효하다고 확인된 뒤 `Done`으로 나옵니다.
4. `Running.fbx`도 자기 모델의 Humanoid Avatar가 유효한지 확인합니다.
5. Runing FBX를 Hierarchy에 새로 배치하거나 복사 씬의 기존 비활성 Runing 오브젝트를 켭니다.
6. **대상 로봇의 Animator Avatar에는 대상 로봇 자신의 Avatar**를 둡니다.
7. Controller에는 `Running.controller`를 연결합니다. 그 안의 Motion은 다른 `Running.fbx`의 Humanoid 클립입니다.
8. 로봇 하나만 활성화해 Play합니다. 손·발·골반, 시작 방향, 발 높이, 루프 경계를 봅니다.

`Copy From Other Avatar`는 리그 구조가 같은 모델·애니메이션 파일끼리 공유할 때 사용하는 기능입니다. 모양이 사람 같거나 Hips라는 이름이 같다고 호환되는 것은 아닙니다. 뿌리부터 부모 경로와 기준 자세까지 봐야 합니다. [Avatar 설정](https://docs.unity3d.com/6000.0/Documentation/Manual/ConfiguringtheAvatar.html), [리타기팅](https://docs.unity3d.com/6000.0/Documentation/Manual/Retargeting.html).
