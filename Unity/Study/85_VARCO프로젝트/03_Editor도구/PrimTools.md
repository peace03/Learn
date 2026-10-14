# PrimTools: 기본 도형과 광원 생성

[전체 주제 목차](../../README.md) · [전체 용어 사전](../../90_용어사전/README.md)

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
