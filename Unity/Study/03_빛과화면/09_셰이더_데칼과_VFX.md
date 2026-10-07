# 09. 셰이더·데칼·VFX

> 모르는 단어는 [전문 용어 전체 색인](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4_%EC%82%AC%EC%A0%84.md)에서 영문·한글로 찾습니다. 이 장 맨 아래에는 등장 용어의 바로가기 목록이 있습니다.

## 점·숫자·선을 읽는 법

05장의 텍스처·채널·재질을 먼저 실습합니다. **노드**는 입력을 받아 계산하고 출력을 내는 상자, **포트**는 노드에 달린 입력·출력 연결점입니다. 오른쪽 출력 포트에서 왼쪽 입력 포트로 드래그합니다. 빈 바탕으로 끌어 놓는 것과 다릅니다.

**Blackboard**는 그래프 밖의 재질에서 바꿀 입력값을 선언하는 목록입니다. **Exposed**는 그 입력을 Material Inspector에 보여 줄지 정하는 설정입니다. **Fragment**는 화면의 표면 색 등을 계산하는 출력 블록 묶음입니다. Base Color·Metallic처럼 역할이 다른 출력에 같은 값을 무작정 꽂지 않습니다.

Shader Graph 창은 공간이 넓습니다. 휠로 확대·축소하고 빈 곳을 마우스 가운데 버튼으로 드래그해 이동합니다. 노드나 출력 블록이 화면 밖에 있을 수 있습니다. Space 검색창에 정확한 노드 이름을 넣어 만듭니다. 연결선을 따라 **입력 숫자 → 계산 → 최종 출력** 순서로 읽습니다.

**데칼**은 이미 있는 표면에 추가 그림을 투사하는 효과입니다. **입자**는 작은 점·면 등의 반복 요소이며, **VFX**는 Visual Effects, 화면 효과라는 뜻입니다. 이 프로젝트의 먼지는 입자를 여러 개 만들고 각자의 위치·수명·투명도를 바꿔 표현합니다. Spawn은 생성, Initialize는 초기값 지정, Update는 시간 변화, Output은 그리기를 맡습니다.

## 데칼 첫 배치를 위한 출발값

아래 데칼 실습에서 새 Plane은 Position `(0,0,0)`, Rotation `(0,0,0)`으로 둡니다. Projector는 Position `(0,1,0)`, Rotation `(90,0,0)`, Width·Height `2`, Projection Depth `3`에서 시작합니다. Scene의 투사 상자가 Plane을 통과하고 앞 방향이 아래를 향하는지 확인합니다. 기존 바닥과 겹치면 두 대상을 X=4로 함께 옮깁니다. 겹친 면의 깜박임을 재질 문제로 혼동하지 않기 위해서입니다.

실제 로고 방향은 원본 그래프·재질에도 영향을 받으므로 이 수치를 완성 구도의 정답으로 외우지 않습니다. 먼저 범위 안 불투명 Plane에 보이는지 확인한 뒤 위치와 회전을 조절합니다.

## Shader Graph는 계산을 선으로 연결한다

노드는 계산기 한 개, 선은 계산 결과가 이동하는 길입니다. 텍스처의 색을 읽고 두 색을 섞어 Base Color로 보내면 표면 색이 됩니다. 노드가 파일에 있다는 사실만으로 최종 출력에 영향을 준다고 판단하지 않습니다. **끝의 출력까지 연결된 선**을 봐야 합니다.

| 노드 | 하는 일 | 익숙한 예 |
|---|---|---|
| Sample Texture 2D | UV 위치의 픽셀 읽기 | 지도에서 색 찾기 |
| Split / Combine | RGBA를 나누기·묶기 | 칸별 내용 분리·포장 |
| Multiply | 두 값을 곱하기 | 세기를 2배로 |
| Add | 두 값을 더하기 | 기준 밝기 더하기 |
| One Minus | `1 - 값` | 거칠기를 매끈함으로 |
| Lerp | A와 B를 비율로 섞기 | 빨강과 파랑 사이 색 |
| Fresnel | 시선과 표면 방향 관계에 따른 가장자리 효과 | 구의 가장자리 강조 |
| Time | 시간에 따라 증가하는 값 | 움직이는 무늬의 시간 입력 |
| Tiling And Offset | UV 반복·이동 | 흐르는 무늬 |
| Voronoi / Checkerboard | 절차적 무늬 생성 | 얼룩·체커 패턴 |

