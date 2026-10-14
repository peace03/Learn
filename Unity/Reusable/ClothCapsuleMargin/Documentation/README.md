# Cloth Capsule Margin 사용 설명서

버전: 1.0.0 · 기준 Unity: 6000.3.9f1 · Unity 기본 Cloth용

**천이 캡슐을 살짝 뚫고 보일 때, 조금 큰 보조 충돌체를 만들어 천을 바깥에서 먼저 밀어내는 기능입니다.** 화면에 보이는 캡슐은 키우지 않습니다.

패키지를 가져온 뒤 **캡슐에 스크립트를 붙이고, Target Cloth에 천을 연결해야** 작동합니다. 천 모델이나 완성된 예제 씬을 자동으로 만드는 패키지는 아닙니다.

## 1. 패키지에 들어 있는 파일

```text
Assets/Scripts/Cloth/
    ClothCapsuleMargin.cs          ← 실행 코드
    Documentation/
        README.md                 ← 지금 읽는 사용 설명서
```

Unity가 연결을 유지하는 데 쓰는 `.meta` 정보도 포함됩니다. 프로젝트 밖의 개인 공부 자료 없이 이 문서만으로 기본 연결 방법을 확인할 수 있습니다.

이 문서가 열리지 않으면 Unity의 Project 창에서 `README.md` 우클릭 → **Show in Explorer**를 누릅니다. 파일 탐색기에서 파일을 우클릭 → **연결 프로그램 → 메모장**으로 엽니다. `.md`는 글과 간단한 서식 기호를 담는 텍스트 파일입니다.

## 2. 다른 프로젝트에 가져오기

1. Unity Hub에서 적용할 프로젝트를 엽니다.
2. Play 중이라면 위쪽 재생 버튼을 눌러 종료합니다.
3. 위쪽 메뉴 **Assets → Import Package → Custom Package...**를 누릅니다.
4. `ClothCapsuleMargin_v1.0.0.unitypackage`를 선택하고 **Open**을 누릅니다.
5. 가져오기 목록에서 코드와 `Documentation/README.md`가 선택되어 있는지 확인하고 **Import**를 누릅니다.
6. 처리가 끝나면 Project 창의 `Assets → Scripts → Cloth`를 엽니다. 코드 파일과 Documentation 폴더가 보여야 합니다.
7. **Window → General → Console**에서 빨간 컴파일 오류가 없는지 봅니다. 같은 코드가 이미 설치되어 있다면 중복 파일을 하나 더 만들지 말고 아래의 갱신 설명을 따릅니다.

## 3. 천과 캡슐에 연결하기

이미 천에 **Unity 기본 Cloth**가 붙어 있다면 이 절차부터 진행합니다. 준비된 천이 없으면 먼저 5번의 작은 실습을 진행합니다.

1. **Hierarchy**에서 천과 부딪힐 캡슐 오브젝트를 선택합니다.
2. 오른쪽 **Inspector**에 **Capsule Collider**가 있는지 확인합니다. 없다면 **Add Component → Capsule Collider**로 추가하고 몸의 모양에 맞춥니다.
3. **Add Component**를 누르고 `Cloth Capsule Margin`을 검색해 추가합니다.
4. Hierarchy에서 **Cloth 컴포넌트가 붙은 천 오브젝트**를 `Target Cloth` 칸으로 드래그합니다. 부모 캐릭터가 아니라 실제로 Cloth가 붙은 자식일 수 있습니다.
5. `Margin`을 입력합니다. 큰 테스트 Plane과 기본 캡슐은 `0.2`로 시작할 수 있습니다. 작은 의상에는 더 작은 값부터 비교합니다.
6. **Ctrl+S**로 씬을 저장하고 위쪽 **Play ▶**를 누릅니다.
7. Hierarchy에서 캡슐 왼쪽 화살표를 펼칩니다. **Cloth Collision Margin**이라는 자식이 생겨야 합니다.
8. 천이나 캡슐을 천천히 움직여 천이 캡슐 겉에서 밀리는지 봅니다. 테스트할 때 고정된 점을 직접 관통시키거나 물체를 순간이동시키지 않습니다.

스크립트가 보조 캡슐을 Cloth의 충돌 목록에 직접 넣습니다. 사용자가 그 자식을 다시 목록에 넣을 필요는 없습니다.

