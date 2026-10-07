# 11. VARCO Bridge와 변환 도구

> 모르는 단어는 [전문 용어 전체 색인](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4_%EC%82%AC%EC%A0%84.md)에서 영문·한글로 찾습니다. 이 장 맨 아래에는 등장 용어의 바로가기 목록이 있습니다.

## 가져오기와 변환을 구분하고 시작한다

[04A. USD 기초](../02_모델과재질/04A_USD를_처음부터_이해하기.md)를 먼저 읽습니다. **다운로드**는 다른 곳의 파일을 내 PC에 받는 일, **임포트**는 받은 파일을 Unity가 사용할 형태로 읽는 일, **변환**은 다른 파일 규칙으로 내용을 다시 쓰는 일입니다. 세 단계 중 앞 단계가 성공해도 뒷 단계가 실패할 수 있습니다.

**서버**는 요청을 받아 처리하는 프로그램, **클라이언트**는 요청하는 쪽입니다. Bridge는 이 PC에서 요청을 받고 Unity 임포트로 넘깁니다. **포트**는 한 컴퓨터 안에서 통신할 프로그램을 구별하는 번호입니다. 5326은 이 Bridge 코드에 정해진 번호이며 Unity 전체의 공통 번호가 아닙니다. **localhost**는 내 컴퓨터를 가리키는 이름입니다.

**Console 로그**는 프로그램이 남긴 글입니다. 연결 대기 로그, 파일 수신 로그, 변환 완료 로그가 증명하는 단계는 각각 다릅니다. 웹 버튼 위치는 이번 문서 작업에서 실제 클릭하지 않았으므로 아래 절차 중 웹 단계에서는 해당 서비스의 현재 화면 안내를 함께 확인합니다. 기존 모델로 공부하는 데 웹 접속은 필수가 아닙니다.

## 두 도구의 역할

**VARCO Bridge**는 웹의 파일을 Unity로 받아 씬에 배치하는 연결 도구입니다. **Varco3DExtractTool**은 선택한 USDZ·FBX를 읽고 별도 FBX·클립·재질·프리팹을 만드는 프로젝트 전용 도구입니다.

```text
VARCO 웹 → Bridge → Assets/VARCO3DImports
                       ↓ 사용자가 선택
                  Run Extract
                       ↓
                Assets/VARCO_Converted
```

Bridge가 받았다고 Humanoid가 된 것은 아니고, FBX가 생겼다고 재질과 움직임이 완전히 같다는 뜻도 아닙니다.

## 기존 결과부터 공부한다

입문자는 먼저 이미 있는 `Streetwear Robot_Walk.fbx`와 `Lab_Varco3D_01`로 04~10장을 실습합니다. 웹 계정·모델 생성·다운로드를 완료해야만 앞의 학습이 가능한 것은 아닙니다.

Bridge `1.1.0`은 프로젝트의 `Packages/VARCO3D-Bridge-for-Unity`에 있습니다. manifest에는 다른 PC 경로인 `file:C:/Unity 6_URP_01/VARCO3D-Bridge-for-Unity`가 남아 있고, lock 파일은 현재 패키지를 `embedded`로 기록합니다. 경로 문자열만 보고 패키지를 재설치하지 말고 Package Manager에서 실제 선택된 패키지를 먼저 확인합니다.

## 실습 A: Bridge로 받기

1. 실습 씬을 저장하고 Play를 끕니다.
2. Unity 상단 `VARCO3D > Connect VARCO3D`를 클릭합니다. **코드의 실제 메뉴명**입니다. README의 짧은 `Connect` 표기와 다릅니다.
3. Console에서 `[VARCO3D] Listening on port 5326` 기록을 확인합니다. 체크 표시만으로 다운로드 성공을 판단하지 않습니다.
4. `VARCO3D > Open VARCO3D`를 클릭합니다.
5. 웹에서 본인이 사용할 모델을 열고 `Send to Unity` 기능을 실행합니다. 로그인과 현재 웹 UI는 웹 서비스에서 직접 확인합니다.
6. Unity의 임포트가 끝나면 Project > `Assets/VARCO3DImports`를 확인합니다.
7. Hierarchy에 새 모델이 생겼는지, Renderer 재질과 Animator Controller가 있는지 확인합니다.
8. 작업을 마치면 같은 Connect 메뉴로 연결을 끌 수 있습니다.

