# 10. 리깅·Avatar·애니메이션

> 모르는 단어는 [전문 용어 전체 색인](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4_%EC%82%AC%EC%A0%84.md)에서 영문·한글로 찾습니다. 이 장 맨 아래에는 등장 용어의 바로가기 목록이 있습니다.

## 멈춘 모양이 움직이는 순서

준비 B의 부모·자식과 보간을 먼저 읽습니다. **리깅**은 모델이 움직일 수 있도록 뼈 구조와 제어 관계 등을 준비하는 작업입니다. **뼈대, Skeleton**는 부모·자식으로 연결된 뼈들의 구조이며, 실제 뼈 그림이 보이지 않아도 Transform으로 존재할 수 있습니다. **스키닝**은 메시 정점이 뼈를 얼마나 따라갈지 정하고 변형하는 과정입니다.

애니메이션 클립이 특정 시각의 뼈 위치·회전을 정하면, 스키닝이 그 뼈를 따라 메시를 변형하고, 카메라가 그 결과를 그립니다. Animator 상태 막대가 흘러도 클립 주소가 다른 뼈를 가리키면 실제 로봇이 안 움직일 수 있습니다.

아래 수식의 `Σ`는 여러 항을 모두 더하라는 기호입니다. 한 점이 위팔을 0.25, 아래팔을 0.75 비율로 따른다면 두 뼈로 계산한 점 위치를 각각 25%, 75% 섞습니다. 단순 선형 스키닝의 설명이며 모든 변형 기법을 뜻하지는 않습니다. Bind Pose 보정은 원래 기준 자세에서 뼈와 메시가 이중으로 이동하지 않도록 상대 기준을 맞추는 역할을 합니다.

**키프레임**은 특정 시각에 지정한 기준값, **커브**는 그 사이의 변화 규칙입니다. **루프**는 끝에서 시작으로 돌아가 반복하는 것이며, Loop Time 체크만으로 두 자세의 차이가 사라지지는 않습니다.

## 미리보기 창을 여는 법

Project에서 FBX를 클릭 → Animation 탭 → 아래 Preview 영역을 펼칩니다. 영역이 접혀 있으면 하단 경계를 위로 드래그합니다. 재생할 클립을 고르고 Preview의 재생 버튼을 누릅니다. 여러 클립이면 이름을 확인합니다. Animator의 Motion 칸은 이 클립을 가리키는 연결입니다. Preview와 실제 씬 Play를 모두 확인하는 이유는 연결 환경이 다르기 때문입니다.

## 움직임을 만드는 다섯 부품

| 부품 | 쉬운 뜻 | 정확한 역할 |
|---|---|---|
| Skeleton / Bone | 몸속 뼈대 | 부모·자식 Transform 구조 |
| Skin Weight | 살과 뼈를 잇는 끈의 세기 | 각 정점에 뼈가 미치는 비율 |
| Animation Clip | 동작 악보 | 시간별 위치·회전·크기·기타 값 |
| Avatar | 사람 뼈 이름 번역표 등 | Humanoid에서 원본 뼈와 표준 인체 대응 |
| Animator Controller | 재생 순서표 | 어떤 상태와 클립을 재생하고 전환할지 결정 |

Animator는 이 순서표를 실행하는 컴포넌트입니다. `.controller` 파일과 Animator 컴포넌트를 같은 것으로 부르지 않습니다.

## 스키닝의 원리

팔꿈치 근처 정점은 위팔과 아래팔의 영향을 나눠 받습니다. 단순화하면:

```text
변형된 정점 = Σ(뼈별 가중치 × 뼈 변환 × 해당 뼈의 Bind Pose 보정 × 원래 정점)
```

Bind Pose는 메시를 뼈에 연결할 때의 기준 자세입니다. 모양만 같아도 뼈 기준·가중치가 다르면 결과가 다릅니다. 팔이 찢어지는 문제를 무조건 Animator 속도 문제로 보면 안 되는 이유입니다.

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

## 실습 A: 지금 연결된 Walk 추적

1. `Study_Lab`의 Hierarchy에서 `Streetwear Robot_Walk` 루트를 클릭하고 활성 체크를 켭니다. 같은 위치의 Chibi 등 다른 캐릭터는 비교 중 잠시 끕니다.
2. Inspector > Animator의 Controller를 확인합니다. `VARCO_Converted/Streetwear Robot_Walk/Streetwear Robot_Walk.controller`입니다.
3. Controller 슬롯의 파일 이름을 클릭해 Project에서 위치를 찾습니다. 더블클릭하면 Animator 창이 열립니다.
4. 기본 상태에서 Motion을 확인합니다. 원천은 Walk **FBX 내부 클립**입니다.
5. Project에서 Walk FBX 왼쪽 펼침 삼각형을 눌러 하위 클립을 봅니다.
6. FBX의 Animation 탭에서 Loop Time·클립 길이를 확인합니다.
7. Play를 켜고 Animator 상태 진행과 실제 팔·다리의 움직임을 함께 봅니다.
8. 정지 후 원래 위치로 돌아왔는지 확인합니다.

주 씬 Walk의 Animator는 Avatar가 비어 있고 Apply Root Motion은 꺼져 있습니다. Generic Transform 애니메이션에서 Avatar가 비었다는 이유만으로 오류라고 판단하지 않습니다.

## 실습 B: 자기 Controller 만들기

