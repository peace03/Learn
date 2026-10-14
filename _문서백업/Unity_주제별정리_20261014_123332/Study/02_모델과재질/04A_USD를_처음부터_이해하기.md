# 04A. USD를 처음부터 이해하기

> 모르는 단어는 [전문 용어 전체 색인](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4_%EC%82%AC%EC%A0%84.md)에서 영문·한글로 찾습니다. 이 장 맨 아래에는 등장 용어의 바로가기 목록이 있습니다.

먼저 준비 A의 파일·경로·참조, 준비 B의 메시·뼈대·시간, 04장의 임포트를 이해합니다. **USD는 Universal Scene Description의 약자이며, 3D 장면의 구성과 속성을 기록하고 여러 자료를 합쳐 다루는 체계**입니다. 장면은 물체 하나뿐 아니라 물체 관계·재질·빛·카메라·시간별 변화까지 포함할 수 있습니다. OpenUSD는 공개된 USD 기술과 구현을 부르는 이름입니다. [OpenUSD 소개](https://openusd.org/release/intro.html).

## 왜 그림 파일만으로 부족할까

로봇 사진에는 보는 방향의 색만 남습니다. 뒤로 돌려 보려면 입체 모양, 걷게 하려면 뼈와 시간별 자세, 금속처럼 보이게 하려면 표면 정보가 필요합니다. 다른 제작 프로그램에 넘길 때도 이 정보를 어떤 이름·단위·관계로 읽을지 약속해야 합니다. **파일 형식**은 그런 기록 규칙입니다.

USD는 파일 저장에 더해 여러 장면 자료를 연결하고 합치는 규칙도 제공합니다. 모델 담당자는 모양을, 배치 담당자는 위치를 별도 자료에 기록할 수 있습니다. 원본 로봇을 직접 고치지 않고 다른 장면에서 위치만 바꿔 사용하는 구성이 가능합니다. 모든 프로그램이 USD의 모든 기능을 지원한다는 뜻은 아닙니다.

## USD·USDA·USDC·USDZ를 각각 구분한다

| 이름 | 무엇인가 | 메모장으로 읽을 수 있는가 |
|---|---|---|
| USD | 장면을 기술·조합하는 전체 체계. `.usd` 확장자 이름으로도 사용 | 확장자만으로 판단 못 함 |
| USDA, `.usda` | 사람이 읽을 수 있는 UTF-8 텍스트로 쓴 USD 레이어 | 가능 |
| USDC, `.usdc` | 프로그램이 효율적으로 읽는 바이너리 방식의 USD 레이어 | 일반 텍스트처럼 읽지 못함 |
| `.usd` | USDA 또는 USDC 내용을 담을 수 있는 확장자 | 내부 형식을 확인해야 함 |
| USDZ, `.usdz` | USD 자료와 이미지 등 관련 파일을 한 묶음에 담는 형식 | 묶음 내부를 먼저 확인해야 함 |

따라서 **USDZ 안에 반드시 USDA가 있다는 보장은 없습니다.** `.usd`도 항상 바이너리는 아닙니다. 확장자 변경은 실제 형식 변환이 아닙니다. [OpenUSD 파일 형식 FAQ](https://openusd.org/release/usdfaq.html).

USDZ는 ZIP을 기반으로 하지만 내부 파일을 압축하지 않는 방식과 배치 규칙 등을 정한 패키지입니다. 일반 ZIP의 이름만 `.usdz`로 바꿔서 정상 파일을 만들 수는 없습니다. 읽기 도구로 묶음을 여는 것과 유효한 USDZ를 만드는 것은 다릅니다. [USDZ 규격](https://openusd.org/release/spec_usdz.html).

## 장면을 구성하는 최소 단위

| 개념 | 뜻 | 로봇 사례 |
|---|---|---|
| Prim | USD 장면에서 주소를 가진 기본 요소 | 로봇 묶음·메시·재질 각각의 요소 |
| Prim Path | Prim을 찾는 계층 주소 | `/Robot/Body` |
| Attribute | 값으로 기록하는 속성 | 크기·색·시간별 회전 |
| Relationship | 다른 요소를 가리키는 관계 | 어떤 뼈대 등을 사용할지 연결 |
| Schema | 특정 종류의 요소가 쓰는 속성과 동작의 약속 | Mesh 종류와 Skeleton 종류의 규칙 |
| Layer | 장면에 대한 기록 한 묶음 | 원본 모양 기록, 추가 배치 기록 |
| Stage | 레이어·참조를 해석해 얻은 장면 전체 | 이 장면에서 보게 될 로봇과 배경의 구성 |
| Composition | 여러 기록을 정해진 우선순위와 규칙으로 합치기 | 원본의 모양 + 이 장면에서 정한 위치 |

Layer는 반드시 포토샵의 그림 층이나 Unity Layer 번호와 같은 개념이 아닙니다. Stage도 `.unity` 씬 파일과 동일한 형식이 아닙니다. 비슷한 역할을 비유로 이해한 뒤 실제 저장 규칙은 구분합니다. [OpenUSD 용어](https://openusd.org/release/glossary.html).

별도 파일의 요소를 가져오는 **USD Reference**, 레이어를 함께 쌓는 **Sublayer**, 필요한 내용의 불러오기를 미룰 수 있는 **Payload**, 여러 구성을 선택하는 **Variant** 같은 방식이 있습니다. 이 프로젝트의 초보 실습에서는 이를 새로 작성하지 않습니다. “USD는 원본과 변경을 나눠 합칠 수 있다”는 목적을 이해하면 됩니다. 단순히 마지막으로 저장한 파일이 무조건 이기는 규칙은 아닙니다. [레이어 참조 예제](https://openusd.org/release/tut_referencing_layers.html).

## 짧은 USDA를 한 줄씩 읽는다

다음은 이해를 위해 작성한 작은 예입니다. 프로젝트 로봇 파일의 전체 내용이 아니며, Unity에 넣는 필수 실습도 아닙니다.

```usda
#usda 1.0
(
    upAxis = "Y"
    metersPerUnit = 1
)
def Xform "StudyRoot"
{
    def Sphere "Ball"
    {
        double radius = 0.5
    }
}
```

1. `#usda 1.0`: 이 파일이 USDA 문법임을 나타내는 첫 표기입니다.
2. 괄호 `()` 안의 두 값은 자료를 어떻게 해석할지 알려 주는 **메타데이터**입니다. `upAxis="Y"`는 Y가 위, `metersPerUnit=1`은 길이 1단위를 1m로 해석한다는 뜻입니다.
3. `def`는 요소를 정의한다는 문법입니다. `Xform`은 변환과 자식 묶음에 쓰는 종류, `StudyRoot`는 우리가 붙인 이름입니다.
4. `{}` 안에는 그 요소의 내용이 들어갑니다. `Sphere`는 구 종류이며 `Ball`이라는 자식 요소를 만듭니다. 주소는 `/StudyRoot/Ball`입니다.
5. `double`은 소수를 표현하는 수 자료형, `radius`는 반지름입니다. 0.5m 반지름이면 지름은 1m입니다.

이 예에 재질·조명·카메라를 따로 적지 않았습니다. “USD를 열었다”는 사실만으로 같은 조명과 카메라의 완성 화면이 보장되지 않습니다. 기본 구 예제의 문법은 [OpenUSD 첫 Stage 예제](https://openusd.org/release/tut_helloworld.html), 수 자료형은 [USD 자료형 표](https://openusd.org/release/api/_usd__page__datatypes.html)를 참고했습니다.

## 이 프로젝트의 Walk USDZ 안에는 무엇이 있나

현재 원본 `Assets/VARCO3DImports/Streetwear Robot_Walk/Streetwear Robot_Walk.usdz`를 읽어 확인한 목록입니다.

```text
Streetwear Robot_Walk.usdz
├─ model.usda              장면·뼈·애니메이션·표면 연결 기록
├─ mat_3_base_color.png    표면 색 이미지
├─ mat_3_normal.png        표면의 작은 요철 방향 이미지
└─ mat_3_orm.png           차폐·거칠기·금속성 수치 이미지
```

`model.usda`에는 `SkelRoot`(뼈 기반 모델 묶음), `SkelAnimation`(뼈의 시간별 변화), `joints`(관절 주소 목록)가 있습니다. `rotations`, `translations`, `scales`는 회전·이동·크기이며, `timeSamples`는 어떤 시각에 어떤 값인지 기록한 표입니다. `uniform token[] joints`에서 `token`은 이름 등에 쓰는 문자열 종류, `[]`는 여러 개의 목록, `uniform`은 시간에 따라 변하지 않는 속성이라는 표기입니다.

현재 기록은 Y-up, metersPerUnit=1, framesPerSecond=30, timeCodesPerSecond=30, 시작 시간 코드 2, 끝 84입니다. **시간 코드**는 파일 안의 시간 눈금입니다. 초당 눈금 30이면 2에서 32까지 30눈금 차이는 1초입니다. 파일 FPS와 실제 게임 FPS는 같을 필요가 없습니다.

표면 연결은 Base Color RGB, Normal RGB, ORM의 R=Occlusion·G=Roughness·B=Metallic입니다. USD의 `UsdPreviewSurface`는 표면 속성을 교환하기 위한 공통 규칙이며 URP/Lit과 똑같은 프로그램은 아닙니다. 두 표면 규칙의 채널 약속을 맞춰야 하므로 05장의 재질 과정이 필요합니다.

## 읽기 실습: 원본을 바꾸지 않고 내부 확인하기

1. Unity Project 창에서 위 Walk `.usdz`를 찾습니다. 우클릭 `Show in Explorer`로 Windows 파일 위치를 엽니다.
2. 파일을 `Ctrl+C`로 복사합니다. 바탕화면에 새 `USD_읽기연습` 폴더를 만들어 `Ctrl+V`로 붙입니다. 원본 프로젝트 밖의 **복사본**인지 주소를 확인합니다.
3. 파일 탐색기의 확장명 표시를 켭니다. 복사본 이름만 `Walk_보기.zip`으로 바꿉니다. 확장자 변경 경고는 이 복사본에 한해서 확인합니다. 이것은 형식 변환이 아니라 ZIP 기반 내부 목록을 읽기 위한 방법입니다.
4. 우클릭 `모두 압축 풀기`로 별도 폴더에 꺼냅니다. 해당 Windows 도구가 읽지 못하면 여기서 멈추고 위 확인된 목록으로 학습합니다. 원본 이름을 바꾸거나 재압축해 덮어쓰지 않습니다.
5. 추출된 `model.usda`를 우클릭 → `연결 프로그램 > 메모장`으로 엽니다. 다른 앱이 기본으로 열리면 연결 프로그램에서 메모장을 고릅니다.
6. `Ctrl+F`로 `metersPerUnit`, `timeCodesPerSecond`, `SkelAnimation`, `inputs:metallic.connect`를 각각 찾습니다. 검색창을 닫은 뒤 주변 줄을 읽습니다.
7. metallic의 연결이 `orm.outputs:b`인지 확인합니다. `b`는 파란색 채널의 수치를 읽는다는 뜻입니다. 현재 자료에서는 그 수가 금속성입니다.
8. 저장하지 않고 닫습니다. 메모장 안의 모든 긴 숫자를 읽을 필요는 없습니다. 목록·단위·시간·연결 네 가지를 찾으면 완료입니다.

만약 다른 모델에 USDC만 있다면 메모장으로 읽지 못하는 것이 정상입니다. OpenUSD 도구 `usdcat` 같은 실제 변환 도구가 필요하지만, 현재 학습에 그 설치를 요구하지 않습니다. 지금 원본 Walk는 USDA가 포함되어 있습니다.

## Unity에서 읽기와 전용 변환기는 별개다

```text
USDZ 파일 → Unity USD Importer → Unity가 사용할 모델·클립 등
                           ↓
전용 ExtractTool → 별도 FBX·이미지·재질·프리팹
```

**임포터**는 외부 기록을 Unity 데이터로 해석하는 도구, **익스포터**는 다른 파일 형식으로 내보내는 도구입니다. Bridge는 파일 수신과 Unity 임포트를 이어 줍니다. 프로젝트의 ExtractTool은 USDZ 안에서 첫 `.usda`만 고르고 특정 애니메이션 문구를 해석합니다. 유효한 USDZ라도 이 전용 도구가 지원하지 않는 구성이 있습니다. 특히 텍스트 내용이더라도 `.usd` 이름이면 현재 코드의 `.usda` 검색에 걸리지 않습니다.

Unity USD Importer의 지원 범위와 ExtractTool의 한계는 서로 다릅니다. [Unity USD Importer 안내](https://docs.unity3d.com/Packages/com.unity.importer.usd@1.0/manual/index.html)는 전자의 자료이며, 후자는 프로젝트 소스가 기준입니다. 11장에서 백업과 실제 변환 순서를, 15장에서 코드 원리를 배웁니다.

## FBX와 비교하면

FBX도 모양·뼈·애니메이션 등을 전달하는 형식입니다. FBX를 단순한 정지 모델 전용 파일로 외우면 안 됩니다. 이 프로젝트에서는 Unity의 FBX 임포트·Avatar 설정·기존 애니메이션 작업 흐름을 사용하려고 결과를 FBX로 만듭니다. USD의 레이어 합성 규칙과 표면 표현이 변환 후 그대로 유지된다는 뜻은 아닙니다.

질문: USDZ를 FBX로 변환하면 이미지도 반드시 같은 모습일까요? **답:** 아닙니다. 단위·축·뼈·표면 채널·조명까지 맞는지 확인해야 합니다. 파일이 생기는 것과 외관이 맞는 것은 다른 검사입니다.

## 이 장의 용어 찾기

모르는 말은 아래 링크 또는 [전체 용어 색인](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4_%EC%82%AC%EC%A0%84.md)에서 찾습니다. 영문 UI 이름도 검색할 수 있습니다.

- PC와·Unity: [Exporter](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#exporter) · [Import](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#import) · [Importer](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#importer) · [Layer](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#layer) · [Package](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#package) · [Prefab](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#prefab) · [Project](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#project) · [Reference](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#reference) · [Unity](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#unity) · [UTF-8](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#utf8) · [경로](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#path) · [데이터](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#data) · [바이너리](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#binary) · [파일 형식](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#format) · [프로그램](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#program) · [확장자](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#extension)

- 수학과·모델: [3D](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#3d) · [Mesh](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#mesh) · [Normal](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#normal) · [Sphere](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#sphere)

- USD와·파일형식: [.unity](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#scene-file) · [Attribute](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#attribute) · [Composition](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#composition) · [def](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd-def) · [FBX](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#fbx) · [framesPerSecond](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#framespersecond) · [joints](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#joints) · [Metadata](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#metadata) · [metersPerUnit](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#meters) · [OpenUSD](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#openusd) · [Payload](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#payload) · [Prim](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#prim) · [Prim Path](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#prim-path) · [Relationship](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#relationship) · [rotations](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#rotations) · [scales](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#scales) · [Schema](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#schema) · [SkelAnimation](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#skelanimation) · [SkelRoot](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#skelroot) · [Stage](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#stage) · [Sublayer](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#sublayer) · [timeCodesPerSecond](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#timecodespersecond) · [timeSamples](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#timesamples) · [token](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#token) · [translations](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#translations) · [uniform](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#uniform) · [upAxis](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#upaxis) · [USD](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd) · [USD Importer](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd-importer) · [USD Reference](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd-reference) · [USDA](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usda) · [USDC](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usdc) · [usdcat](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usdcat) · [UsdPreviewSurface](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usdpreview) · [USDZ](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usdz) · [Variant](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#variant) · [Xform](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#xform) · [ZIP](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#zip) · [시간 코드](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#timecode)

- 표면과·렌더링: [Ambient Occlusion](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#ao) · [Base Color](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#basecolor) · [Lit](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#lit) · [Metallic](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#metallic) · [ORM](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#orm) · [RGB](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#rgb) · [Roughness](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#roughness) · [URP](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#urp)

- 효과와·움직임과·UI: [Animation](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#animation) · [Avatar](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#avatar) · [Priority](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#priority) · [Skeleton](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#skeleton)

- 코드와·통신과·검증: [double](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#double) · [FPS](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#fps) · [string](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#string) · [VARCO Bridge](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#bridge) · [자료형](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#type)

- 보충·기초와·도구이름: [Camera](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#camera) · [radius](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#radius) · [Show in Explorer](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#show-explorer)

<!-- study-navigation -->
[이전](04_%EB%AA%A8%EB%8D%B8_%EC%9E%84%ED%8F%AC%ED%8A%B8%EC%99%80_%ED%94%84%EB%A6%AC%ED%8C%B9.md) · [목차](../README.md) · [다음](05_PBR_%ED%85%8D%EC%8A%A4%EC%B2%98%EC%99%80_%EC%9E%AC%EC%A7%88.md)
