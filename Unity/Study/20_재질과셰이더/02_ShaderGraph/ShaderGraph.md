# Shader Graph 연결과 ORM

[전체 주제 목차](../../README.md) · [전체 용어 사전](../../90_용어사전/README.md)

## 점·숫자·선을 읽는 법

[PBR·텍스처·재질 문서](../01_재질/재질과텍스처.md)의 텍스처·채널·재질을 먼저 실습합니다. **노드**는 입력을 받아 계산하고 출력을 내는 상자, **포트**는 노드에 달린 입력·출력 연결점입니다. 오른쪽 출력 포트에서 왼쪽 입력 포트로 드래그합니다. 빈 바탕으로 끌어 놓는 것과 다릅니다.

**Blackboard**는 그래프 밖의 재질에서 바꿀 입력값을 선언하는 목록입니다. **Exposed**는 그 입력을 Material Inspector에 보여 줄지 정하는 설정입니다. **Fragment**는 화면의 표면 색 등을 계산하는 출력 블록 묶음입니다. Base Color·Metallic처럼 역할이 다른 출력에 같은 값을 무작정 꽂지 않습니다.

Shader Graph 창은 공간이 넓습니다. 휠로 확대·축소하고 빈 곳을 마우스 가운데 버튼으로 드래그해 이동합니다. 노드나 출력 블록이 화면 밖에 있을 수 있습니다. Space 검색창에 정확한 노드 이름을 넣어 만듭니다. 연결선을 따라 **입력 숫자 → 계산 → 최종 출력** 순서로 읽습니다.

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

[PBR·텍스처·재질 문서](../01_재질/재질과텍스처.md)의 채널 문제를 직접 이해하는 심화 실습입니다. 새 그래프만 만듭니다.

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