보조 자식의 **Capsule Collider 체크박스가 꺼진 것은 정상**입니다. 일반 물체와의 충돌을 끄고 Cloth 목록을 통해 사용하도록 만든 것입니다. 이 동작은 Unity 6000.3.9f1에서 확인했습니다.

## 4. Margin을 맞추고 저장하기

Margin은 **보이는 캡슐 바깥에 더할 월드 거리**입니다. 크기의 백분율이 아닙니다. `1 Unity 단위 = 1m`로 만든 모델에서는 `0.2 = 20cm`이므로 작은 캐릭터에 그대로 쓰면 천이 많이 떠 보일 수 있습니다.

| 보이는 모습 | 조절 방법 |
|---|---|
| 캡슐이 천을 조금 뚫고 보임 | Margin을 조금 올리고 비교 |
| 천이 캡슐에서 너무 멀리 떠 있음 | Margin을 조금 내리고 비교 |
| 큰 삼각형 사이로 계속 보임 | 천 메시를 더 잘게 나눌 필요가 있는지 확인 |
| 천 전체가 통과하거나 움직이지 않음 | Margin보다 Target Cloth, 고정점, Max Distance, 이동 속도를 먼저 확인 |

Play 중 시험한 값은 종료하면 돌아갈 수 있습니다. **원하는 값을 적기 → Play 종료 → 그 값을 다시 입력 → Ctrl+S** 순서로 저장합니다. 원본 캡슐의 Radius나 Scale도 함께 키우면 결과를 비교하기 어려우므로, 먼저 Margin만 바꿉니다.

## 5. 준비된 천이 없을 때: 기본 Plane으로 연습하기

이 예시는 Scene 창에서 충돌만 관찰하기 위한 연습입니다. 처음에는 중력을 끄고, 천이 캡슐을 피하는지만 봅니다. 이 연습용 숫자를 실제 의상에 그대로 복사하지 않습니다.

### 천 한 장 준비

1. 현재 씬을 저장합니다. **File → New Scene → Empty → Create**로 새 씬을 만듭니다.
2. **Ctrl+Shift+S**로 `Assets` 안에 `ClothMarginPractice.unity`를 저장합니다.
3. **GameObject → 3D Object → Plane**을 누릅니다. Hierarchy에서 이름을 `PracticeCloth`로 바꿉니다.
4. Inspector의 Transform을 **Position=(0,0,0), Rotation=(-90,0,0), Scale=(1,1,1)**로 맞춥니다.
5. **Mesh Collider** 제목 오른쪽 메뉴 → **Remove Component**를 누릅니다. 평면의 일반 충돌체는 이번 실습에 쓰지 않습니다.
6. **Add Component → Cloth**를 추가합니다. Inspector에 Cloth와 Skinned Mesh Renderer가 보여야 합니다.
7. Cloth의 **Use Gravity**를 끄고 **Use Tethers**는 켭니다.
8. Scene 창에 마우스를 놓고 **F**를 눌러 천을 가운데로 맞춥니다. Scene 위쪽 **2D**를 켜 정면에서 사각형을 봅니다.
9. Cloth의 **Edit Constraints** 버튼을 누릅니다. 아이콘이면 마우스를 올려 이름을 확인합니다.
10. 나타난 Cloth Constraints 도구판에서 **Select**를 누르고 **Visualization = Max Distance**로 둡니다. 도구판이 없으면 Scene의 Overlays 메뉴에서 Cloth Constraints를 켭니다.
11. 빈 곳을 클릭한 뒤 모든 점을 감싸는 사각형을 마우스로 그립니다. **Max Distance 체크를 켜고 3**을 입력합니다. Surface Penetration은 사용하지 않습니다.
12. 빈 곳을 눌러 선택을 풀고 **맨 위 한 줄만** 사각형으로 선택합니다. Max Distance 체크를 켠 상태에서 **0**을 입력합니다.
13. 위쪽 점은 0, 아래쪽 점은 3인지 하나씩 선택해 확인합니다. Edit Constraints를 다시 눌러 편집을 끝냅니다.

### 캡슐을 연결하고 밀어 보기