1. `_Study/Animations` 우클릭 → `Create > Animation > Animator Controller` → `Study_Walk`.
2. 더블클릭해 Animator 창을 엽니다.
3. Project의 Walk FBX를 펼친 뒤 **재생할 하위 Animation Clip**을 Animator 창 빈 공간으로 드래그합니다.
4. 상태가 만들어졌는지 봅니다. 원하는 상태를 우클릭 → `Set as Layer Default State`. 기본 상태는 보통 주황색으로 표시됩니다.
5. Hierarchy의 실습용 Walk 루트 Animator > Controller 슬롯에 `Study_Walk.controller`를 드래그합니다.
6. Play로 재생을 확인합니다. 재생 안 되면 17장의 순서대로 확인합니다.

`Animations/Streetwear Robot_Walk_Original.anim`과 `_RetargetClean.anim`은 파일에서 **Legacy=1**입니다. 변환 중간 보존용 클립을 그대로 Mecanim Animator용 클립이라고 간주하지 않습니다. 이 실습은 FBX가 임포트한 클립을 사용합니다.

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

## Root Motion과 제자리 재생

클립에서 추출한 이동·회전을 GameObject에 적용하는 기능이 Root Motion입니다. Animator의 Apply Root Motion을 켰다고 모든 클립에 이동이 생기는 것은 아닙니다. 클립의 Root Transform·Bake Into Pose·Generic의 Root Node 설정도 영향을 줍니다.

또한 Apply Root Motion을 꺼도 Generic 클립이 자식 Root/Hips의 위치를 직접 움직이면 몸이 움직일 수 있습니다. “오브젝트 이동”과 “뼈의 이동 곡선”을 구분합니다.

루프는 마지막 자세에서 첫 자세로 돌아갑니다. Loop Time은 반복 재생 설정이며, 끝과 시작의 자세가 다르면 튈 수 있습니다. 변환 도구는 끝부분을 시작값 쪽으로 섞지만 모든 동작의 자연스러움을 보장하지는 않습니다.

## 합격 기준

- 클립 Preview에서 뼈가 움직인다.
- 씬 Play에서 실제 대상 캐릭터가 움직인다.
- 한 주기를 넘어 반복해도 큰 튐이 없다.
- 발이 심하게 미끄러지거나 지면 아래로 들어가지 않는다.
- 다른 모델로 옮겼다면 원본과 대상 둘 다 확인한다.

**확인 질문:** Humanoid Avatar가 유효하면 애니메이션이 반드시 자연스러운가? 스킨 메시 없이 뼈만 움직이는 결과도 변환 성공인가?

**답:** 유효성은 필요 조건이지 외관 보장은 아닙니다. 뼈와 메시가 함께 올바르게 움직이는지 봐야 합니다.

## 이 장의 용어 찾기

모르는 말은 아래 링크 또는 [전체 용어 색인](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4_%EC%82%AC%EC%A0%84.md)에서 찾습니다. 영문 UI 이름도 검색할 수 있습니다.

- PC와·Unity: [Component](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#component) · [GameObject](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#gameobject) · [Hierarchy](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#hierarchy) · [Import](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#import) · [Inspector](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#inspector) · [Instance](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#instance) · [Layer](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#layer) · [Play](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#play) · [Preview](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#preview) · [Transform](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#transform)

- 수학과·모델: [3D](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#3d) · [Triangle](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#triangle)

- USD와·파일형식: [.anim](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#anim) · [.controller](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#controller-file) · [FBX](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#fbx)

- 표면과·렌더링: [Bake](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#bake)

- 효과와·움직임과·UI: [Animation](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#animation) · [Animation Clip](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#clip) · [Animator](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#animator) · [Animator Controller](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#controller) · [Avatar](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#avatar) · [Bind Pose](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#bindpose) · [Bone](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#bone) · [Generic](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#generic) · [Humanoid](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#humanoid) · [Keyframe](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#keyframe) · [Legacy Animation](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#legacy) · [Loop](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#loop) · [Loop Time](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#loop-time) · [Mecanim](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#mecanim) · [Node](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#node) · [Retargeting](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#retarget) · [Rig](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#rig) · [Root Motion](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#rootmotion) · [Skeleton](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#skeleton) · [Skin Weight](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#skinweight) · [Skinning](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#skinning) · [State](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#state) · [T-Pose](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#tpose)

- 코드와·통신과·검증: [Frame](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#frame)

- 화면의·속성과·메뉴: [Animation Type](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#animation-type) · [Apply](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#apply-import) · [Apply Root Motion](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#apply-root-motion) · [Avatar Definition](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#avatar-definition) · [Bake Into Pose](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#bake-into-pose) · [Configure](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#configure) · [Copy From Other Avatar](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#copy-avatar) · [Create From This Model](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#create-avatar) · [Done](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#done) · [Motion](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#motion) · [No Avatar](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#no-avatar) · [Root Node](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#root-node) · [Root Transform](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#root-transform) · [Set as Layer Default State](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#default-state)

- 보충·기초와·도구이름: [Camera](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#camera)

<!-- study-navigation -->
[이전](../03_%EB%B9%9B%EA%B3%BC%ED%99%94%EB%A9%B4/09_%EC%85%B0%EC%9D%B4%EB%8D%94_%EB%8D%B0%EC%B9%BC%EA%B3%BC_VFX.md) · [목차](../README.md) · [다음](11_VARCO_Bridge%EC%99%80_%EB%B3%80%ED%99%98%EB%8F%84%EA%B5%AC.md)
