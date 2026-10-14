# Cloth의 개념과 원리

[Cloth 목차](../README.md) · [천 실습](../01_천한장_방법.md) · [옷 실습](../02_캐릭터옷_방법.md) · [용어 사전](../../../90_참고/용어사전/11_Cloth와_천물리.md)

천이 움직이려면 **움직일 점, 점 사이의 관계, 붙잡을 자리, 가해지는 가속도, 막아 줄 표면**이 필요합니다. 재질의 색이나 옷의 파일 이름으로 이 조건이 만들어지지는 않습니다.

<a id="particles"></a>

## 1. 점과 삼각형에서 천까지

컴퓨터의 옷은 실제 실로 짠 천이 아닙니다. **정점(Vertex)**이라는 점을 **삼각형(Triangle)**으로 이어 만든 **메시(Mesh)**입니다. 삼각형은 세 점으로 만든 면입니다. 점이 움직이면 그 점에 붙은 면의 모양도 바뀝니다. 이 면에 색과 무늬를 그려 옷처럼 보이게 합니다.

Cloth는 천을 계산할 점을 **입자(Particle)**로 다룹니다. 이때 입자는 불꽃 같은 시각 효과가 아니라 계산용 점입니다. 점끼리 아무 관계가 없다면 중력에 따라 흩어질 뿐입니다. 가까운 점 사이의 길이, 면이 접히는 정도, 움직일 수 있는 범위 등을 제한해야 천으로 남습니다. 이런 제한을 **제약(Constraint)**이라고 합니다.

주름을 만들려면 그 부분을 꺾을 수 있는 점이 있어야 합니다. 점 네 개뿐인 큰 사각형은 세밀하게 접힐 수 없습니다. 반대로 점을 무작정 늘리면 계산량과 조정할 부분도 늘어납니다. 실습에 Quad 대신 여러 칸으로 나뉜 Plane을 쓴 이유입니다.