1. **GameObject → 3D Object → Capsule**을 만들고 이름을 `PracticeCapsule`로 바꿉니다.
2. Transform을 **Position=(0,0,-1.5), Rotation=(0,0,0), Scale=(1,1,1)**로 맞춥니다. Capsule Collider는 남깁니다.
3. `Cloth Capsule Margin`을 추가하고 `Target Cloth`에 **PracticeCloth**를 드래그합니다. Margin은 **0.2**로 시작합니다.
4. Ctrl+S → Play → **Scene 탭**을 누릅니다. 카메라가 없는 연습 씬이라 Game 창 대신 Scene 창에서 봅니다.
5. Scene의 2D를 끄고 Alt+마우스 왼쪽 드래그로 비스듬히 봅니다. 천이 뒤에서 안 보이면 앞쪽으로 돌려 봅니다.
6. PracticeCapsule을 선택하고 **W**를 누릅니다. Scene 위쪽 축 기준을 **Global**로 두고 **파란색 Z 화살표**로 천 쪽으로 조금씩 밉니다. 시작 Z=-1.5에서 0, 그다음 약 0.5 정도까지 천천히 비교합니다.
7. 천 가운데가 캡슐 바깥으로 휘고 윗줄은 고정되어 있는지 봅니다. 멈춘 뒤 반복할 시작 위치와 Margin을 입력·저장합니다.

이 Plane은 가로·세로 10단위인 큰 격자입니다. 천이 닿는 부분의 점 간격 때문에 더 세밀한 의상과 결과가 다를 수 있습니다. 새 연습 씬의 결과는 대상 프로젝트에서 직접 확인해야 합니다.

## 6. 문제가 있을 때

| 증상 | 확인할 순서 |
|---|---|
| Add Component에서 검색되지 않음 | 코드 임포트 완료 → Console 첫 빨간 오류 → 파일 이름과 클래스 이름 확인 |
| Target Cloth가 None이거나 연결되지 않음 | 선택한 천에 Unity 기본 Cloth가 있는지 확인. 다른 천 도구의 컴포넌트는 연결 불가 |
| Target Cloth 오류 후 스크립트가 꺼짐 | Play 종료 → 천 연결 → 스크립트 체크박스 켜기 → 다시 Play |
| Cloth Collision Margin 자식이 없음 | Play 중인지, 부모·스크립트가 켜져 있는지, Console에 오류가 있는지 확인 |
| 보조 Capsule Collider가 꺼져 있음 | 현재 구현에서는 정상. 따로 켤 필요 없음 |
| 천이 전혀 변형되지 않음 | 움직일 점의 Max Distance가 모두 0인지 확인 |
| 천 전체가 지나감 | 대상 연결과 Cloth 이동 제한·고정점·시작 겹침 확인. 속도를 낮춰 비교 |
| Scale 관련 오류 | 오브젝트와 부모의 Scale이 0이 아닌지, Margin이 0 이상의 정상 숫자인지 확인 |
| 같은 클래스가 이미 있다는 컴파일 오류 | 같은 스크립트가 중복 설치되었는지 확인. 파일명만 바꾼 복사본으로 해결하지 않음 |
| 천이 한쪽에서 안 보임 | 얇은 면의 뒷면일 수 있음. Scene 시점을 돌리거나 사용 중인 셰이더의 양면 표시 확인 |

Margin을 무작정 크게 해도 모든 충돌 문제가 해결되지는 않습니다. 고정한 점을 캡슐로 밀어붙이는 상황, 아주 큰 삼각형, 빠른 순간이동은 별도 조정이 필요합니다.

## 7. 사용 범위와 갱신

- 이 컴포넌트 한 개는 **Capsule Collider 한 개와 Cloth 한 개**를 연결합니다.
- Target Cloth를 바꾸려면 Play를 종료한 뒤 다시 연결합니다. 재생 중 연결 대상을 바꾸는 기능은 아닙니다.
- 스크립트를 끄면 보조 캡슐을 제거하고 이 코드가 바꾼 충돌 목록 항목을 복구합니다.
- 보관한 `.unitypackage`는 저장 당시의 복사본입니다. 원본이 바뀌어도 자동으로 갱신되지 않습니다.
- 새 버전을 가져오기 전에 대상 프로젝트에서 따로 수정한 코드가 있는지 확인합니다. 같은 에셋의 갱신으로 가져오며, 같은 클래스를 중복으로 추가하지 않습니다.
- 원본 코드와 `.meta`를 함께 보관합니다. 파일 탐색기로 옮길 때도 한 쌍으로 취급합니다.

