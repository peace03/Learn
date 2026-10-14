# 08. Volume 후처리

> 모르는 단어는 [전문 용어 전체 색인](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4_%EC%82%AC%EC%A0%84.md)에서 영문·한글로 찾습니다. 이 장 맨 아래에는 등장 용어의 바로가기 목록이 있습니다.

## 사진의 색을 바꾸는 일과 물체의 표면을 바꾸는 일

선수 개념은 준비 C의 HDR·톤매핑과 06장의 카메라입니다. 이미 계산한 화면의 밝기·색에 다시 규칙을 적용하는 것이 **후처리**입니다. 따라서 같은 모델·조명도 후처리 설정에 따라 다르게 보입니다.

**노출**은 밝기 배율입니다. **대비**는 밝고 어두운 차이, **채도**는 색의 선명함, **색온도**는 따뜻한 색과 차가운 색의 균형입니다. **틴트**는 여기서 주로 초록과 자홍 쪽 균형입니다. 색온도에 붙는 숫자가 물체의 실제 온도를 바꾸지는 않습니다.

**Weight**는 해당 Volume의 영향 정도, **Priority**는 함께 적용될 때의 우선순위, **Layer Mask**는 검사 대상 Layer를 고르는 필터입니다. Global Volume은 거리에 따른 지역 제한 없이 적용 후보가 되고, Local Volume은 공간 범위 조건이 추가됩니다. 후보여도 카메라 필터나 Override 조건이 맞지 않으면 원하는 값이 적용되지 않습니다.

아래 비교에서는 복제한 Profile 슬롯에 `Study_Lab_Profile`이 실제로 나타났는지 먼저 확인합니다. 원본 `Lab_Studio`가 보이면 아직 연결을 바꾸지 않은 것입니다. 새 효과가 필요한데 목록에 없을 때는 Profile의 `Add Override`에서 효과 이름을 검색합니다. 값 왼쪽 체크와 효과 제목의 활성 체크를 모두 봅니다.

## 카메라가 그린 그림을 다시 조절한다

후처리는 완성되어 가는 화면 전체에 적용하는 처리입니다. 재질은 물체 표면의 성질이고, 후처리는 화면에 보이는 결과를 바꿉니다. 피부색이 이상할 때 재질부터 바꾸기 전에 색 보정도 확인해야 하는 이유입니다.

