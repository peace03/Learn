# 06. URP·카메라·품질

> 모르는 단어는 [전문 용어 전체 색인](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4_%EC%82%AC%EC%A0%84.md)에서 영문·한글로 찾습니다. 이 장 맨 아래에는 등장 용어의 바로가기 목록이 있습니다.

## 카메라는 사진기가 맡는 두 일을 숫자로 한다

준비 C의 투영·래스터화·깊이 버퍼를 먼저 읽습니다. 카메라의 **Transform**은 어디에서 어디를 볼지, **FOV**는 어느 각도까지 담을지 정합니다. 카메라와 가까운 물체와 먼 물체가 함께 있는 장면에서 카메라를 옮기는 것과 FOV를 바꾸는 것은 다른 결과입니다. 물체 자체의 크기가 바뀌지 않아도 화면의 크기는 바뀝니다.

렌더 파이프라인은 물체를 고르고 그리기 작업을 배분합니다. **CPU**는 주로 규칙·준비 작업, **GPU**는 많은 정점과 픽셀의 계산을 나누어 처리합니다. **Renderer Feature**는 그림자·데칼 같은 추가 렌더 작업을 Renderer에 넣는 기능입니다. 파일이 있어도 현재 카메라가 쓰는 Renderer에 연결되지 않으면 효과가 없을 수 있습니다.

**SSAO**는 현재 카메라의 깊이·표면 방향 등을 이용해 주변이 막힌 정도를 근사합니다. **Screen Space Shadows**는 화면 공간에 그림자 결과를 준비해 사용하는 기능입니다. 둘 다 화면을 활용하지만 같은 효과가 아닙니다. **Screen Space**는 3D 방 전체의 주소가 아니라 화면 위 위치를 기준으로 하는 표현입니다.

안티앨리어싱도 구분합니다. **MSAA**는 픽셀 경계의 여러 샘플을 활용하고, **FXAA**는 그려진 화면의 경계를 처리하며, **TAA**는 이전 프레임 정보도 사용합니다. 이 프로젝트의 저장된 MSAA=1은 추가 다중 샘플을 사용하지 않는 값입니다. 세 방식이 모두 현재 켜졌다는 뜻은 아닙니다.

## 렌더링은 3D를 2D 그림으로 만드는 계산이다

카메라는 어느 쪽을 볼지 정합니다. 렌더 파이프라인은 어떤 물체를 어떤 순서로, 어떤 빛 계산을 써서 그릴지 정합니다. 이 프로젝트는 **Universal Render Pipeline, URP**를 사용합니다.

한 프레임을 단순하게 풀면 다음과 같습니다.

```text
카메라에 필요한 물체 고르기 → 그림자 준비 → 표면 그리기 → 투명 효과 → 후처리 → 화면
```

실제 순서는 Renderer·기능·렌더링 경로에 따라 추가 단계가 생깁니다. **Render Pass**는 그 과정의 작업 한 단계입니다. **Render Graph**는 필요한 작업과 임시 자원의 관계를 표현하고 관리하는 체계입니다. 그래프를 사용한다고 모든 효과가 저절로 빨라지는 것은 아닙니다.

## 헷갈리는 설정 세 개

| 이름 | 역할 | 현재 프로젝트 |
|---|---|---|
| URP Asset | 화면 크기 비율·그림자·HDR 등 전체 렌더 설정 | `PC_RPAsset`, `Mobile_RPAsset` |
| Renderer Data | 렌더링 방식과 추가 기능 구성 | `PC_Renderer`, `Mobile_Renderer` |
| Volume Profile | Bloom·색 보정 같은 후처리 값 | `Lab_Studio` 등 |

연결 흐름은 `Graphics 기본값 또는 Quality별 설정 → URP Asset → Renderer Data`입니다. Quality에 별도 URP Asset이 있으면 그 설정을 먼저 봅니다. 카메라가 특정 Renderer를 선택할 수도 있습니다.