원본 코드의 컴파일·등록 복구 검사와 Test 씬의 충돌 동작은 Unity 6000.3.9f1에서 확인했습니다. 다른 프로젝트의 메시·Unity 버전·Player 빌드까지 검증한 결과는 아닙니다. 부모의 비균일 Scale과 자식 회전이 겹친 기울어진 변형도 별도 확인이 필요합니다.

## 8. 용어를 처음 볼 때

| 용어 | 쉬운 뜻 |
|---|---|
| Project 창 / Assets | 프로젝트에 저장된 파일을 찾는 창 / 주로 에셋을 보관하는 폴더 |
| Hierarchy | 현재 씬에 배치한 물체 목록 |
| Inspector | 선택한 물체나 파일의 설정을 보는 창 |
| Scene / Scene 창 | 물체와 설정을 저장하는 장면 / 그 장면을 편집하는 화면 |
| Game 창 | 게임 카메라가 그린 결과를 보여 주는 화면 |
| GameObject | 씬에 놓는 물체. 여러 기능을 붙일 수 있음 |
| Component | 물체에 붙이는 기능. Cloth, Capsule Collider, 이 스크립트 등이 해당 |
| Script / C# / .cs | 동작 규칙을 적은 코드 / 사용 언어 / 그 소스 파일의 확장자 |
| Class | 코드에서 기능과 데이터를 묶어 이름 붙인 정의. 이 코드는 ClothCapsuleMargin |
| Compile / Console | 코드를 검사·변환하는 과정 / 오류와 실행 기록을 보여 주는 창 |
| .unitypackage / Import | 옮길 에셋을 묶은 파일 / 프로젝트가 사용할 수 있게 가져오는 작업 |
| .meta / GUID | 에셋 식별 정보 파일 / 에셋을 구분하는 고유 식별자 |
| Cloth | 점들을 움직여 천 모양을 계산하는 Unity 기본 기능 |
| Collider / Capsule Collider | 부딪힘을 판단하는 보이지 않는 모양 / 둥근 양 끝이 있는 캡슐 충돌체 |
| Target Cloth / Reference | 이 코드가 사용할 천 / 특정 대상과의 연결 |
| None | 아직 연결된 대상이 없다는 표시 |
| Margin / World 단위 | 캡슐 바깥에 더할 거리 / 씬 전체에서 거리를 재는 단위 |
| Mesh / Vertex / Triangle | 물체의 표면 데이터 / 표면의 점 / 점 세 개를 이은 면 |
| Skinned Mesh Renderer | 변형되는 메시를 화면에 그리는 기능. Cloth가 함께 사용 |
| Transform | 물체의 Position·Rotation·Scale을 묶은 설정 |
| Position / Rotation / Scale | 위치 / 회전 각도 / 크기 배율 |
| Axis / Global | X·Y·Z 방향 기준 / 씬 전체 방향을 기준으로 조작 |
| Parent / Child | 다른 물체를 포함하는 부모 / 그 안에 들어간 자식 |
| Play | Editor 안에서 게임을 실행하는 상태 |
| Constraints / Max Distance | 움직임을 제한하는 규칙 / 기준 위치에서 허용한 최대 이동 거리. 0이면 고정 |
| Use Gravity / Use Tethers | 중력 사용 / 천이 지나치게 늘어나는 것을 줄이는 거리 제한 사용 |
| Visualization / Overlay | 편집 정보를 화면에 보여 주는 방식 / Scene 위에 표시되는 도구판 |
| Surface Penetration | Cloth의 기준 표면 주변 침투 제한 설정. 외부 캡슐의 Margin과 다른 기능 |
| Shader / 양면 표시 | 표면을 그리는 규칙 / 얇은 면의 앞뒤를 모두 그리는 설정 |
| Player 빌드 | Unity Editor 밖에서 실행할 프로그램을 만드는 것 |

공식 참고: [패키지 가져오기](https://docs.unity3d.com/6000.3/Documentation/Manual/AssetPackagesImport.html), [Cloth](https://docs.unity3d.com/6000.3/Documentation/Manual/class-Cloth.html), [Cloth 캡슐 목록](https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Cloth-capsuleColliders.html), [메타 파일](https://docs.unity3d.com/6000.3/Documentation/Manual/AssetMetadata.html).
