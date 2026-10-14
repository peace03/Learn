# C#과 실행 흐름

> 모르는 단어는 [전문 용어 전체 색인](../90_용어사전/README.md)에서 영문·한글로 찾습니다. 이 장 맨 아래에는 등장 용어의 바로가기 목록이 있습니다.

## 코드도 한 줄씩 숫자와 대상을 바꾸는 지시문이다

**C#**은 이 프로젝트의 동작을 쓰는 프로그래밍 언어입니다. **소스 코드**는 사람이 작성한 명령 글, **컴파일**은 이를 검사하고 실행 가능한 코드로 바꾸는 과정입니다. Console에 컴파일 오류가 남으면 새 스크립트 부착이나 Editor 도구가 나타나지 않을 수 있습니다.

**변수**는 이름을 붙인 값, **자료형**은 어떤 값을 담을지 정한 규칙입니다. `float speed = 6f;`는 소수형 변수 speed에 6을 넣습니다. `f`는 C#의 float 숫자 표기, `=`는 대입, `;`는 명령 끝입니다. 수학에서 등식을 뜻하는 `=`와 다릅니다. 같은지 비교할 때는 보통 `==`를 씁니다.

**함수**는 이름을 붙여 호출할 수 있는 작업입니다. 클래스 안의 함수를 **메서드**라고 부릅니다. `Rotate(...)`의 괄호 안 값은 작업에 넘기는 **인수**입니다. **클래스**는 값과 기능을 묶은 정의, **인스턴스**는 그 정의로 만든 실제 대상입니다. `.cs` 파일을 씬 물체에 붙이는 것은 그 물체에 동작 컴포넌트를 연결하는 일입니다.

아래 한 줄의 `transform`은 이 컴포넌트가 붙은 물체의 Transform, 점 `.`은 그 안의 기능 찾기, `new Vector3(0f,6f,0f)`는 세 수 묶음 만들기, `*`는 곱하기입니다. `Time.deltaTime`을 곱한 결과를 Rotate에 넘깁니다. 한 줄 안에도 **대상 → 입력값 → 시간 보정 → 호출**이 들어 있습니다.

**배열**은 같은 종류의 값을 번호로 찾는 목록입니다. 번호인 **인덱스**는 0부터 시작하므로 2개면 0과 1입니다. `Posts[0]`은 첫 물체, `Posts.Length`는 물체 수입니다. **null**은 가리키는 대상이 없다는 값입니다. None인 슬롯을 채워야 하는 이유가 여기에 있습니다.

실습에서는 코드를 새로 작성하지 않고 이미 있는 회전 스크립트를 붙입니다. 문법을 모두 외우기 전에 “누가, 언제, 어떤 값을 바꾸나”를 확인하면 됩니다.

## 먼저 이 코드 한 줄을 읽는다

프로젝트의 `Lab_TransformRotate.Update()`:

```csharp
transform.Rotate(new Vector3(0f, 6f, 0f) * Time.deltaTime);
```

“이 물체를 Y축으로 초당 6도 회전시킨다”는 뜻입니다. `Time.deltaTime`은 직전 프레임부터 흐른 시간입니다. 프레임마다 6도씩 돌리는 코드와 다릅니다.

## 자주 나오는 문법

| 코드 | 뜻 | 프로젝트에서 읽는 방법 |
|---|---|---|
| `class` | 데이터와 기능을 묶는 설계 | `Lab_PostSelection`이라는 기능 정의 |
| `: MonoBehaviour` | GameObject에 붙는 Unity 동작 | 생명주기 함수를 Unity가 호출 |
| `public` | 외부 접근을 허용 | 일반적인 지원 필드는 Inspector에도 직렬화됨 |
| `private` | 그 클래스 내부에서 사용 | 공개 설정과 내부 상태를 구분 |
| `[SerializeField]` | 비공개 필드도 저장·표시하도록 요청 | 반사 설정의 Inspector 노출 |
| `float` / `int` / `bool` | 소수 / 정수 / 참거짓 | 속도 / 선택 번호 / 켜짐 여부 |
| `GameObject[]` | 여러 오브젝트를 순서대로 담는 배열 | `Posts` 목록 |
| `void` | 돌려주는 값이 없는 함수 | `NextPost()`는 상태를 바꿈 |
| `if` / `return` | 조건 검사 / 함수 종료 | 빈 배열이면 작업 중단 |
| `foreach` | 목록을 하나씩 처리 | 여러 Renderer에 재질 배치 |
| `null` | 연결된 대상 없음 | Inspector의 None, Missing 점검 |
| `static` | 개별 인스턴스보다 클래스 쪽에 공유 | 변환 도구 함수·공유 반사 카메라 |
| `namespace` | 이름의 주소 공간 | `URPLabStudio`, `NCAI.VARCO3D.Bridge` |