**Volume**은 효과의 적용 범위·세기·우선순위를 정하는 컴포넌트, **Profile**은 효과 값이 담긴 에셋입니다. Global은 공간 전역, Local은 Collider 범위와 카메라 위치 등에 따라 적용됩니다. 여러 Volume은 조건에 따라 값을 섞습니다. [Unity Volume 원리](https://docs.unity3d.com/6000.0/Documentation/Manual/urp/Volumes.html).

## 숫자를 바꿨는데 변화가 없는 이유

값 왼쪽 **Override 체크**는 “이 값으로 덮어쓰겠다”는 뜻입니다. 체크가 꺼져 있으면 입력된 숫자가 있어도 현재 Volume이 그 항목을 결정하지 않을 수 있습니다.

확인 순서: GameObject 활성 → Volume 컴포넌트 활성 → Profile 연결 → 효과 활성 → 값의 Override → Weight → 카메라 Volume Layer Mask → 카메라 Post Processing → 다른 Volume의 우선순위.

## 이 프로젝트의 주요 효과

| 효과 | 바꾸는 것 | 과하면 생기는 문제 |
|---|---|---|
| Bloom | 밝은 부분 주변의 번짐 | 형태·글자가 흐려짐 |
| Tonemapping | 넓은 밝기 범위를 화면 표현에 맞게 압축 | 재질의 원래 색과 차이가 커질 수 있음 |
| Color Adjustments | 노출·대비·채도 등 | 검정 뭉침·하이라이트 소실 |
| White Balance | 전체 색의 온도·틴트 | 흰 물체가 다른 색으로 보임 |
| Lift / Gamma / Gain | 어두운 영역·중간·밝은 영역의 색과 밝기 | 구간별 색 균형이 무너짐 |
| Vignette | 화면 가장자리 어둡게 | 주변 UI나 피사체 가림 |
| Motion Blur | 움직임의 흐림 | 동작 판독 어려움 |
| Color Lookup / LUT | 색을 표로 바꾸기 | 잘못된 LUT 형식·임포트 설정으로 색 왜곡 |

`Lab_Studio.asset`에는 Color Adjustments, Tonemapping, Bloom, White Balance, LiftGammaGain이 들어 있습니다. 다른 프로필의 효과가 모두 동시에 적용 중인 것은 아닙니다.

## 현재 프로필의 출발값

파일에서 확인한 `Lab_Studio` 값 일부:

- Post Exposure `0.2`, Contrast `20`.
- Bloom Threshold `1.2`, Intensity `0.2`, Scatter `0.6`.
- White Balance Temperature `-10`, Tint `0`.

프로필 전체의 다른 값, 카메라·URP 기본 프로필도 결과에 영향을 줍니다. 위 숫자만 복제해도 모든 씬이 같은 화면이 되지는 않습니다.

## 실습: 프로필 복제 후 하나씩 비교

1. Project에서 `Assets/VARCO_URP/07.Settings/URP Profile/Lab_Studio.asset`을 선택합니다.
2. `Ctrl+D` → 이름 `Study_Lab_Profile` → `_Study/Profiles`로 이동합니다.
3. Hierarchy에서 `Lab_Studio_Env > Lighting > Volume Profile`을 선택합니다.
4. 복제한 `Study_Lab_Profile`을 **Volume > Profile 슬롯**에 드래그합니다. 슬롯 오른쪽 동그라미 선택기를 써도 됩니다.
5. Mode가 Global인지, Weight가 1인지 확인합니다.
6. Main Camera의 Post Processing을 확인하고 Game 탭을 봅니다.
7. Bloom을 펼쳐 Intensity 왼쪽 Override를 켭니다. Intensity `0`과 `0.8`을 비교합니다.
8. Intensity를 원래 값으로 돌린 다음 Color Adjustments > Post Exposure만 `0`과 `1`로 비교합니다.
9. 다시 원래 값으로 돌리고 White Balance Temperature를 `-20`과 `20`으로 비교합니다.
10. 가장 잘 보이는 조합을 기록하고 씬을 저장합니다.

서로 다른 화면을 만들려면 “차가운 화면: Temperature를 낮춤”, “더 강한 빛 번짐: 밝은 재질과 Bloom 조절”처럼 **원인과 결과를 묶어 기록**합니다.

## 정확하게 이해하기

노출은 밝기를 더하는 것과 다릅니다. 일반적인 stop 기반 노출에서는 +1이 약 2배, -1이 약 1/2의 광량 배율입니다. Tonemapping과 디스플레이 변환 뒤의 최종 픽셀 값까지 정확히 두 배가 되는 것은 아닙니다.

Bloom Threshold보다 밝은 픽셀이 충분하지 않으면 Intensity만 올려도 기대한 번짐이 나오지 않을 수 있습니다. Emission을 크게 올려 문제를 가리기보다 광원·노출·재질을 분리해 봅니다.

프로필을 여러 개 켜면 설정이 섞일 수 있습니다. 단순한 A/B 비교는 비교 대상 중 하나만 활성화합니다. 13장에서 버튼으로 이 동작을 연결합니다.

**확인 질문:** Profile 값이 바뀌는데 화면이 그대로라면 무엇을 볼까? Bloom이 주변 물체의 실제 조명 계산을 대신하는가?

**답:** Override·Weight·카메라·레이어·다른 Volume을 확인합니다. Bloom은 화면의 번짐이며 광원 자체가 아닙니다.

## 이 장의 용어 찾기

모르는 말은 아래 링크 또는 [전체 용어 색인](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4_%EC%82%AC%EC%A0%84.md)에서 찾습니다. 영문 UI 이름도 검색할 수 있습니다.

- PC와·Unity: [Component](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#component) · [GameObject](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#gameobject) · [Hierarchy](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#hierarchy) · [Import](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#import) · [Layer](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#layer) · [Layer Mask](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#layer-mask) · [Override](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#override) · [Project](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#project) · [Unity](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#unity)

- 수학과·모델: [Collider](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#collider)

- USD와·파일형식: [.asset](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#asset-file)

- 표면과·렌더링: [Emission](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#emission) · [HDR](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#hdr) · [Highlight](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#highlight) · [Mask](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#mask) · [URP](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#urp)

- 효과와·움직임과·UI: [Bloom](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#bloom) · [Color Adjustments](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#color-adjustments) · [Color Lookup](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#color-lookup) · [Color Temperature](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#color-temperature) · [Contrast](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#contrast) · [Exposure](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#exposure) · [Gain](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#gain) · [Gamma](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#gamma) · [Global Volume](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#global-volume) · [Lift](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#lift) · [Local Volume](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#local-volume) · [LUT](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#lut) · [Motion Blur](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#motionblur) · [Post Processing](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#postprocessing) · [Priority](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#priority) · [stop](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#stop) · [Temperature](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#temperature) · [Tint](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#tint) · [Tonemapping](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#tonemapping) · [UI](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#ui) · [Vignette](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#vignette) · [Volume](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#volume) · [Volume Profile](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#profile) · [White Balance](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#white-balance)

- 화면의·속성과·메뉴: [Intensity](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#intensity) · [Motion](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#motion) · [Scatter](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#scatter) · [Threshold](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#threshold)

- 보충·기초와·도구이름: [Add Override](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#add-override) · [Camera](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#camera)

<!-- study-navigation -->
[이전](07_%EC%A1%B0%EB%AA%85_%EB%B2%A0%EC%9D%B4%ED%81%AC%EC%99%80_%EB%B0%98%EC%82%AC.md) · [목차](../README.md) · [다음](09_%EC%85%B0%EC%9D%B4%EB%8D%94_%EB%8D%B0%EC%B9%BC%EA%B3%BC_VFX.md)
