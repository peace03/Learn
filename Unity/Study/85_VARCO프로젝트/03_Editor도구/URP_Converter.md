# URP Converter: 재질 변환

[전체 주제 목차](../../README.md) · [전체 용어 사전](../../90_용어사전/README.md)

## URP Converter

1. Project에서 변환할 Built-in Material을 복제합니다.
2. 복제한 Material을 선택합니다.
3. `URP Converter > Convert to URP`를 누릅니다.
4. Console과 재질 Inspector의 Shader·텍스처 슬롯을 확인합니다.

내부적으로 `Edit/Rendering/Materials/Convert Selected Built-in Materials to URP` 메뉴를 호출합니다. Unity 버전에서 이 메뉴를 제공하지 않으면 경고가 납니다. 현재 Editor에서 메뉴 호출 성공을 직접 검증하지 않았습니다.

대체 수동 절차는 새 URP/Lit Material을 만들고 Base Map·Normal 등을 연결하는 05장입니다. 임의의 커스텀 셰이더를 URP로 정확히 자동 변환한다고 생각하지 않습니다.