`Lerp(A,B,t) = A(1-t) + Bt`입니다. A=0, B=10, t=0.3이면 3입니다. 프레넬 효과는 물리적인 반사 개념과 관련 있지만, 그래프의 Fresnel 노드만으로 완전한 물리 반사가 구현되는 것은 아닙니다.

## 실제 그래프 위치

모두 `Assets/VARCO_URP/08.Shaders` 아래에 있습니다.

| 파일 | 확인한 구성·노출 값 |
|---|---|
| `URPCustom/URP_PaintColor.shadergraph` | Base Color, Normal, Normal Intensity, Coat Mask; Fresnel·Voronoi 등 |
| `URPCustom/URP_CarbonCoat.shadergraph` | Carbon, Carbon Color, Normal, Coat Mask; 텍스처·Lerp 등 |
| `URPCustom/URP_Gradient.shadergraph` | Base Color, Coat Mask; Gradient·Fresnel 등 |
| `URPLight/UVC_LightFlickering.shadergraph` | Speed, Color; Time·Checkerboard 등 |
| `URPDecal/UVC_DecalAlphaEm.shadergraph` | Alpha, Color, Speed, Boolean, `Emmisive Intensity` |
| `URPDecal/UVC_DecalBlackEm.shadergraph` | Alpha, Color, Speed, `Emmisive Intensity` |
| `URPReflections/UVC_Reflections.ShaderGraph` | Reflection Amount, 텍스처, 전역 `_PlanarReflectionTexture` |

`Emmisive`는 실제 속성 이름의 철자입니다. 검색할 때 `Emissive`로 고쳐 쓰면 찾기 어려울 수 있습니다.

## 실습 A: 기존 그래프 읽기

1. Project에서 `URP_PaintColor.shadergraph`를 더블클릭합니다.
2. Blackboard에서 Base Color·Normal 같은 속성을 찾습니다.
3. 속성 노드에서 시작해 선을 따라 출력의 Base Color·Normal까지 갑니다.
4. `Lerp`가 보이면 A·B·T에 무엇이 들어오는지 적습니다.
5. 저장하지 않고 닫습니다. 우선 읽기 연습입니다.
6. 실제 표면 비교는 `02.Materials/Lab_Custom_PaintColor 1.mat`을 복제하고 `_Study/Materials`로 옮겨 사용합니다.

## 실습 B: ORM을 올바르게 읽는 작은 그래프

05장의 채널 문제를 직접 이해하는 심화 실습입니다. 새 그래프만 만듭니다.

1. `_Study/Materials`에서 우클릭 → `Create > Shader Graph > URP > Lit Shader Graph`. 이름 `Study_ORM_Lit`.
2. 더블클릭해 열고 Blackboard의 `+`로 Texture2D 속성 `BaseTexture`, `ORMTexture`를 만듭니다. 필요하면 Exposed를 켭니다.
3. BaseTexture 속성을 작업 영역으로 드래그합니다. 빈 공간에서 Space → `Sample Texture 2D`를 만들고 속성을 Texture 입력에 연결합니다.
4. 그 노드의 RGB 출력을 Fragment의 Base Color에 연결합니다.
5. ORMTexture도 Sample Texture 2D로 읽습니다. RGBA 출력을 `Split` 입력에 연결합니다.
6. Split의 **B → Metallic**, **R → Ambient Occlusion**에 연결합니다.
7. Split의 G를 `One Minus`에 연결한 뒤 **출력 → Smoothness**에 연결합니다. 출력 블록이 없으면 Fragment의 블록 추가 메뉴에서 해당 블록을 추가합니다.
8. `Save Asset`을 누릅니다.
9. Project에서 그래프를 우클릭 → `Create > Material`. 만들어진 재질의 BaseTexture에 Base Color, ORMTexture에 원본 ORM을 넣습니다.
10. ORM 텍스처의 sRGB가 꺼졌는지 확인하고 복사 씬 로봇에 이 재질을 연결합니다.

이 최소 실습은 Normal 연결을 생략했습니다. 비교할 때 기존 재질도 Normal 영향을 끄거나, 추가 Texture2D와 Sample Texture 2D의 Normal 모드를 사용해 Fragment Normal에 연결합니다. 다른 조건이 같아야 채널 차이를 비교할 수 있습니다.

## 데칼: 표면에 그림을 투사한다

