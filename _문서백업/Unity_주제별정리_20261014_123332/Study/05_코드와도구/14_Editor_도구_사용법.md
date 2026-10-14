# 14. Editor 도구 사용법

> 모르는 단어는 [전문 용어 전체 색인](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4_%EC%82%AC%EC%A0%84.md)에서 영문·한글로 찾습니다. 이 장 맨 아래에는 등장 용어의 바로가기 목록이 있습니다.

## 게임에 붙는 기능과 제작 화면의 기능

**Editor 도구**는 개발자가 배치·변환 작업을 쉽게 하도록 제작 화면에 추가한 기능입니다. 배포한 게임의 버튼과 다릅니다. **오버레이**는 Scene 작업 화면 위에 얹는 도구판, **툴바**는 버튼을 줄로 모은 띠입니다. **툴팁**은 마우스를 올려 잠깐 기다리면 보이는 설명입니다.

아래 PrimTools 그림 버튼을 구별하기 어렵다면 마우스를 올려 툴팁의 `Create Grounded Cube` 같은 정확한 이름을 확인합니다. **Primitive**는 Cube·Sphere 같은 기본 도형입니다. **Reset**은 도구가 정한 초기값으로 돌리는 것이며, 모든 도구의 기준이 같지는 않습니다.

실습 전 02장의 복사 씬을 열고 실습 Cube를 준비합니다. Overlay가 목록에 없다면 Console 오류 → Scene 창 선택 → Overlays 목록 순서로 봅니다. 코드 파일을 GameObject에 붙여 오버레이를 만들려고 하지 않습니다.

## 오버레이는 Scene 창 위의 작은 도구판이다

이 프로젝트는 Scene 뷰용으로 `PrimTools`, `Transform`, `URP Converter`, `VE Extract Tool`을 등록합니다. Inspector의 GameObject 컴포넌트 목록에서 찾는 기능이 아닙니다.

