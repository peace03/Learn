# HLSL 셰이더 코드 읽기

[전체 주제 목차](../../README.md) · [전체 용어 사전](../../90_용어사전/README.md)

## HLSL 파일을 읽을 때

`URPC#/UVC_Color Shadow Matte.shader`는 투명 그림자 수신 표면입니다. ShadowCaster 패스가 없어 자체 그림자를 만들지 않습니다. `_alphaClip`이라는 이름이 있어도 실제 코드에서는 픽셀을 버리는 `clip()` 대신 색 합성 경로를 고릅니다. 이름보다 코드를 봅니다.

`UVC_Skybox.shader`는 Cubemap·Exposure·Speed를 노출합니다. `_Color`는 선언되어 있지만 최종 색 계산에서 사용되지 않습니다. Color 값을 바꿔도 기대한 변화가 없을 수 있는 구체적인 사례입니다. 이 문서 작성 중 셰이더를 수정하거나 컴파일하지 않았습니다.