직렬화는 메모리의 설정을 파일에 적고 다시 읽는 일입니다. 코드 초기값과 Inspector에 저장된 값은 다를 수 있습니다. 예를 들어 반사 해상도의 코드 초기값은 Third지만 주 씬에는 Full이 저장되어 있습니다.

## Unity가 호출하는 시점

| 함수 | 일반적인 역할 | 이 프로젝트 사례 |
|---|---|---|
| Awake | 인스턴스 초기화 시 참조 준비 | Fade가 Image를 찾아 검정색으로 설정 |
| OnEnable | 활성화될 때 구독·시작 | 반사 코드가 렌더 이벤트 구독 |
| Start | 활성 상태에서 첫 Update 전 초기 작업 | `Lab_XYZRotate`에는 빈 함수 |
| Update | 프레임마다 처리 | 회전·페이드 |
| FixedUpdate | 고정 시간 간격의 물리 처리 | 현재 회전 코드에서는 사용하지 않음 |
| OnDisable | 비활성화 시 정리 | 반사 이벤트 해제·텍스처 반환 |
| OnDestroy | 파괴 시 정리 | 반사 자원 정리 |

같은 오브젝트의 일반 흐름과 여러 오브젝트 사이의 실행 순서는 구별합니다. A의 Update가 항상 B보다 먼저라고 가정하면 안 됩니다. 활성 상태·생성 시점에 따라 호출 시점도 달라집니다. [Unity 실행 순서](https://docs.unity3d.com/6000.0/Documentation/Manual/execution-order.html).

## 회전 코드 두 개 비교

`Lab_XYZRotate`는 다음처럼 회전합니다.

```csharp
transform.Rotate(x + 0f, y + 0f, z + 0f);
```

여기서 y=1이면 **프레임당 1도**입니다. 30FPS이면 초당 약 30도, 120FPS이면 약 120도입니다. `+0f`는 값을 바꾸지 않습니다.

`Lab_TransformRotate`는 초당 6도이므로 약 60초에 360도입니다. `deltaTime`을 곱하면 프레임 속도 차이를 보정하지만, 시간 배율이 바뀌면 영향을 받습니다. 무조건 현실 시계 기준의 60초를 보장한다는 뜻은 아닙니다.

## 실습: 회전 컴포넌트 붙이기

1. 복사 씬의 `Study_Cube`를 선택합니다.
2. Project에서 `Assets/VARCO_URP/06.Scripts/Lab_Canvas/Lab_TransformRotate.cs`를 찾습니다.
3. 파일을 **선택한 Cube의 Inspector 빈 공간**으로 드래그합니다.
4. Inspector에 해당 컴포넌트가 생겼는지 확인합니다.
5. Play를 켜고 천천히 도는지 봅니다. 정지하면 편집 시점 회전으로 돌아오는지 확인합니다.
6. 같은 오브젝트에 두 회전 스크립트를 동시에 붙이면 두 회전이 합쳐질 수 있습니다. 비교 실습은 하나만 켜고 합니다.

스크립트가 Project에 있다는 것만으로 Update가 실행되지는 않습니다. 오브젝트에 붙고, 활성 조건을 만족해야 합니다. `[ExecuteAlways]`가 있는 컴포넌트는 편집 중에도 실행될 수 있어 별도로 봅니다.

## 배열과 나머지 연산

`Lab_PostSelection`의 핵심:

```csharp
selectedPost = (selectedPost + 1) % Posts.Length;
```

Posts가 3개라면 번호는 `0 → 1 → 2 → 0`으로 돕니다. `%`는 나눈 나머지입니다. 이전 번호는 `(selectedPost - 1 + Posts.Length) % Posts.Length`로 계산해 0에서 마지막으로 돌아갑니다.

현재 코드는 배열이 없거나 길이가 0인 경우는 막지만, 배열 안의 null이나 범위를 벗어난 selectedPost까지 막지 않습니다. 따라서 Inspector에 올바르게 연결하는 것이 실습의 전제입니다. 문서에서 이 코드를 고쳤다고 주장하지 않습니다.

## 페이드 수식 읽기

`Lab_FadeFromBlack`은 다음 원리를 사용합니다.

```text
진행률 = Clamp01(지난 시간 / 전체 시간)
알파 = 1 - 진행률
```

처음에는 알파 1로 검정 화면, 끝에는 0으로 투명합니다. `Clamp01`은 0보다 작으면 0, 1보다 크면 1로 제한합니다. 시간이 끝나면 오브젝트를 끕니다.

현재 구현은 Awake에만 초기화하고 재활성화 때 경과 시간을 초기화하지 않습니다. 한 번 껐다 켜서 같은 페이드를 반복 재생하는 구조가 아닙니다. `fadeInStartFrame`도 해당 오브젝트가 켜진 뒤 프레임이 아니라 전역 `Time.frameCount`와 비교합니다.

## 이벤트와 자원 수명

`+=`는 “일이 생기면 이 함수도 불러 달라”는 등록입니다. `-=`는 취소입니다. `UVC_Reflections`는 카메라 렌더 직전에 실행되도록 등록하고, 꺼질 때 해제합니다. 임시 RenderTexture도 반환합니다.

`try/finally`는 중간에 문제가 생겨도 정리 코드를 실행하기 위한 구조입니다. 반사 코드가 뒤집어 놓은 Culling·Fog·LOD 설정을 원상복구하는 데 사용합니다. `catch`는 예외를 잡아 기록하거나 처리합니다. 둘은 역할이 다릅니다.

**확인 질문:** 60FPS에서 프레임당 2도면 초당 몇 도인가? Inspector에서 None인 오브젝트의 함수를 호출하면 왜 문제가 될까?

**답:** 약 120도입니다. 실제 대상 참조가 없으므로 멤버에 접근할 수 없습니다.

## 이 장의 용어 찾기

모르는 말은 아래 링크 또는 [전체 용어 색인](../90_용어사전/README.md)에서 찾습니다. 영문 UI 이름도 검색할 수 있습니다.

- PC와·Unity: [Component](../90_용어사전/01_PC와_Unity.md#component) · [Console](../90_용어사전/01_PC와_Unity.md#console) · [GameObject](../90_용어사전/01_PC와_Unity.md#gameobject) · [Inspector](../90_용어사전/01_PC와_Unity.md#inspector) · [Instance](../90_용어사전/01_PC와_Unity.md#instance) · [Missing](../90_용어사전/01_PC와_Unity.md#missing) · [None](../90_용어사전/01_PC와_Unity.md#none) · [Play](../90_용어사전/01_PC와_Unity.md#play) · [Project](../90_용어사전/01_PC와_Unity.md#project) · [Transform](../90_용어사전/01_PC와_Unity.md#transform) · [Unity](../90_용어사전/01_PC와_Unity.md#unity) · [데이터](../90_용어사전/01_PC와_Unity.md#data)

- 수학과·모델: [3D](../90_용어사전/02_수학과_모델.md#3d) · [Clamp01](../90_용어사전/02_수학과_모델.md#clamp01) · [Cube](../90_용어사전/02_수학과_모델.md#cube) · [Vector3](../90_용어사전/02_수학과_모델.md#vector3)

- USD와·파일형식: [.cs](../90_용어사전/03_USD와_파일형식.md#cs-file)

- 표면과·렌더링: [Culling](../90_용어사전/04_표면과_렌더링.md#culling) · [Fog](../90_용어사전/04_표면과_렌더링.md#fog) · [Renderer](../90_용어사전/04_표면과_렌더링.md#renderer) · [RenderTexture](../90_용어사전/04_표면과_렌더링.md#rendertexture) · [Resolution](../90_용어사전/04_표면과_렌더링.md#resolution) · [Texture](../90_용어사전/04_표면과_렌더링.md#texture)

- 효과와·움직임과·UI: [Fade](../90_용어사전/05_효과와_움직임과_UI.md#fade) · [Image](../90_용어사전/05_효과와_움직임과_UI.md#image-ui)

- 코드와·통신과·검증: [Awake](../90_용어사전/06_코드와_통신과_검증.md#awake) · [bool](../90_용어사전/06_코드와_통신과_검증.md#bool) · [C#](../90_용어사전/06_코드와_통신과_검증.md#csharp) · [catch](../90_용어사전/06_코드와_통신과_검증.md#catch) · [class](../90_용어사전/06_코드와_통신과_검증.md#class) · [deltaTime](../90_용어사전/06_코드와_통신과_검증.md#deltatime) · [Event](../90_용어사전/06_코드와_통신과_검증.md#event) · [ExecuteAlways](../90_용어사전/06_코드와_통신과_검증.md#executealways) · [finally](../90_용어사전/06_코드와_통신과_검증.md#finally) · [FixedUpdate](../90_용어사전/06_코드와_통신과_검증.md#fixedupdate) · [float](../90_용어사전/06_코드와_통신과_검증.md#float) · [foreach](../90_용어사전/06_코드와_통신과_검증.md#foreach) · [Frame](../90_용어사전/06_코드와_통신과_검증.md#frame) · [int](../90_용어사전/06_코드와_통신과_검증.md#int) · [Length](../90_용어사전/06_코드와_통신과_검증.md#length) · [Lifecycle](../90_용어사전/06_코드와_통신과_검증.md#lifecycle) · [LOD](../90_용어사전/06_코드와_통신과_검증.md#lod) · [Memory](../90_용어사전/06_코드와_통신과_검증.md#memory) · [MonoBehaviour](../90_용어사전/06_코드와_통신과_검증.md#monobehaviour) · [namespace](../90_용어사전/06_코드와_통신과_검증.md#namespace) · [new](../90_용어사전/06_코드와_통신과_검증.md#new) · [null](../90_용어사전/06_코드와_통신과_검증.md#null) · [OnDestroy](../90_용어사전/06_코드와_통신과_검증.md#ondestroy) · [OnDisable](../90_용어사전/06_코드와_통신과_검증.md#ondisable) · [OnEnable](../90_용어사전/06_코드와_통신과_검증.md#onenable) · [private](../90_용어사전/06_코드와_통신과_검증.md#private) · [public](../90_용어사전/06_코드와_통신과_검증.md#public) · [return](../90_용어사전/06_코드와_통신과_검증.md#return) · [Serialization](../90_용어사전/06_코드와_통신과_검증.md#serialization) · [SerializeField](../90_용어사전/06_코드와_통신과_검증.md#serializefield) · [static](../90_용어사전/06_코드와_통신과_검증.md#static-code) · [Time.frameCount](../90_용어사전/06_코드와_통신과_검증.md#framecount) · [try](../90_용어사전/06_코드와_통신과_검증.md#try) · [VARCO](../90_용어사전/06_코드와_통신과_검증.md#varco) · [VARCO Bridge](../90_용어사전/06_코드와_통신과_검증.md#bridge) · [void](../90_용어사전/06_코드와_통신과_검증.md#void) · [나머지 연산](../90_용어사전/06_코드와_통신과_검증.md#remainder) · [메서드](../90_용어사전/06_코드와_통신과_검증.md#method) · [소스 코드](../90_용어사전/06_코드와_통신과_검증.md#source) · [인덱스](../90_용어사전/06_코드와_통신과_검증.md#index) · [자료형](../90_용어사전/06_코드와_통신과_검증.md#type) · [컴파일](../90_용어사전/06_코드와_통신과_검증.md#compile)

- 화면의·속성과·메뉴: [Posts](../90_용어사전/07_화면의_속성과_메뉴.md#posts) · [Selected Post](../90_용어사전/07_화면의_속성과_메뉴.md#selected-post)

- API와·추가설정: [NextPost](../90_용어사전/08_API와_추가설정.md#nextpost) · [Rotate](../90_용어사전/08_API와_추가설정.md#rotate)

- 보충·기초와·도구이름: [Camera](../90_용어사전/09_보충_기초와_도구이름.md#camera) · [fadeInStartFrame](../90_용어사전/09_보충_기초와_도구이름.md#fade-start)

- 프로젝트·코드·식별자: [Lab_FadeFromBlack](../90_용어사전/10_프로젝트_코드_식별자.md#script-lab_fadefromblack) · [Lab_PostSelection](../90_용어사전/10_프로젝트_코드_식별자.md#script-lab_postselection) · [Lab_TransformRotate](../90_용어사전/10_프로젝트_코드_식별자.md#script-lab_transformrotate) · [Lab_XYZRotate](../90_용어사전/10_프로젝트_코드_식별자.md#script-lab_xyzrotate) · [UVC_Reflections](../90_용어사전/10_프로젝트_코드_식별자.md#script-uvc_reflections)