**Decal Projector**는 범위 안의 표면에 스티커처럼 이미지를 투사합니다. 벽 문양·바닥 로고·흔적에 쓸 수 있습니다. 일반 Mesh Renderer에 바르는 재질과 Decal 전용 재질은 구분합니다. [Decal 설명](https://docs.unity3d.com/6000.0/Documentation/Manual/urp/renderer-feature-decal.html).

1. PC 품질과 `PC_Renderer`의 Decal 기능이 켜졌는지 확인합니다. Mobile Renderer에는 저장된 Decal 기능이 없습니다.
2. `_Study/Materials`에 기존 `URPDecal/UVC_DecalBlackEm.mat`을 복제합니다.
3. 메뉴 `GameObject > Rendering > URP Decal Projector`를 누릅니다.
4. 새 오브젝트의 Inspector > Decal Projector > Material에 복제한 `.mat`을 드래그합니다.
5. 불투명 URP/Lit Plane을 하나 만들고, Projector 상자가 그 표면과 겹치도록 위치·회전을 조절합니다. Scene의 투사 방향 표시를 보고 맞춥니다.
6. Width·Height·Projection Depth를 조절해 로고 범위를 맞춥니다. Fade Factor도 확인합니다.
7. Game 탭에서 확인합니다. 투명 Shadow Matte 바닥은 일반 불투명 수신체와 조건이 다르므로 첫 실습에서는 Lit Plane을 씁니다.

`Lab_DecalScaler.cs`의 클래스명은 `DecalScaler`입니다. 파일명과 클래스명이 다르며 현재 씬에 연결된 기록도 없습니다. 처음에는 이 스크립트를 붙이지 않고 Projector 크기를 직접 조절합니다. [Projector 속성 설명](https://docs.unity3d.com/6000.0/Documentation/Manual/urp/renderer-feature-decal-projector-reference.html).

## VFX: 작은 입자를 많이 그린다

`FloatingDust.vfx`는 화면에 먼지를 띄우는 Visual Effect Graph입니다. 기본 흐름은 다음과 같습니다.

```text
Spawn: 몇 개 만들까 → Initialize: 처음 위치·크기·수명 → Update: 시간마다 변화 → Output: 어떻게 그릴까
```

1. `Study_Lab`의 `FloatingDust`를 선택합니다.
2. Inspector의 Visual Effect에서 연결된 에셋이 `FloatingDust`인지 확인합니다.
3. 노출된 `Spawn Rate`, `Box Size`, `Min Dust Size`, `Max Dust Size`를 기록합니다.
4. Spawn Rate만 낮춰 비교합니다. 기존 입자는 수명이 끝날 때까지 남을 수 있습니다. 즉시 사라지지 않는다고 실패로 판단하지 않습니다.
5. `_Study`로 VFX 에셋을 복제해 더블클릭하면 내부 그래프를 공부할 수 있습니다. 원본 그래프의 Capacity 저장값은 500입니다.

Capacity는 담을 수 있는 입자 수, Spawn Rate는 만드는 속도입니다. 단순히 `동시에 살아 있는 수 ≈ 초당 생성 수 × 평균 수명`으로 생각하되, 그래프의 추가 생성·제거 규칙에 따라 달라집니다. 먼지를 키우면 화면에 겹쳐 그리는 **Overdraw**도 늘 수 있습니다. [VFX Context 설명](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@17.0/manual/Contexts.html).

## HLSL 파일을 읽을 때

`URPC#/UVC_Color Shadow Matte.shader`는 투명 그림자 수신 표면입니다. ShadowCaster 패스가 없어 자체 그림자를 만들지 않습니다. `_alphaClip`이라는 이름이 있어도 실제 코드에서는 픽셀을 버리는 `clip()` 대신 색 합성 경로를 고릅니다. 이름보다 코드를 봅니다.

`UVC_Skybox.shader`는 Cubemap·Exposure·Speed를 노출합니다. `_Color`는 선언되어 있지만 최종 색 계산에서 사용되지 않습니다. Color 값을 바꿔도 기대한 변화가 없을 수 있는 구체적인 사례입니다. 이 문서 작성 중 셰이더를 수정하거나 컴파일하지 않았습니다.

**확인 질문:** 그래프에 노드가 있으면 무조건 화면에 반영되는가? Spawn Rate를 0으로 하면 모든 입자가 같은 순간에 지워지는가?

**답:** 출력까지 연결되어야 합니다. 새 생성이 멈추는 것과 이미 생성된 입자가 사라지는 것은 다릅니다.

## 이 장의 용어 찾기

모르는 말은 아래 링크 또는 [전체 용어 색인](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4_%EC%82%AC%EC%A0%84.md)에서 찾습니다. 영문 UI 이름도 검색할 수 있습니다.

- PC와·Unity: [GameObject](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#gameobject) · [Inspector](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#inspector) · [Project](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#project)

- 수학과·모델: [2D](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#2d) · [Lerp](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#lerp) · [Mesh](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#mesh) · [Normal](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#normal) · [Plane](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#plane) · [Sample](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#sample) · [UV](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#uv)

- USD와·파일형식: [.cs](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#cs-file) · [.mat](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#mat) · [.shader](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#shader-file) · [.shadergraph](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#shadergraph-file) · [.unity](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#scene-file) · [.vfx](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#vfx-file)

- 표면과·렌더링: [Alpha](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#alpha) · [Ambient Occlusion](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#ao) · [Base Color](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#basecolor) · [Cubemap](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#cubemap) · [Emission](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#emission) · [Lit](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#lit) · [Mask](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#mask) · [Mesh Renderer](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#mesh-renderer) · [Metallic](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#metallic) · [Offset](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#offset) · [Opaque](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#opaque) · [ORM](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#orm) · [Renderer](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#renderer) · [Rendering](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#rendering) · [RGB](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#rgb) · [RGBA](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#rgba) · [Roughness](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#roughness) · [Shader](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#shader) · [Shadow Matte](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#shadow-matte) · [ShadowCaster](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#shadowcaster) · [Smoothness](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#smoothness) · [sRGB](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#srgb) · [Texture](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#texture) · [Texture2D](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#texture2d) · [Tiling](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#tiling) · [URP](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#urp) · [투영](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#projection)

- 효과와·움직임과·UI: [Blackboard](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#blackboard) · [Capacity](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#capacity) · [Checkerboard](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#checkerboard) · [Coat Mask](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#coat-mask) · [Combine](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#combine) · [Decal](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#decal) · [Decal Projector](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#decal-projector) · [Exposed](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#exposed) · [Exposure](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#exposure) · [Fade](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#fade) · [Fragment](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#fragment) · [Fresnel](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#fresnel) · [Gradient](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#gradient) · [Initialize](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#initialize) · [Multiply](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#multiply) · [One Minus](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#one-minus) · [Sample Texture 2D](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#sample-texture) · [Shader Graph](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#shader-graph) · [Spawn](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#spawn) · [Spawn Rate](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#spawn-rate) · [Split](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#split) · [VFX](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#vfx) · [VFX Graph](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#vfx-graph) · [Voronoi](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#voronoi)

- 코드와·통신과·검증: [bool](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#bool) · [class](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#class) · [Overdraw](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#overdraw) · [컴파일](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#compile)

- 화면의·속성과·메뉴: [Box Size](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#box-size) · [Emmisive Intensity](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#emmisive) · [Fade Factor](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#fade-factor) · [Intensity](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#intensity) · [Max Dust Size](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#max-dust-size) · [Min Dust Size](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#min-dust-size) · [Normal Intensity](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#normal-intensity) · [Projection Depth](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#projection-depth) · [Reflection Amount](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#reflection-amount) · [Speed](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#speed)

- API와·추가설정: [_PlanarReflectionTexture](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/08_API%EC%99%80_%EC%B6%94%EA%B0%80%EC%84%A4%EC%A0%95.md#planar-texture) · [clip()](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/08_API%EC%99%80_%EC%B6%94%EA%B0%80%EC%84%A4%EC%A0%95.md#clip-function) · [DecalScaler](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/08_API%EC%99%80_%EC%B6%94%EA%B0%80%EC%84%A4%EC%A0%95.md#decal-scaler) · [HLSL](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/08_API%EC%99%80_%EC%B6%94%EA%B0%80%EC%84%A4%EC%A0%95.md#hlsl)

- 보충·기초와·도구이름: [_alphaClip](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#alpha-clip-name) · [_Color](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#color-property) · [BaseTexture](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#base-texture) · [ORMTexture](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#orm-texture) · [Save Asset](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#save-asset)

- 프로젝트·코드·식별자: [Lab_DecalScaler](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/10_%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8_%EC%BD%94%EB%93%9C_%EC%8B%9D%EB%B3%84%EC%9E%90.md#script-lab_decalscaler) · [UVC_Reflections](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/10_%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8_%EC%BD%94%EB%93%9C_%EC%8B%9D%EB%B3%84%EC%9E%90.md#script-uvc_reflections)

<!-- study-navigation -->
[이전](08_Volume_%ED%9B%84%EC%B2%98%EB%A6%AC.md) · [목차](../README.md) · [다음](../04_%EC%9B%80%EC%A7%81%EC%9E%84/10_%EB%A6%AC%EA%B9%85_Avatar%EC%99%80_%EC%95%A0%EB%8B%88%EB%A9%94%EC%9D%B4%EC%85%98.md)
