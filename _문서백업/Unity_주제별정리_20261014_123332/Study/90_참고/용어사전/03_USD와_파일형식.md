# 용어 사전 03. USD와 · 파일형식

[전체 검색 색인](../용어_사전.md) · [학습 목차](../../README.md)

각 항목은 **뜻 → 작동 원리 또는 예 → 적용 조건** 순서입니다. 동일 개념의 한글·영문·약어는 한 항목에서 함께 찾습니다. 서로 다른 개념은 별도 항목으로 둡니다.

근거: [USD 파일 형식](https://openusd.org/release/usdfaq.html), [USDZ 규격](https://openusd.org/release/spec_usdz.html), [Prim API](https://openusd.org/release/api/class_usd_prim.html), [Stage API](https://openusd.org/release/api/class_usd_stage.html), [Layer API](https://openusd.org/release/api/class_sdf_layer.html), [자료형](https://openusd.org/release/api/_usd__page__datatypes.html)

<a id="usd"></a>

## USD · Universal Scene Description

3D 장면의 요소·속성·관계를 기록하고 여러 자료를 조합하는 체계입니다.

모델 파일 확장자 하나만 뜻하지 않습니다. 04A장에서 원리부터 읽습니다.

함께 찾기: [확장자](01_PC%EC%99%80_Unity.md#extension) · [3D](02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#3d)

<a id="openusd"></a>

## OpenUSD

공개된 USD 기술과 소프트웨어 구현을 부르는 이름입니다.

USD의 기본 장면 규칙을 공식 문서에서 확인할 수 있습니다.

함께 찾기: [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd) · [소프트웨어](09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#software)

<a id="usda"></a>

## USDA

USD 레이어를 사람이 읽는 UTF-8 글로 적은 형식입니다.

Walk USDZ 안의 model.usda를 메모장으로 읽습니다.

함께 찾기: [UTF-8](01_PC%EC%99%80_Unity.md#utf8) · [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd) · [USDZ](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usdz)

<a id="usdc"></a>

## USDC

USD 레이어를 Crate라는 바이너리 방식으로 저장하는 형식입니다.

이 프로젝트 전용 ExtractTool의 텍스트 검색 대상이 아닙니다.

함께 찾기: [바이너리](01_PC%EC%99%80_Unity.md#binary) · [Project](01_PC%EC%99%80_Unity.md#project) · [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd) · [Crate](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#crate)

<a id="usd-extension"></a>

## .usd 확장자

USDA 또는 USDC 방식의 내용을 담을 수 있는 파일 이름 끝 표지입니다.

항상 바이너리라고 단정할 수 없습니다.

함께 찾기: [바이너리](01_PC%EC%99%80_Unity.md#binary) · [USDA](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usda) · [USDC](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usdc)

<a id="usdz"></a>

## USDZ

USD와 이미지 등 관련 자료를 ZIP 기반 규칙으로 묶은 패키지 형식입니다.

USDA가 반드시 들어 있지는 않습니다. 일반 ZIP을 이름만 바꿔 만들지 않습니다.

함께 찾기: [Package](01_PC%EC%99%80_Unity.md#package) · [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd) · [USDA](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usda) · [ZIP](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#zip)

<a id="zip"></a>

## ZIP

여러 파일과 각 파일의 정보를 한 파일에 담는 규격입니다.

일반 ZIP은 압축할 수 있으나 USDZ는 비압축 등 추가 제약이 있습니다.

함께 찾기: [USDZ](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usdz)

<a id="crate"></a>

## Crate

USDC가 사용하는 USD 바이너리 저장 형식 이름입니다.

사람이 직접 글처럼 읽는 USDA와 구분합니다.

함께 찾기: [바이너리](01_PC%EC%99%80_Unity.md#binary) · [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd) · [USDA](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usda) · [USDC](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usdc)

<a id="prim"></a>

## Prim

USD 장면에서 경로를 갖고 속성·관계를 담는 기본 요소입니다.

메시·재질·변환 묶음 등이 Prim으로 표현됩니다.

함께 찾기: [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd)

<a id="prim-path"></a>

## Prim Path

USD 요소를 찾는 계층 주소입니다.

/StudyRoot/Ball은 StudyRoot 아래 Ball입니다.

함께 찾기: [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd)

<a id="attribute"></a>

## Attribute · 속성

대상의 특정 성질을 이름과 값으로 기록한 항목입니다.

USD radius=0.5는 반지름 속성입니다. C#의 [SerializeField] 속성 표기와 문맥이 다릅니다.

함께 찾기: [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd) · [C#](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#csharp) · [SerializeField](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#serializefield) · [radius](09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#radius)

<a id="relationship"></a>

## Relationship

USD에서 다른 요소를 가리키는 관계 정보입니다.

어떤 뼈대 등을 사용할지 연결할 수 있습니다.

함께 찾기: [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd)

<a id="schema"></a>

## Schema · 스키마

특정 종류의 데이터에 어떤 속성과 의미가 있는지 정한 규칙입니다.

Mesh와 Skeleton은 서로 다른 규칙을 씁니다.

함께 찾기: [데이터](01_PC%EC%99%80_Unity.md#data) · [Mesh](02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#mesh) · [Skeleton](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#skeleton)

<a id="usd-layer"></a>

## USD Layer

장면에 대한 기록을 담는 단위입니다.

원본 모양과 장면별 배치 변경을 다른 레이어에 둘 수 있습니다.

<a id="stage"></a>

## Stage

레이어와 참조를 해석해 하나의 구성으로 보여 주는 USD 장면 전체입니다.

파일 하나를 단순 복사한 결과와 다를 수 있습니다.

함께 찾기: [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd)

<a id="composition"></a>

## Composition · USD 합성

여러 장면 기록을 정해진 규칙과 우선순위로 조합하는 과정입니다.

원본 모델을 공유하면서 별도 위치 변경을 적용합니다.

함께 찾기: [Priority](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#priority)

<a id="usd-reference"></a>

## USD Reference

다른 USD 요소의 내용을 현재 장면 구성에 가져오는 방식입니다.

일반적인 참조보다 구체적인 USD 합성 기능입니다.

함께 찾기: [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd) · [Composition](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#composition)

<a id="sublayer"></a>

## Sublayer

다른 레이어를 현재 레이어 묶음에 포함하는 방식입니다.

여러 기록의 강도와 우선순위를 함께 해석합니다.

함께 찾기: [Priority](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#priority)

<a id="payload"></a>

## Payload

필요한 내용을 선택적으로 불러오도록 제어할 수 있는 USD 구성 방식입니다.

큰 장면에서 모든 상세 자료를 늘 읽지 않도록 할 수 있습니다.

함께 찾기: [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd)

<a id="variant"></a>

## Variant · USD Variant

하나의 대상에 준비한 여러 구성 중 선택하는 변형입니다.

다른 의상 구성 같은 선택지를 표현할 수 있습니다.

<a id="metadata"></a>

## Metadata · 메타데이터

데이터 자체를 어떻게 해석할지 설명하는 부속 정보입니다.

단위·위쪽 축·시간 눈금 설정 등이 예입니다.

함께 찾기: [데이터](01_PC%EC%99%80_Unity.md#data)

<a id="upaxis"></a>

## upAxis · Y-up

USD에서 위로 간주할 축의 설정입니다. Y-up은 Y축이 위라는 뜻입니다.

이 값 하나만으로 모든 좌표계 방향이 같다고 할 수는 없습니다.

함께 찾기: [좌표계](02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#coordinate-system) · [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd)

<a id="meters"></a>

## metersPerUnit

USD 길이 1단위를 몇 미터로 해석할지 적는 값입니다.

1이면 1단위=1m입니다.

함께 찾기: [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd)

<a id="defaultprim"></a>

## defaultPrim

레이어를 외부에서 참조할 때 기본 대상으로 사용할 최상위 Prim 지정입니다.

현재 Walk는 root를 지정합니다.

함께 찾기: [Prim](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#prim)

<a id="xform"></a>

## Xform

USD에서 변환을 가질 수 있고 자식을 묶는 데 쓰는 요소 종류입니다.

예제의 StudyRoot가 Xform입니다.

함께 찾기: [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd)

<a id="usd-def"></a>

## def

USDA에서 요소를 정의하는 문법 표기입니다.

def Sphere "Ball"은 Ball이라는 구 요소를 정의합니다.

함께 찾기: [Sphere](02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#sphere) · [USDA](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usda)

<a id="skelroot"></a>

## SkelRoot

USD의 뼈 기반 모델을 포함하는 범위에 쓰는 요소 종류입니다.

Walk 원본은 root라는 SkelRoot를 가집니다.

함께 찾기: [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd)

<a id="skelanimation"></a>

## SkelAnimation

USD에서 뼈의 시간별 변환 등을 담는 애니메이션 요소 종류입니다.

전용 변환기는 이 텍스트 블록을 찾습니다.

함께 찾기: [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd) · [Animation](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#animation)

<a id="joints"></a>

## joints

USD 뼈 애니메이션 등이 참조하는 관절 이름·경로 목록입니다.

Root/Hips와 같은 부모 경로도 중요합니다.

함께 찾기: [Root](01_PC%EC%99%80_Unity.md#root) · [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd) · [Animation](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#animation)

<a id="timesamples"></a>

## timeSamples

시간 코드별 속성값을 기록한 표입니다.

회전·이동·크기 값이 언제 달라지는지 적습니다.

함께 찾기: [시간 코드](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#timecode)

<a id="timecode"></a>

## 시간 코드 · Time Code

USD 안에서 시간 위치를 나타내는 수치 눈금입니다.

30눈금이 몇 초인지는 timeCodesPerSecond를 봅니다.

함께 찾기: [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd) · [timeCodesPerSecond](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#timecodespersecond)

<a id="timecodespersecond"></a>

## timeCodesPerSecond · TimeCodesPerSecond

1초에 해당하는 USD 시간 코드 수입니다.

(32-2)/30=1초입니다.

함께 찾기: [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd) · [시간 코드](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#timecode)

<a id="framespersecond"></a>

## framesPerSecond

USD 자료의 의도된 초당 프레임 수 메타데이터입니다.

게임이 실제 출력하는 FPS와 같을 필요가 없습니다.

함께 찾기: [데이터](01_PC%EC%99%80_Unity.md#data) · [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd) · [Metadata](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#metadata) · [Frame](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#frame) · [FPS](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#fps)

<a id="starttime"></a>

## startTimeCode

USD 재생 구간의 시작 시간 코드입니다.

현재 Walk는 2입니다.

함께 찾기: [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd) · [시간 코드](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#timecode)

<a id="endtime"></a>

## endTimeCode

USD 재생 구간의 끝 시간 코드입니다.

현재 Walk는 84입니다.

함께 찾기: [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd) · [시간 코드](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#timecode)

<a id="token"></a>

## token

USD에서 이름·분류 등에 쓰는 문자열 자료형입니다.

token[]은 이름 여러 개의 배열입니다.

함께 찾기: [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd) · [자료형](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#type) · [string](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#string)

<a id="uniform"></a>

## uniform

USD 속성이 시간에 따라 변하지 않는다는 분류 표기입니다.

애니메이션 관절 목록에 사용됩니다.

함께 찾기: [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd) · [Animation](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#animation)

<a id="quatf"></a>

## quatf

USD의 float 정밀도 쿼터니언 자료형입니다.

USDA 표기의 실수부·벡터부 순서를 Unity 생성자 순서와 구분합니다.

함께 찾기: [Unity](01_PC%EC%99%80_Unity.md#unity) · [Quaternion](02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#quaternion) · [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd) · [USDA](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usda) · [자료형](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#type) · [float](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#float) · [정밀도](08_API%EC%99%80_%EC%B6%94%EA%B0%80%EC%84%A4%EC%A0%95.md#shader-precision)

<a id="float3"></a>

## float3

소수 성분 세 개의 USD 자료형입니다.

translations와 scales 배열에 쓰입니다.

함께 찾기: [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd) · [translations](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#translations) · [scales](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#scales) · [자료형](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#type)

<a id="rotations"></a>

## rotations

뼈 등의 회전 값 목록입니다.

순서가 joints 목록과 맞아야 합니다.

함께 찾기: [joints](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#joints)

<a id="translations"></a>

## translations

뼈 등의 이동 값 목록입니다.

회전값이 아니라 위치 변화입니다.

<a id="scales"></a>

## scales

뼈 등의 축별 크기 배율 목록입니다.

입력 좌표와 단위 가정을 함께 봅니다.

<a id="usdpreview"></a>

## UsdPreviewSurface

USD에서 표면 색·거칠기·금속성 등을 전달하는 공통 표면 규칙입니다.

URP/Lit과 채널·계산이 자동으로 같아지는 것은 아닙니다.

함께 찾기: [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd) · [Metallic](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#metallic) · [Roughness](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#roughness) · [URP](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#urp) · [Lit](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#lit)

<a id="usdcat"></a>

## usdcat

USD 내용을 읽거나 텍스트·바이너리 형식 사이로 내보내는 OpenUSD 도구입니다.

현재 읽기 실습에는 설치하지 않아도 됩니다.

함께 찾기: [바이너리](01_PC%EC%99%80_Unity.md#binary) · [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd) · [OpenUSD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#openusd)

<a id="usd-importer"></a>

## USD Importer

USD 장면 기록을 Unity가 사용할 에셋 등으로 읽는 패키지입니다.

프로젝트의 전용 ExtractTool과 지원 범위가 다릅니다.

함께 찾기: [Unity](01_PC%EC%99%80_Unity.md#unity) · [Project](01_PC%EC%99%80_Unity.md#project) · [Package](01_PC%EC%99%80_Unity.md#package) · [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd)

<a id="fbx"></a>

## FBX

메시·뼈·애니메이션 등을 프로그램 사이에 전달하는 3D 파일 형식입니다.

텍스처가 항상 내장되는 것은 아닙니다.

함께 찾기: [파일 형식](01_PC%EC%99%80_Unity.md#format) · [프로그램](01_PC%EC%99%80_Unity.md#program) · [3D](02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#3d) · [Texture](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#texture) · [Animation](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#animation)

<a id="fbx-exporter"></a>

## FBX Exporter

Unity의 물체 등을 FBX 파일로 기록하는 패키지입니다.

내보내기와 다시 임포트한 뒤의 외관 검증은 별도입니다.

함께 찾기: [Unity](01_PC%EC%99%80_Unity.md#unity) · [Import](01_PC%EC%99%80_Unity.md#import) · [Export](01_PC%EC%99%80_Unity.md#export) · [Package](01_PC%EC%99%80_Unity.md#package) · [FBX](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#fbx)

<a id="png"></a>

## PNG

이미지를 저장하는 파일 형식입니다.

색뿐 아니라 ORM 같은 수치 지도도 저장할 수 있습니다.

함께 찾기: [파일 형식](01_PC%EC%99%80_Unity.md#format) · [ORM](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#orm)

<a id="json"></a>

## JSON

이름과 값·목록을 글로 기록하는 데이터 형식입니다.

manifest.json은 패키지 요청을 기록합니다.

함께 찾기: [데이터](01_PC%EC%99%80_Unity.md#data) · [Package](01_PC%EC%99%80_Unity.md#package) · [manifest.json](01_PC%EC%99%80_Unity.md#manifest)

<a id="yaml"></a>

## YAML

들여쓰기와 이름·값 등으로 데이터를 표현하는 텍스트 형식입니다.

Unity의 텍스트 씬·프리팹 저장 내용을 읽을 때 볼 수 있습니다.

함께 찾기: [데이터](01_PC%EC%99%80_Unity.md#data) · [Unity](01_PC%EC%99%80_Unity.md#unity) · [Prefab](01_PC%EC%99%80_Unity.md#prefab)

<a id="anim"></a>

## .anim

Unity의 독립 AnimationClip 에셋 파일 확장자입니다.

FBX 내부 하위 클립과 별도 파일을 구분합니다.

함께 찾기: [확장자](01_PC%EC%99%80_Unity.md#extension) · [Unity](01_PC%EC%99%80_Unity.md#unity) · [FBX](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#fbx) · [Animation Clip](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#clip)

<a id="mat"></a>

## .mat

Unity Material 에셋 파일 확장자입니다.

사용 셰이더와 값·텍스처 참조가 담깁니다.

함께 찾기: [확장자](01_PC%EC%99%80_Unity.md#extension) · [Unity](01_PC%EC%99%80_Unity.md#unity) · [Texture](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#texture) · [Material](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#material) · [Shader](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#shader)

<a id="controller-file"></a>

## .controller

Animator Controller 에셋의 파일 확장자입니다.

시간별 자세 자체보다 재생 상태와 전환을 담습니다.

함께 찾기: [확장자](01_PC%EC%99%80_Unity.md#extension) · [Animator](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#animator) · [Animator Controller](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#controller)

<a id="scene-file"></a>

## .unity

Unity Scene 에셋의 파일 확장자입니다.

Build Scene 목록에 등록해야 시작 씬으로 사용할 수 있습니다.

함께 찾기: [확장자](01_PC%EC%99%80_Unity.md#extension) · [Unity](01_PC%EC%99%80_Unity.md#unity) · [Scene](01_PC%EC%99%80_Unity.md#scene) · [Build](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#build)

<a id="shader-file"></a>

## .shader

셰이더 정의를 저장한 파일 확장자입니다.

프로젝트의 직접 작성 셰이더를 읽을 때 봅니다.

함께 찾기: [확장자](01_PC%EC%99%80_Unity.md#extension) · [Project](01_PC%EC%99%80_Unity.md#project) · [Shader](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#shader)

<a id="shadergraph-file"></a>

## .shadergraph

Shader Graph의 노드·연결을 저장한 파일 확장자입니다.

그래프 편집기로 열고 Material이 이를 사용합니다.

함께 찾기: [확장자](01_PC%EC%99%80_Unity.md#extension) · [Material](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#material) · [Shader](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#shader) · [Shader Graph](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#shader-graph)

<a id="vfx-file"></a>

## .vfx

Visual Effect Graph 에셋의 확장자입니다.

FloatingDust의 생성·변화·출력 규칙을 담습니다.

함께 찾기: [확장자](01_PC%EC%99%80_Unity.md#extension) · [VFX Graph](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#vfx-graph)

<a id="cs-file"></a>

## .cs

C# 소스 코드 파일의 확장자입니다.

파일이 있어도 컴포넌트가 연결되지 않으면 동작하지 않을 수 있습니다.

함께 찾기: [확장자](01_PC%EC%99%80_Unity.md#extension) · [Component](01_PC%EC%99%80_Unity.md#component) · [C#](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#csharp) · [소스 코드](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#source)

<a id="asset-file"></a>

## .asset

Unity가 여러 종류의 에셋을 저장할 때 쓰는 확장자입니다.

이름 끝만으로 Volume인지 URP 설정인지 확정하지 않습니다.

함께 찾기: [확장자](01_PC%EC%99%80_Unity.md#extension) · [Unity](01_PC%EC%99%80_Unity.md#unity) · [URP](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#urp) · [Volume](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#volume)

<a id="inputactions-file"></a>

## .inputactions

Input System의 액션·입력 연결 설정을 저장하는 파일입니다.

키 입력 의미와 이를 사용하는 게임 코드는 별개입니다.

함께 찾기: [Input System](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#inputsystem)