근거는 [프로젝트 내 Bridge README](<C:/KNDA_NCAI/UnityProject/Learning/261007 NC강사님/Unity6.6_URPVarco/Packages/VARCO3D-Bridge-for-Unity/README.md>)와 `VARCO3DMenu.cs`, `VARCO3DUsdzImporter.cs`입니다. 웹 안내 페이지는 [VARCO Bridge 사용자 안내](https://3d.varco.ai/blog/2026-03-19-varco-3d-bridge-for-unity)에 있으나, 이번 조사에서 본문 내용을 읽어 검증하지는 못했습니다.

포트는 프로그램이 통신을 받는 문 번호입니다. 현재 코드는 `IPAddress.Any`에 5326을 바인딩합니다. 이를 “localhost에서만 접근할 수 있는 서버”라고 이해하면 안 됩니다. 임포트가 끝나면 연결을 끄는 방법도 알아둡니다.

## 변환 전 보존 절차

이 도구는 동일 이름의 FBX·일부 AnimationClip·Prefab을 **삭제 후 다시 생성**합니다. 기존 재질을 수정하고 같은 이름의 텍스처를 덮어쓸 수도 있습니다. GUID가 바뀌면 다른 씬의 참조가 끊길 수 있으며 Ctrl+Z가 파일 변경 전체를 복구하지 않습니다.

1. 현재 씬과 필요한 에셋을 저장합니다.
2. 가장 안전한 반복 실습은 별도 **프로젝트 복사본**에서 합니다. 최소한 `Assets`, `Packages`, `ProjectSettings`를 같은 묶음으로 외부 백업합니다. 캐시인 Library는 보존 필수 원본이 아닙니다.
3. 특히 `Assets/VARCO_Converted/Streetwear Robot_Walk`와 그 `.meta` 파일들을 보존합니다.
4. 지금 사용할 원본 USDZ와 대상 캐릭터가 같은 모델인지 확인합니다.

이 문서 작업에서는 변환 버튼을 실행하지 않았습니다. 아래는 독자가 백업한 실습 환경에서 실행할 절차입니다.

## 실습 B: USDZ에서 추출

1. 원본 USDZ가 아직 Hierarchy에 없다면 Project의 `Assets/VARCO3DImports/Streetwear Robot_Walk/Streetwear Robot_Walk.usdz`를 Hierarchy 빈 공간으로 드래그합니다. Unity가 GameObject로 임포트하지 못했다면 진행하지 말고 Console부터 확인합니다.
2. 원본 캐릭터 **루트**를 선택합니다. 변환된 FBX 인스턴스와 혼동하지 않습니다.
3. 루트가 빈 컨테이너의 자식이면 특히 주의합니다. 현재 도구는 최상위 부모까지 올라가므로 의도와 다른 전체 묶음을 선택할 수 있습니다. 별도 프로젝트의 단독 루트로 실습합니다.
4. `Tools > URPLab > VARCO > Convert Character + Pick USDZ`를 클릭합니다.
5. 파일 선택 창에서 그 캐릭터의 `.usdz`를 지정합니다. 원본을 명시하는 경로가 이름 자동 추정보다 확인하기 쉽습니다.
6. 진행 표시가 끝나면 Console에서 FBX 경로, Bound joints, AnimationClips, Avatar 결과를 읽습니다.
7. Project의 결과 폴더를 확인하고, 10장 방식으로 새 FBX의 Rig·Animation·재생을 확인합니다.

간단한 경로는 `Tools > URPLab > VARCO > Run Extract (Auto)`입니다. Scene 뷰의 `VE Extract Tool > Run Extract`도 같은 진입 함수를 호출합니다. 선택 파일이 FBX인지 USDZ인지, Hierarchy 오브젝트인지에 따라 분기합니다.

## 어떤 결과가 생기는가

USDZ 변환은 일반적으로 아래 구조를 만듭니다. 파일이 실제로 생성되는지는 입력과 분기에 따라 다릅니다.

```text
Assets/VARCO_Converted/<모델명>/
├─ <모델명>.fbx
├─ Textures/      추출 이미지
├─ Materials/     URP/Lit 재질
├─ Animations/    Original, RetargetClean 등 중간 클립
└─ Prefabs/       재질을 연결한 프리팹
```

현재 Walk 폴더의 `.controller`가 있다고 해서 변환기가 항상 Controller까지 만든다고 설명하면 틀립니다. `ProcessFbx()`는 Animator의 Apply Root Motion을 끄지만, Animator Controller를 새로 구성하지 않습니다.

## 다른 메뉴

| 메뉴 | 입력 | 실제 역할·조건 |
|---|---|---|
| `Run Extract (Auto)` | FBX·USDZ·Hierarchy 선택 | 선택 유형을 보고 분기 |
| `Convert Character + Pick USDZ` | Hierarchy 루트 + 원본 지정 | 모델과 원본을 명시해 USDZ 변환 |
| `Extract USDZ Textures Only` | USDZ 또는 대응하는 루트 | 이미지 추출. 내부 구현은 USDA 읽기도 요구 |
| `Extract Selected FBX` | Project의 FBX | 해당 FBX 옆에 재질·텍스처·프리팹 처리 |
| `Assets > VARCO > Convert USDZ to FBX (Motion + Textures)` | Project의 USDZ | Unity가 해당 에셋을 GameObject로 제공해야 진행 |

**FBX 추출**은 USDZ 변환과 다르게 무조건 `VARCO_Converted`에 새 FBX를 만드는 작업이 아닙니다. 선택한 FBX의 폴더 옆에 결과를 만듭니다. 또 이 경로 자체는 Humanoid 자동 매핑을 호출하지 않습니다.

## 지원 범위와 검사 순서

현재 변환기는 USDZ 안의 **텍스트 `.usda`**와 `SkelAnimation`을 기대합니다. 모든 USDZ를 지원하는 범용 변환기는 아닙니다. 내부에 `.usda`가 없으면 진행하지 못합니다. `.usdc`는 바이너리이고 `.usd`는 텍스트일 수도 있지만, 현재 코드는 확장자가 `.usda`인 항목만 찾습니다. 따라서 유효한 텍스트 `.usd`도 이 검색에서 제외됩니다. 애니메이션 없는 입력도 전체 변환 경로에서 중단될 수 있습니다.

검사는 다섯 단계로 나눕니다.

1. **파일:** FBX·이미지·프리팹이 존재하는가?
2. **연결:** 재질·메시·Controller·뼈 참조가 맞는가?
3. **움직임:** 뼈와 메시가 같이 움직이는가?
4. **외관:** Base·Normal·ORM 채널·방향·크기가 맞는가?
5. **재사용:** 다른 씬과 대상 Avatar에서도 의도대로 쓰이는가?

`Retarget Ready: True`는 도구가 검사한 조건을 통과했다는 뜻입니다. 발 접지·루프 품질·다른 캐릭터 재생까지 눈으로 확인한 인증이 아닙니다.

**확인 질문:** FBX가 생성됐는데 왜 여전히 검사가 필요한가? Textures Only는 모든 USDZ에서 동작하는가?

**답:** 파일 존재는 연결·외관·동작을 보장하지 않습니다. 현재 구현은 텍스처만 추출할 때도 읽을 수 있는 USDA를 요구합니다.

## 이 장의 용어 찾기

모르는 말은 아래 링크 또는 [전체 용어 색인](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4_%EC%82%AC%EC%A0%84.md)에서 찾습니다. 영문 UI 이름도 검색할 수 있습니다.

- PC와·Unity: [.meta](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#meta) · [Console](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#console) · [Embedded Package](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#embedded) · [GameObject](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#gameobject) · [GUID](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#guid) · [Hierarchy](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#hierarchy) · [Import](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#import) · [Instance](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#instance) · [Library](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#library) · [manifest.json](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#manifest) · [Package](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#package) · [Package Manager](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#package-manager) · [Play](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#play) · [Prefab](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#prefab) · [Project](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#project) · [Project Settings](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#project-settings) · [Unity](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#unity) · [바이너리](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#binary) · [프로그램](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#program)

- 수학과·모델: [3D](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#3d) · [Normal](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#normal)

- USD와·파일형식: [.controller](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#controller-file) · [.cs](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#cs-file) · [FBX](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#fbx) · [joints](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#joints) · [SkelAnimation](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#skelanimation) · [USD](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd) · [USDA](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usda) · [USDZ](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usdz)

- 표면과·렌더링: [Lit](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#lit) · [ORM](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#orm) · [Renderer](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#renderer) · [Texture](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#texture) · [URP](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#urp)

- 효과와·움직임과·UI: [Animation](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#animation) · [Animation Clip](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#clip) · [Animator](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#animator) · [Animator Controller](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#controller) · [Avatar](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#avatar) · [Binding](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#binding) · [Humanoid](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#humanoid) · [Rig](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#rig) · [Root Motion](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#rootmotion) · [UI](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#ui)

- 코드와·통신과·검증: [Client](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#client) · [Download](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#download) · [IPAddress.Any](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#ipaddress-any) · [localhost](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#localhost) · [lock](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#lock) · [string](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#string) · [VARCO](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#varco) · [VARCO Bridge](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#bridge)

- 화면의·속성과·메뉴: [Apply](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#apply-import) · [Apply Root Motion](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#apply-root-motion) · [Motion](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#motion)

- API와·추가설정: [Bound joints](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/08_API%EC%99%80_%EC%B6%94%EA%B0%80%EC%84%A4%EC%A0%95.md#bound-joints) · [ProcessFbx](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/08_API%EC%99%80_%EC%B6%94%EA%B0%80%EC%84%A4%EC%A0%95.md#processfbx) · [Retarget Ready](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/08_API%EC%99%80_%EC%B6%94%EA%B0%80%EC%84%A4%EC%A0%95.md#retarget-ready) · [RetargetClean](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/08_API%EC%99%80_%EC%B6%94%EA%B0%80%EC%84%A4%EC%A0%95.md#retarget-clean)

- 보충·기초와·도구이름: [Connect VARCO3D](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#connect-varco) · [Convert Character + Pick USDZ](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#pick-usdz) · [Extract Selected FBX](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#extract-fbx) · [Extract USDZ Textures Only](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#extract-textures) · [Run Extract](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#run-extract) · [Send to Unity](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#send-unity) · [VE Extract Tool](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#ve-extract)

- 프로젝트·코드·식별자: [Varco3DExtractTool](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/10_%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8_%EC%BD%94%EB%93%9C_%EC%8B%9D%EB%B3%84%EC%9E%90.md#script-varco3dextracttool) · [VARCO3DMenu](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/10_%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8_%EC%BD%94%EB%93%9C_%EC%8B%9D%EB%B3%84%EC%9E%90.md#script-varco3dmenu) · [VARCO3DUsdzImporter](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/10_%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8_%EC%BD%94%EB%93%9C_%EC%8B%9D%EB%B3%84%EC%9E%90.md#script-varco3dusdzimporter)

<!-- study-navigation -->
[이전](10_%EB%A6%AC%EA%B9%85_Avatar%EC%99%80_%EC%95%A0%EB%8B%88%EB%A9%94%EC%9D%B4%EC%85%98.md) · [목차](../README.md) · [다음](../05_%EC%BD%94%EB%93%9C%EC%99%80%EB%8F%84%EA%B5%AC/12_CSharp%EC%99%80_%EC%8B%A4%ED%96%89%ED%9D%90%EB%A6%84.md)