**그림용 메시의 정점 번호와 Cloth의 입자 번호는 항상 같지 않습니다.** 같은 위치의 정점이 UV 경계 등으로 나뉘어 있어도 Cloth는 하나의 점으로 다룰 수 있습니다. 코드로 칠하기를 자동화할 때 `mesh.vertices[i]`와 `cloth.coefficients[i]`가 같은 점이라고 가정하면 잘못 칠할 수 있습니다. [Cloth.vertices](https://docs.unity3d.com/6000.6/Documentation/ScriptReference/Cloth-vertices.html)

관련 기초: [점·방향·시간](../../../00_준비/00B_점과_방향과_시간.md).

## 2. 위치·속도·가속도

| 말 | 쉬운 뜻 | 예 |
|---|---|---|
| 위치 | 지금 어디 있는가 | 바닥에서 1m 위 |
| 속도 | 어느 방향으로 얼마나 빠르게 움직이는가 | 아래로 초당 2m |
| 가속도 | 속도가 얼마나 빨리 바뀌는가 | 매초 아래쪽 속도가 더 커짐 |
| 관성 | 움직이던 상태를 이어 가려는 성질 | 몸이 멈춰도 옷 끝이 조금 더 움직임 |

Unity는 시간을 작은 간격으로 나누어 다음 상태를 계산합니다. 아래는 이해를 위한 단순한 계산입니다. Unity Cloth 내부 계산식 전체를 그대로 옮긴 것은 아닙니다.

```text
새 속도 ≈ 이전 속도 + 가속도 × 지난 시간
임시 위치 ≈ 이전 위치 + 새 속도 × 지난 시간
최종 위치: 임시 위치를 고정·거리·접힘·충돌 조건에 맞게 조정
```

예를 들어 멈춘 점에 아래쪽 가속도 10m/s²가 0.1초 작용하면, 아래쪽 속도가 약 1m/s 늘어납니다. `m/s²`는 “1초마다 속도가 몇 m/s씩 바뀌는가”를 나타냅니다. 옷에서는 연결과 고정 조건이 이 움직임을 다시 제한합니다.

**중력(Gravity)**도 가속도입니다. Unity에서는 보통 +Y가 위, -Y가 아래입니다. **Use Gravity**는 Cloth에 중력을 적용할지 정합니다. **Unity 6.6에서는 Edit > Project Settings > Physics > Cloth 탭의 Gravity Override**에서 천에 적용할 중력을 확인합니다. Manual에서는 같은 설정을 `Cloth Gravity`라고 설명합니다. 흔한 값 `(0, -9.81, 0)`은 모든 프로젝트에서 반드시 사용하는 값은 아닙니다. [Use Gravity](https://docs.unity3d.com/6000.6/Documentation/ScriptReference/Cloth-useGravity.html), [Physics 설정](https://docs.unity3d.com/6000.6/Documentation/Manual/class-PhysicsManager.html)

코드 이름도 나뉩니다. **`Physics.clothGravity`는 Cloth 중력**, **`Physics.gravity`는 Rigidbody 중력**입니다. Rigidbody는 단단한 물체의 운동을 계산하는 컴포넌트입니다. 공이 잘 떨어진다고 옷에도 같은 중력이 설정됐다고 단정하지 않습니다. [Cloth 중력](https://docs.unity3d.com/6000.6/Documentation/ScriptReference/Physics-clothGravity.html), [Rigidbody 중력](https://docs.unity3d.com/6000.6/Documentation/ScriptReference/Physics-gravity.html)

중력이 켜져 있어도 모든 점을 고정했다면 처질 수 없습니다. 움직일 수 있는 최대 거리가 아주 작아도 거의 안 움직이는 것처럼 보입니다.

**External Acceleration**은 일정한 가속도, **Random Acceleration**은 흔들리는 가속도를 더합니다. 실습에서는 바람을 대신합니다. 이것은 옷의 재질을 바꾸거나 공기 흐름 전체를 정확히 계산하는 작업은 아닙니다. [일정한 가속도](https://docs.unity3d.com/6000.6/Documentation/ScriptReference/Cloth-externalAcceleration.html), [무작위 가속도](https://docs.unity3d.com/6000.6/Documentation/ScriptReference/Cloth-randomAcceleration.html)

<a id="skinning"></a>

## 3. 뼈로 움직인 옷 위에 Cloth가 더해집니다

캐릭터의 **뼈(Bone)**는 몸 부위를 움직이는 기준입니다. **뼈 가중치(Skin Weight)**는 각 점이 어느 뼈를 얼마나 따라갈지 정한 비율입니다. 그 비율로 메시를 변형하는 과정을 **스키닝(Skinning)**이라고 합니다.

팔꿈치 근처 옷의 점이 위팔을 30%, 아래팔을 70% 따라간다고 생각해 봅니다. 팔을 굽히면 두 뼈의 영향을 섞어 그 점의 기준 위치를 계산합니다. 그 뒤 Cloth가 허용 범위 안에서 점을 흔들리게 합니다.

```text
애니메이션 → 뼈의 자세 → 스키닝된 기준 위치
                              ↓
        중력·몸의 이동 + 고정·거리·접힘·충돌 제약
                              ↓
                        천의 최종 모양
```

이것은 역할을 이해하기 위한 흐름도입니다. Unity 전체의 함수 호출 순서표는 아닙니다.

| 구분 | 뼈 가중치 | Cloth 칠하기 |
|---|---|---|
| 정하는 것 | 어느 뼈를 얼마나 따라가는가 | 기준 위치에서 얼마나 벗어날 수 있는가 |
| 값의 예 | 허벅지 0.8, 골반 0.2 | Max Distance 0.05 |
| 잘못됐을 때 | 옷이 다른 뼈를 따라가거나 찌그러짐 | 너무 붙거나 멀리 늘어짐 |

가중치가 모든 점에 있다는 사실만으로 올바른 옷이 되지는 않습니다. **어느 뼈에 연결했는지**도 맞아야 합니다. Cloth는 잘못된 가중치를 자동으로 고쳐 주지 않습니다. 뼈가 없는 Plane 실습은 물체의 모양을 기준으로 계산하는 간단한 경우입니다.

더 깊은 설명: [스키닝과 Bind Pose](../../10_리깅_Avatar와_애니메이션.md).

<a id="max-distance"></a>

## 4. Max Distance의 중심은 움직일 수 있습니다

**Max Distance는 각 점의 스키닝된 기준 위치를 중심으로 허용하는 최대 이동 거리**입니다. 기준점 주위에 눈에 보이지 않는 공을 그렸다고 생각하면 됩니다. 천의 점은 그 공 안에서 움직일 수 있습니다.

```text
몸이 움직이기 전: 기준점 A 주위의 허용 범위
몸이 움직인 뒤:   기준점 B 주위의 허용 범위

Max Distance = 0 → 천의 점은 매 순간 기준점에 놓임
Max Distance > 0 → 기준점 주위에서 제한된 만큼 흔들림
```

그래서 허리 부분의 값을 0으로 만들면 **허리가 있던 세계의 한 자리에 멈추는 것이 아니라, 움직이는 허리의 기준점을 계속 따라갑니다.** 이 차이를 모르면 고정을 풀어야 캐릭터를 따라간다고 오해하기 쉽습니다. [Max Distance의 정의](https://docs.unity3d.com/6000.6/Documentation/ScriptReference/ClothSkinningCoefficient-maxDistance.html)

| Select 도구의 상태 | 의미 |
|---|---|
| Max Distance 체크 켬 + 0 | 기준점에 고정 |
| 체크 켬 + 양수 | 그 거리 안에서 움직임 허용 |
| 체크 끔 | 이 거리 제한을 사용하지 않음 |

체크를 끈 상태에서 회색 숫자가 0처럼 보여도 **0으로 고정한 상태가 아닙니다.** 칠하기 색은 선택한 표시 종류와 값 범위에 따라 달라집니다. 검은색도 ‘고정’이라고 외우면 안 됩니다. 정확한 판정은 체크 상태와 숫자로 합니다. [6000.6.0f1 Inspector의 값 처리](https://github.com/Unity-Technologies/UnityCsReference/blob/6000.6.0f1/Modules/ClothEditor/ClothInspector.cs)

## 5. 뻣뻣함·고정·감쇠는 서로 다릅니다

- **Stretching Stiffness**: 천이 길게 늘어나는 데 얼마나 저항하는가. 점과 점 사이의 간격을 유지하려는 성질입니다. [API](https://docs.unity3d.com/6000.6/Documentation/ScriptReference/Cloth-stretchingStiffness.html)
- **Bending Stiffness**: 천이 접히는 데 얼마나 저항하는가. 종이와 얇은 천의 차이를 생각하면 쉽습니다. [API](https://docs.unity3d.com/6000.6/Documentation/ScriptReference/Cloth-bendingStiffness.html)
- **Use Tethers**: 움직이는 점이 고정된 점에서 지나치게 멀어지지 않도록 도와 과도한 늘어짐을 줄입니다. 점을 어디에 붙잡을지 대신 정해 주지는 않습니다. [API](https://docs.unity3d.com/6000.6/Documentation/ScriptReference/Cloth-useTethers.html)
- **Damping, 감쇠**: 흔들리던 움직임이 잦아들게 합니다. 값을 키우면 대체로 움직임이 빨리 가라앉습니다. 옷을 몸에 붙이는 설정은 아닙니다. [API](https://docs.unity3d.com/6000.6/Documentation/ScriptReference/Cloth-damping.html)

뻣뻣한 천도 통째로 움직일 수 있고, 부드러운 천도 윗부분은 고정할 수 있습니다. 따라서 ‘안 움직인다’는 증상을 보고 Bending만 바꾸면 고정값 때문에 생긴 문제는 해결되지 않습니다.

<a id="collision"></a>

## 6. 보이는 몸과 충돌용 몸은 다릅니다

사람 모양이 화면에 보인다고 천이 그 표면을 자동으로 알지는 못합니다. **Collider, 충돌체**는 계산에 사용할 단순한 경계입니다. Cloth에서는 주로 몸통·팔다리를 **Capsule Collider, 캡슐 충돌체**로 감쌉니다.

몸에 충돌체를 붙이는 것과 옷의 Cloth 목록에 등록하는 것은 별개입니다. **Capsule Colliders** 목록에 연결한 캡슐, **Sphere Colliders** 목록에 연결한 구를 Cloth가 충돌 대상으로 사용합니다. Box Collider나 Mesh Collider를 같은 방식으로 등록하는 기능은 없습니다. [Capsule 목록](https://docs.unity3d.com/6000.6/Documentation/ScriptReference/Cloth-capsuleColliders.html), [Sphere 목록](https://docs.unity3d.com/6000.6/Documentation/ScriptReference/Cloth-sphereColliders.html)

Sphere 목록의 한 항목에는 `First`, `Second`가 있습니다. First에만 구를 넣으면 구 하나이고, 둘 다 넣으면 두 구와 그 사이를 잇는 굵기가 달라질 수 있는 캡슐 모양입니다. 팔·다리의 굵기 차이를 대략 표현할 때 쓸 수 있습니다. [ClothSphereColliderPair](https://docs.unity3d.com/6000.6/Documentation/ScriptReference/ClothSphereColliderPair.html)

충돌은 계산용 입자와 단순한 경계를 이용하므로 완벽한 실제 옷처럼 모든 관통을 막는다고 보장할 수 없습니다. 점 간격, 큰 움직임, 시작 시 겹침, 충돌체 크기 등을 함께 봐야 합니다. 더 정교한 외관이 필요하면 메시와 애니메이션 자체도 조정합니다.

**Surface Penetration**은 스키닝된 옷의 기준 표면 뒤쪽으로 파고드는 것을 제한하는 입자별 설정입니다. **법선(Normal)**, 즉 표면의 바깥 방향을 이용합니다. 이것을 칠한다고 별도 Body 메시 전체가 충돌체로 등록되는 것은 아닙니다. 본문 실습에서는 끄고 명시적인 캡슐 충돌부터 확인합니다. [표면 제약의 정의](https://docs.unity3d.com/6000.6/Documentation/ScriptReference/ClothSkinningCoefficient-collisionSphereDistance.html)

## 7. 정확도에는 계산 시간이 필요합니다

여러 제약을 한 번에 완벽하게 맞추기는 어렵습니다. 계산을 되풀이하며 오차를 줄이는 부분을 **Solver, 솔버**라고 합니다. **Solver Frequency**는 초당 반복 계산 수입니다. 화면을 그리는 횟수인 FPS와는 다른 값입니다.

예를 들어 공식 API 설명에서 240회/초는 60FPS일 때 프레임당 약 4회 계산하는 경우에 해당합니다. 값을 올리면 더 정확해질 수 있지만 계산 시간도 늘어납니다. 프레임 속도가 달라지거나 다른 조건이 바뀌면 결과를 다시 확인해야 합니다. [Cloth.clothSolverFrequency](https://docs.unity3d.com/6000.6/Documentation/ScriptReference/Cloth-clothSolverFrequency.html)

이 때문에 점 수·충돌체·자기 충돌을 모두 최대치로 늘리는 방식보다 **필요한 부분에만 Cloth를 적용하고 같은 동작으로 비교**하는 것이 좋습니다. 성능이 충분한지는 실제 게임과 목표 기기에서 측정합니다.

## 스스로 설명해 보기

1. 허리의 Max Distance가 0인데도 걷는 몸을 따라가는 이유는 무엇인가요?
2. 옷에 뼈 가중치가 있는데도 Cloth의 고정부를 정해야 하는 이유는 무엇인가요?
3. 몸에 Mesh Collider가 있어도 Cloth가 뚫는 이유는 무엇인가요?
4. Damping을 키우는 것과 Max Distance를 줄이는 것은 무엇이 다른가요?

답의 핵심: **기준점이 움직임 / 뼈 연결과 이동 허용 범위는 별개 / 지원 충돌체를 명시적으로 등록 / 운동을 가라앉힘과 공간 범위를 제한함의 차이**.

다음: [설정과 문제 해결](설정과문제해결.md)
