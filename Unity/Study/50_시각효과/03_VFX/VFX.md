# VFX 입자 효과

[전체 주제 목차](../../README.md) · [전체 용어 사전](../../90_용어사전/README.md)

**입자**는 작은 점·면 등의 반복 요소이며, **VFX**는 Visual Effects, 화면 효과라는 뜻입니다. 이 프로젝트의 먼지는 입자를 여러 개 만들고 각자의 위치·수명·투명도를 바꿔 표현합니다. Spawn은 생성, Initialize는 초기값 지정, Update는 시간 변화, Output은 그리기를 맡습니다.

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