1. Scene 탭에 마우스를 둡니다.
2. Scene의 Overlays 메뉴를 엽니다. 툴바 빈 곳의 우클릭 메뉴 또는 Overlays 메뉴 버튼에서 접근할 수 있습니다. 기본 단축키 환경에서는 백틱(`) 메뉴도 사용할 수 있습니다.
3. 필요한 오버레이 이름을 체크합니다.
4. 패널의 손잡이를 드래그해 위치를 옮깁니다. 숨겨진 패널은 메뉴에서 다시 켭니다.

버전·레이아웃에 따라 아이콘 위치는 다를 수 있습니다. 코드가 등록한 **이름**으로 찾는 것이 확실합니다. [Unity Overlays](https://docs.unity3d.com/6000.0/Documentation/Manual/overlays.html).

## PrimTools

| 버튼·툴팁 | 실제 생성 결과 | 알아둘 점 |
|---|---|---|
| Create Grounded Cube | `Cube_Root` + 자식 Cube | 큐브 반높이만큼 자식을 올림 |
| Create Sphere / Capsule / Cylinder / Plane | 각 Root + 메시 | 선택 부모 아래 또는 월드 원점 |
| Create Empty GameObject | 빈 물체 | 모델이 없는 구조용 물체 |
| Reset Transform of Selected Object(s) | 선택 Transform 초기화 | 여러 선택 대상의 **Local** 위치·회전 0, 크기 1 |
| Create Directional Light | Directional Light | 위치 `(0,3,0)`, 회전 `(50,-30,0)`, Mixed |
| Create Point Light | Point Light | 코드가 정한 기본 광원 생성 |
| Create Spot Light | Spot Light | 위치 `(0,2,0)`, 회전 `(90,0,0)`, Range 15 |
| Create Area Light (Baked Only) | Rectangle Light | Baked, 위치 `(0,2,0)`, 회전 `(90,0,0)` |

Grounded라는 이름은 “씬의 임의 지형에 자동 착지”가 아닙니다. 메시의 bounds 높이로 부모 기준 바닥 정렬을 할 뿐, Terrain이나 Collider를 Raycast로 찾아 붙이는 코드는 없습니다.

실습에서는 Hierarchy의 빈 곳을 클릭해 선택을 해제한 뒤 Cube 버튼을 눌러 봅니다. 선택된 캐릭터 뼈 아래에 새 물체를 실수로 만들지 않도록 새 물체의 부모를 확인합니다.

## 재질 공유의 주의점

Primitive 버튼은 `Assets/Materials`의 정해진 재질을 재사용합니다. 특히 Cube 버튼은 기존 `Cube.Mat`의 색상·Metallic·Smoothness·Emission 설정을 다시 초기화합니다. 그 재질을 쓰는 다른 물체도 영향을 받을 수 있습니다.

따라서 PrimTools 사용을 Scene 오브젝트 생성 하나만 하는 작업이라고 이해하면 안 됩니다. 재질을 꾸민 물체는 자기 복사 재질을 사용합니다. Undo로 오브젝트를 지웠다고 재질 에셋 변경까지 모두 돌아갔다고 가정하지 않습니다.

`CreatePrimitiveDropdown`이라는 코드도 있지만 현재 `PrimToolbarOverlay`가 등록하는 버튼 목록에는 없습니다. 파일이 있다는 이유로 현재 PrimTools에 드롭다운 버튼이 있다고 안내하지 않습니다. 이 별도 코드와 `LightUtils`의 일부 경로는 Built-in의 `Standard` 재질을 생성하므로 URP에서 분홍색 재질 원인이 될 수 있습니다.

## Transform 오버레이

| 조작 | 실제 기준 |
|---|---|
| P | 월드 Position |
| R | 월드 Euler Rotation |
| S | Local Scale |
| 축별 ±90도 버튼 | 해당 월드 Euler 값에 90도 가감 |
| Copy | 현재 활성 선택 하나의 P·R·S를 도구 메모리에 저장 |
| Paste | 저장한 P·R·S를 현재 활성 선택 하나에 적용 |
| Reset | 월드 위치·회전 0, Local Scale 1 |

**Transform 오버레이 Reset과 PrimTools Reset은 기준이 다릅니다.** 부모가 원점에서 떨어져 있으면 두 버튼의 결과도 달라집니다. Inspector Transform 숫자는 보통 부모 기준입니다.

Copy 전에 Paste를 누르면 저장할 값이 아직 준비되지 않았습니다. 특히 copiedScale 기본값이 0이라 물체가 보이지 않을 수 있습니다. Copy → 다른 대상 선택 → Paste 순서로 씁니다.

실습: Cube 위치를 기록하고 Copy → 다른 실습 Cube 선택 → Paste → 두 물체가 겹치는지 확인 → Ctrl+Z. 여러 개를 선택해도 이 오버레이 구현은 activeTransform 하나만 처리합니다.

## URP Converter

1. Project에서 변환할 Built-in Material을 복제합니다.
2. 복제한 Material을 선택합니다.
3. `URP Converter > Convert to URP`를 누릅니다.
4. Console과 재질 Inspector의 Shader·텍스처 슬롯을 확인합니다.

내부적으로 `Edit/Rendering/Materials/Convert Selected Built-in Materials to URP` 메뉴를 호출합니다. Unity 버전에서 이 메뉴를 제공하지 않으면 경고가 납니다. 현재 Editor에서 메뉴 호출 성공을 직접 검증하지 않았습니다.

대체 수동 절차는 새 URP/Lit Material을 만들고 Base Map·Normal 등을 연결하는 05장입니다. 임의의 커스텀 셰이더를 URP로 정확히 자동 변환한다고 생각하지 않습니다.

## VE Extract Tool

Selection 표시로 선택 대상을 확인하고 `Run Extract`를 누릅니다. 코드는 `Varco3DExtractTool.RunFromCurrentSelection()`을 호출합니다. 결과물 삭제·재생성 가능성이 있으므로 **11장을 먼저 읽은 뒤** 사용합니다.

## 전문가 관점: Editor 코드가 따로 필요한 이유

Editor 도구는 `Selection`, `Undo`, `AssetDatabase`, `EditorApplication`을 이용합니다. 설치된 게임에는 Unity 편집기가 없으므로 이런 코드를 실행용 어셈블리와 분리해야 합니다.

현재 `05.Editor`는 정확한 특수 폴더명 `Editor`가 아니며, 다수 파일에 `UNITY_EDITOR` 조건도 없습니다. 이 구조는 사용 설명과 별개로 배포 빌드 점검이 필요한 부분입니다. 문서 작성 중 폴더를 이동하거나 코드를 수정하지 않았습니다.

**확인 질문:** 선택한 물체에 부모가 있을 때 두 Reset 결과가 같을까? 도구 파일이 있으면 항상 버튼으로 노출되는가?

**답:** 좌표 기준이 달라 다를 수 있습니다. 등록과 호출 경로까지 있어야 실제 도구에 나타납니다.

## 이 장의 용어 찾기

모르는 말은 아래 링크 또는 [전체 용어 색인](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4_%EC%82%AC%EC%A0%84.md)에서 찾습니다. 영문 UI 이름도 검색할 수 있습니다.

- PC와·Unity: [Component](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#component) · [Console](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#console) · [GameObject](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#gameobject) · [Hierarchy](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#hierarchy) · [Inspector](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#inspector) · [Project](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#project) · [Transform](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#transform) · [Undo](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#undo) · [Unity](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#unity)

- 수학과·모델: [Bounds](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#bounds) · [Capsule](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#capsule) · [Collider](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#collider) · [Cube](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#cube) · [Cylinder](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#cylinder) · [Euler Angles](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#euler) · [Normal](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#normal) · [Plane](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#plane) · [Primitive](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#primitive) · [Raycast](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#raycast) · [Sphere](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#sphere) · [Terrain](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#terrain)

- 표면과·렌더링: [Area Light](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#area) · [Baked](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#baked) · [Base Map](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#basemap) · [Built-in](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#builtin) · [Directional Light](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#directional) · [Emission](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#emission) · [Lit](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#lit) · [Metallic](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#metallic) · [Mixed](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#mixed) · [Point Light](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#point-light) · [Rendering](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#rendering) · [Shader](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#shader) · [Smoothness](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#smoothness) · [Spot Light](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#spot) · [Standard](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#standard) · [Texture](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#texture) · [URP](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#urp)

- 효과와·움직임과·UI: [Overlay](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#overlay)

- 코드와·통신과·검증: [Assembly](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#assembly) · [Memory](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#memory) · [UNITY_EDITOR](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#unity-editor-symbol)

- 화면의·속성과·메뉴: [Range](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#range)

- API와·추가설정: [activeTransform](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/08_API%EC%99%80_%EC%B6%94%EA%B0%80%EC%84%A4%EC%A0%95.md#activetransform) · [AssetDatabase](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/08_API%EC%99%80_%EC%B6%94%EA%B0%80%EC%84%A4%EC%A0%95.md#assetdatabase) · [EditorApplication](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/08_API%EC%99%80_%EC%B6%94%EA%B0%80%EC%84%A4%EC%A0%95.md#editorapplication) · [RunFromCurrentSelection](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/08_API%EC%99%80_%EC%B6%94%EA%B0%80%EC%84%A4%EC%A0%95.md#runselection) · [Selection](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/08_API%EC%99%80_%EC%B6%94%EA%B0%80%EC%84%A4%EC%A0%95.md#selection)

- 보충·기초와·도구이름: [PrimTools](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#primtools) · [Reset](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#reset) · [Run Extract](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#run-extract) · [URP Converter](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#urp-converter) · [VE Extract Tool](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#ve-extract)

- 프로젝트·코드·식별자: [CreatePrimitiveDropdown](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/10_%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8_%EC%BD%94%EB%93%9C_%EC%8B%9D%EB%B3%84%EC%9E%90.md#script-createprimitivedropdown) · [LightUtils](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/10_%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8_%EC%BD%94%EB%93%9C_%EC%8B%9D%EB%B3%84%EC%9E%90.md#script-lightutils) · [PrimToolbarOverlay](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/10_%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8_%EC%BD%94%EB%93%9C_%EC%8B%9D%EB%B3%84%EC%9E%90.md#script-primtoolbaroverlay) · [Varco3DExtractTool](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/10_%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8_%EC%BD%94%EB%93%9C_%EC%8B%9D%EB%B3%84%EC%9E%90.md#script-varco3dextracttool)

<!-- study-navigation -->
[이전](13_UI_%EC%97%B0%EA%B2%B0_%EC%8B%A4%EC%8A%B5.md) · [목차](../README.md) · [다음](15_%EB%B3%80%ED%99%98_%EC%95%8C%EA%B3%A0%EB%A6%AC%EC%A6%98%EA%B3%BC_%EC%84%A4%EA%B3%84.md)
