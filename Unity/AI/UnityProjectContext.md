# Unity 프로젝트 기술 요약

<!-- unity-onboarding:generated:start -->

## 목적과 기준

VARCO 모델의 재질·조명·반사·애니메이션을 확인하는 URP 실습실이며, 전용 Editor 도구와 USDZ→FBX 변환 코드가 포함되어 있습니다. 이 목적 해석은 파일 구성과 코드에 근거합니다.

- 프로젝트 루트: `C:/KNDA_NCAI/UnityProject/Learning/261007 NC강사님/Unity6.6_URPVarco`.
- 분석일: 2026-10-07.
- Git: 현재 폴더에서 `git rev-parse --show-toplevel` 실패. 분석 커밋 없음.
- 전체 학습 자료: [Study/README](../Study/README.md).

## 환경: 파일 확인

| 항목 | 결과 | 근거 |
|---|---|---|
| Editor | 6000.6.0f1, revision f7f8ed4d1e24 | ProjectVersion.txt |
| 렌더 | URP 17.6.0, Linear | manifest·Graphics·Player Settings |
| 품질 | 현재 저장 PC, PC Forward+, Mobile Forward | QualitySettings·Renderer assets·URP enum |
| 입력 | Input System 1.20.0, activeInputHandler=1 | manifest·ProjectSettings.asset |
| UI | uGUI 2.6.0, TMP 컴포넌트 | manifest·스튜디오 프리팹 |
| VFX | VFX Graph 17.6.0, FloatingDust | manifest·씬·vfx |
| 변환 | FBX Exporter 5.1.6 | manifest·Varco3DExtractTool |
| Bridge | embedded 1.1.0, USD Importer 1.0.0-pre.2 의존 | package.json·lock |
| 테스트 | Test Framework 1.8.0, 자체 테스트 파일 없음 | manifest·Assets/Packages 검색 |
| 네트워크 게임 | 확인되지 않음 | 작성된 게임 코드 범위 |
| 플랫폼 | PC/Mobile 품질 구성. 실제 활성 Build Profile 미조회 | QualitySettings |

Bridge manifest에는 외부 절대경로가 남아 있고 lock에는 embedded로 해결되어 있습니다. 코드 수정 없이 현재 상태만 기록했습니다. Navigation·Timeline·Visual Scripting·Multiplayer Center 설치를 해당 게임 기능의 구현으로 해석하지 않습니다.

## 구조와 어셈블리

- `Assets/VARCO_URP`: 모델·재질·스튜디오 프리팹·씬·Editor 도구·스크립트·렌더 설정·셰이더.
- `Assets/VARCO3DImports`: Bridge 입력. Walk USDZ와 Controller.
- `Assets/VARCO_Converted`: Walk·Run의 FBX·재질·텍스처·중간 클립·프리팹.
- Assets C# 25개, Bridge C# 7개. 상세: [스크립트 색인](../Study/90_참고/스크립트_색인.md).
- Assets 자체 asmdef 없음. 기본 Assembly-CSharp에 포함되는 구조.
- `VARCO3DBridge.Editor.asmdef`: Editor 전용, root namespace `NCAI.VARCO3D.Bridge`, unsafe 끔, 명시 assembly reference 없음.

## 씬과 시작 흐름

- 기본 빌드 목록: `Assets/VARCO_URP/04.Scenes/SampleScene.unity` 하나 활성.
- 주 실습 씬: `Lab_Varco3D_01.unity`.
- 별도 SceneManager 로딩·게임 부팅 관리 코드 확인되지 않음.
- 스튜디오의 조명·Volume·Probe, Main Camera의 UVC_Reflections, FloatingDust가 핵심.
- 처음 조사 때 Walk 중심 구성이었으나 작성 중 씬 변경을 감지. 재확인 시 Chibi Robot·Decal Projector·Sphere들이 있고 Walk는 비활성 Override. 상세 상태는 [에셋·설정 근거](../Study/90_참고/에셋과설정_근거.md) 참고.

## 동작 구조와 관례

컴포넌트를 Inspector에서 연결하는 구조입니다. Lab_Canvas의 UI·회전 코드는 저장된 씬·프리팹에서 연결이 확인되지 않아 직접 연결 실습으로 설명했습니다. 반사 코드는 렌더 이벤트를 구독하며 임시 카메라·RenderTexture를 관리합니다.

변환기는 static 메서드 중심의 단일 도구 파일입니다. Bridge는 백그라운드 다운로드 → 큐 → Editor 메인 스레드 임포트 구조입니다. DI·ECS·서비스 계층 등 별도 게임 아키텍처를 추정하지 않습니다.

네임스페이스·들여쓰기·public/SerializeField 사용이 파일별로 섞여 있습니다. 하나의 엄격한 코드 스타일이 있다고 일반화하지 않습니다.

## 중요한 한계

- `05.Editor`는 특수 폴더 `Editor`가 아님. Assets Editor 코드 다수에 Player 빌드 제외 경계가 없음.
- Walk FBX는 Generic/No Avatar, Runing FBX는 Humanoid/Create From This Model. 재생·Avatar 유효성은 Editor 확인 필요.
- 변환 도구의 기존 출력 삭제·재생성은 참조 GUID에 영향을 줄 수 있음.
- 전용 변환기는 텍스트 USDA·SkelAnimation 전제. 범용 USD 변환기가 아님.
- 원본 Walk ORM은 R=AO, G=Roughness, B=Metallic. 전용 변환기는 URP/Lit 채널 재배치를 하지 않음.
- 모든 Material 슬롯을 한 재질로 대체하는 경로가 있음.
- 평면 반사는 공유 static 카메라·전역 텍스처를 사용. 임의 다중 반사면을 보장하지 않음.
- Lab_DecalScaler 파일명과 DecalScaler 클래스명이 다름.
- Lab_Exit의 Close는 URL 열기 뒤 Quit 호출.
- 스튜디오 프리팹의 해석되지 않는 기본 Volume Profile 참조는 주 씬에서 Lab_Studio 프로필로 Override됨.

## 도구와 검증 범위

이번 세션에서 호출 가능한 Unity Editor MCP 도구는 발견되지 않았습니다. 연결·Console·현재 열린 씬·dirty 상태는 확인하지 않았습니다. VARCO Bridge는 Unity 제어용 MCP가 아닙니다. 새 연결 패키지를 설치하지 않았습니다.

소스·직렬화 파일·GUID 참조·USDZ 내부 텍스트·패키지 구현·공식 문서를 조사했습니다. Editor 컴파일·재임포트·Play·변환·빌드·성능 측정은 실행하지 않았습니다. 학습 문서만 작성했습니다.

주요 근거: ProjectVersion, manifest, packages-lock, EditorBuildSettings, GraphicsSettings, QualitySettings, ProjectSettings, 두 씬, 스튜디오 프리팹, FBX meta, Controller, 애니메이션 파일, 전체 작성 스크립트 색인, 관련 셰이더·프로필. [검증 기록](../Study/90_참고/검증기록.md).

<!-- unity-onboarding:generated:end -->
