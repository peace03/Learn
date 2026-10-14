# Cloth Capsule Margin

Unity 기본 Cloth가 캡슐을 살짝 뚫고 보이는 현상을 줄이는 보조 충돌 스크립트입니다. 보이는 캡슐보다 조금 큰 충돌체를 실행 중에 만들고 Cloth에 연결합니다.

[v1.0.0 패키지 다운로드](https://github.com/peace03/Learn/releases/download/cloth-capsule-margin-v1.0.0/ClothCapsuleMargin_v1.0.0.unitypackage) · [릴리스 설명](https://github.com/peace03/Learn/releases/tag/cloth-capsule-margin-v1.0.0) · [처음 사용하는 사람을 위한 설명서](Documentation/README.md)

## 바로 적용하기

1. 위의 `.unitypackage`를 다운로드합니다.
2. 적용할 Unity 프로젝트에서 **Assets → Import Package → Custom Package...**로 가져옵니다.
3. Capsule Collider가 있는 물체에 **Cloth Capsule Margin**을 추가합니다.
4. **Target Cloth**에 사용할 천의 Cloth 컴포넌트를 연결합니다.
5. **Margin**을 모델 크기에 맞게 조절하고 Play에서 확인합니다.

패키지 안에 `Assets/Scripts/Cloth/Documentation/README.md`가 포함됩니다. 설치·연결·Margin 조절·Plane으로 시작하는 실습·문제 해결·용어 설명을 담았습니다. 가져오기만 하면 자동으로 적용되는 기능은 아닙니다.

## 저장한 파일

| 위치 | 내용 |
|---|---|
| [Runtime/ClothCapsuleMargin.cs](Runtime/ClothCapsuleMargin.cs) | 실제 실행 코드 |
| [Documentation/README.md](Documentation/README.md) | 패키지와 동일한 사용 설명서 |
| `.meta` 파일 | 패키지에 사용한 Unity 에셋 식별 정보 |
| GitHub Releases | 버전별 `.unitypackage` 다운로드 |

이 폴더는 재사용할 기능의 소스와 설명서입니다. Unity Hub에서 열 수 있는 완전한 Unity 프로젝트나 UPM 패키지는 아닙니다. 처음 사용할 때는 릴리스의 `.unitypackage`로 가져오세요.

## 확인한 범위

- 기준: Unity **6000.3.9f1**, Unity 기본 Cloth.
- 원본 Test 프로젝트에서 컴파일·충돌체 등록과 복구·충돌 움직임을 검사했고 사용자가 정상 작동을 확인했습니다.
- 배포 패키지의 코드·설명서·메타 정보가 원본과 같은지 대조했습니다.
- 다른 프로젝트·다른 Unity 버전·Player 빌드의 동작까지 검증한 결과는 아닙니다.

Margin은 월드 거리이며 너무 크면 천이 떠 보입니다. 고정점 충돌, 큰 삼각형, 순간이동을 모두 해결하는 기능은 아닙니다. 스크립트 한 개는 캡슐 한 개와 Cloth 한 개를 연결합니다.