## 저장된 PC·Mobile 차이

경로: `Assets/VARCO_URP/07.Settings/URP Quality`.

| 항목 | PC | Mobile |
|---|---|---|
| Rendering Path | Forward+ | Forward |
| Render Scale | 1.0 | 0.8 |
| Depth Texture | 켬 | 끔 |
| Opaque Texture | 켬 | 끔 |
| HDR | 켬 | 켬 |
| MSAA | 1, 사실상 다중 샘플 없음 | 1 |
| Main Light Shadowmap Resolution | 8192 | 1024 |
| Additional Lights Shadowmap Resolution | 8192 | 2048 |
| Renderer Features | SSAO, Screen Space Shadows, Decal | 없음 |

Forward는 대체로 물체를 그리며 빛을 계산합니다. Forward+는 화면 공간 등을 구역으로 나눠 각 구역에 관련된 빛을 찾는 방식으로 많은 광원 처리를 돕습니다. 모든 장면에서 Forward+가 더 빠른 것은 아닙니다. 저장값 `m_RenderingMode: 2`는 현재 패키지의 enum에서 Forward+입니다.

**Depth Texture**는 카메라에서 표면까지의 깊이 정보, **Opaque Texture**는 불투명 물체를 그린 화면 사본입니다. 기능이 요구할 때 유용하지만 생성 비용과 메모리가 듭니다.

## 카메라의 주요 값

| 속성 | 의미 | 너무 크거나 작을 때 |
|---|---|---|
| Field of View, FOV | 보이는 각도 | 넓으면 주변이 많이 보이고 원근이 과장됨 |
| Near / Far Clipping Plane | 그릴 거리 범위 | Near가 크면 가까운 물체가 잘림 |
| Culling Mask | 그릴 Layer 선택 | 제외된 Layer의 물체는 안 보임 |
| Perspective | 원근 투영 | 먼 물체가 작아짐 |
| Orthographic | 평행 투영 | 거리에 따른 크기 변화가 없음 |
| Post Processing | 후처리 사용 | Volume이 있어도 이 설정을 확인해야 함 |

Layer는 처리 대상을 묶는 번호입니다. Rendering Layer는 조명·데칼 등의 영향을 구분하는 별도 체계입니다. 이름이 비슷해도 Culling Mask와 같은 설정이 아닙니다.

## 실습: 내 화면의 설정 추적

1. `Edit > Project Settings > Graphics`에서 기본 Render Pipeline Asset을 찾습니다. 프로젝트는 `PC_RPAsset`을 참조합니다.
2. `Quality`에서 선택된 품질과 Render Pipeline Asset을 확인합니다. 저장된 현재 품질은 PC입니다.
3. Project에서 `PC_RPAsset`을 클릭합니다. Inspector의 Renderer 목록에서 `PC_Renderer`를 찾습니다.
4. `PC_Renderer`를 클릭하고 Renderer Features 세 개를 읽습니다. 이 단계에서는 값을 바꾸지 않습니다.
5. Hierarchy > `Main Camera` > Camera에서 Rendering·Environment 관련 접힌 항목을 펼칩니다. Renderer는 저장 상태에서 기본값 사용, Post Processing은 켜져 있습니다.
6. 복사 씬에서 FOV만 조금 바꾸고 Game 화면을 봅니다. 물체 Transform이 바뀌지 않아도 구도가 달라집니다.
7. 변경 전 값을 다시 입력합니다.

Render Scale을 비교하려면 `PC_RPAsset`을 `_Study`로 복제하고 Renderer 참조를 확인한 뒤 해당 Quality의 URP Asset 슬롯에 복사본을 연결합니다. 이 연결은 프로젝트 전체 설정이므로 원래 참조를 기록하고 실습 후 복구합니다. 씬을 복제하는 것만으로 Quality는 분리되지 않습니다.

## 픽셀 수의 원리

가로·세로를 모두 0.8배로 그리면 픽셀 수는 `0.8 × 0.8 = 0.64`, 약 64%입니다. 하지만 CPU 작업·그림자·최종 확대 비용까지 모두 64%가 되는 것은 아닙니다.

**확인 질문:** Mobile에서 데칼이 사라지면 무엇을 볼까? FOV를 줄이는 것과 물체를 앞으로 옮기는 것은 같은가?

**답:** 사용 중인 Renderer의 Decal 기능부터 봅니다. 두 동작은 원근 관계와 다른 물체의 구도에 서로 다른 영향을 줍니다.

원리 참고: [URP 기초](https://docs.unity3d.com/6000.0/Documentation/Manual/urp/urp-concepts.html). 수치와 연결은 로컬 설정 파일 기준입니다.

## 이 장의 용어 찾기

모르는 말은 아래 링크 또는 [전체 용어 색인](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4_%EC%82%AC%EC%A0%84.md)에서 찾습니다. 영문 UI 이름도 검색할 수 있습니다.

- PC와·Unity: [Hierarchy](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#hierarchy) · [Inspector](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#inspector) · [Layer](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#layer) · [Package](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#package) · [Project](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#project) · [Project Settings](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#project-settings) · [Rendering Layer](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#rendering-layer) · [Transform](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#transform) · [경로](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#path)

- 수학과·모델: [2D](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#2d) · [3D](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#3d) · [Plane](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#plane)

- 표면과·렌더링: [Anti-aliasing](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#antialias) · [Clipping Plane](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#clipping-plane) · [Culling](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#culling) · [Culling Mask](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#culling-mask) · [Depth Buffer](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#depth-buffer) · [Depth Texture](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#depth-texture) · [Far](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#far) · [Field of View](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#fov) · [Forward](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#forward) · [Forward+](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#forwardplus) · [FXAA](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#fxaa) · [HDR](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#hdr) · [Mask](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#mask) · [MSAA](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#msaa) · [Near](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#near) · [Opaque](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#opaque) · [Opaque Texture](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#opaque-texture) · [Orthographic](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#orthographic) · [Perspective](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#perspective) · [Rasterization](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#rasterization) · [Render Graph](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#render-graph) · [Render Pass](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#render-pass) · [Render Pipeline](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#pipeline) · [Render Scale](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#render-scale) · [Renderer](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#renderer) · [Renderer Data](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#renderer-data) · [Renderer Feature](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#renderer-feature) · [Rendering](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#rendering) · [Resolution](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#resolution) · [Screen Space](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#screen-space) · [Screen Space Shadows](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#screen-shadows) · [SSAO](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#ssao) · [TAA](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#taa) · [Texture](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#texture) · [URP](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#urp) · [URP Asset](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#urp-asset)

- 효과와·움직임과·UI: [Bloom](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#bloom) · [Decal](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#decal) · [Post Processing](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#postprocessing) · [Volume](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#volume) · [Volume Profile](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#profile)

- 코드와·통신과·검증: [CPU](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#cpu) · [enum](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#enum) · [Frame](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#frame) · [GPU](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#gpu) · [Memory](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#memory) · [필드](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#field)

- API와·추가설정: [Rendering Path](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/08_API%EC%99%80_%EC%B6%94%EA%B0%80%EC%84%A4%EC%A0%95.md#rendering-path)

- 보충·기초와·도구이름: [Camera](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#camera) · [Graphics](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#graphics) · [Quality](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#quality)

<!-- study-navigation -->
[이전](../02_%EB%AA%A8%EB%8D%B8%EA%B3%BC%EC%9E%AC%EC%A7%88/05_PBR_%ED%85%8D%EC%8A%A4%EC%B2%98%EC%99%80_%EC%9E%AC%EC%A7%88.md) · [목차](../README.md) · [다음](07_%EC%A1%B0%EB%AA%85_%EB%B2%A0%EC%9D%B4%ED%81%AC%EC%99%80_%EB%B0%98%EC%82%AC.md)
