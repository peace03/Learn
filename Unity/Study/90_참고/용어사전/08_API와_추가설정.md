# 용어 사전 08. API와 · 추가설정

[전체 검색 색인](../용어_사전.md) · [학습 목차](../../README.md)

각 항목은 **뜻 → 작동 원리 또는 예 → 적용 조건** 순서입니다. 동일 개념의 한글·영문·약어는 한 항목에서 함께 찾습니다. 서로 다른 개념은 별도 항목으로 둡니다.

근거: [스크립트 색인](../스크립트_색인.md)과 [에셋·설정 근거](../에셋과설정_근거.md). 프로젝트 전용 함수는 소스의 역할을 적었습니다.

<a id="assetdatabase"></a>

## AssetDatabase

Unity Editor에서 에셋을 찾고 읽고 저장·임포트하는 API입니다.

일반 Player 코드와 분리합니다.

함께 찾기: [Unity](01_PC%EC%99%80_Unity.md#unity) · [Editor](01_PC%EC%99%80_Unity.md#editor) · [Player](01_PC%EC%99%80_Unity.md#player) · [Import](01_PC%EC%99%80_Unity.md#import) · [API](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#api)

<a id="editorapplication"></a>

## EditorApplication

Editor 갱신·종료 등 편집기 동작에 접근하는 API입니다.

Bridge는 update에서 큐를 처리합니다.

함께 찾기: [Editor](01_PC%EC%99%80_Unity.md#editor) · [API](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#api) · [VARCO Bridge](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#bridge)

<a id="editor-update"></a>

## EditorApplication.update

Editor가 갱신할 때 등록한 함수를 실행하는 이벤트입니다.

게임의 MonoBehaviour.Update와 다릅니다.

함께 찾기: [Editor](01_PC%EC%99%80_Unity.md#editor) · [MonoBehaviour](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#monobehaviour) · [Update](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#update) · [Event](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#event)

<a id="delaycall"></a>

## delayCall

Editor가 이후 적절한 갱신 시점에 작업을 실행하도록 예약하는 콜백입니다.

USDZ 임포트 뒤 배치와 Animator 구성을 미룹니다.

함께 찾기: [Editor](01_PC%EC%99%80_Unity.md#editor) · [Import](01_PC%EC%99%80_Unity.md#import) · [USDZ](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usdz) · [Animator](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#animator)

<a id="selection"></a>

## Selection

현재 Editor에서 선택한 대상에 접근하는 API입니다.

선택 하나와 여러 선택 목록을 구분합니다.

함께 찾기: [Editor](01_PC%EC%99%80_Unity.md#editor) · [API](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#api)

<a id="activetransform"></a>

## activeTransform

여러 선택 중 현재 활성 선택의 Transform입니다.

프로젝트 Transform 도구는 이 대상 하나만 처리합니다.

함께 찾기: [Project](01_PC%EC%99%80_Unity.md#project) · [Transform](01_PC%EC%99%80_Unity.md#transform)

<a id="localposition"></a>

## localPosition

부모 기준 위치를 나타내는 Transform 속성입니다.

transform.position은 월드 위치입니다.

함께 찾기: [Transform](01_PC%EC%99%80_Unity.md#transform) · [transform.position](08_API%EC%99%80_%EC%B6%94%EA%B0%80%EC%84%A4%EC%A0%95.md#transform-position)

<a id="transform-position"></a>

## transform.position

Transform의 월드 위치 속성입니다.

Inspector의 부모 기준 Position과 다를 수 있습니다.

함께 찾기: [Inspector](01_PC%EC%99%80_Unity.md#inspector) · [Transform](01_PC%EC%99%80_Unity.md#transform) · [Position](02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#position)

<a id="localrotation"></a>

## localRotation

부모 기준 회전을 나타내는 Transform 속성입니다.

부모의 회전과 합쳐 월드 방향이 됩니다.

함께 찾기: [Transform](01_PC%EC%99%80_Unity.md#transform)

<a id="localscale"></a>

## localScale

부모 기준 축별 크기 배율입니다.

부모가 확대되면 실제 월드 크기도 함께 영향을 받습니다.

<a id="rotate"></a>

## Rotate

Transform을 지정한 회전량만큼 돌리는 메서드입니다.

기본 호출은 자기 기준 축을 사용합니다.

함께 찾기: [Transform](01_PC%EC%99%80_Unity.md#transform) · [메서드](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#method)

<a id="getcomponent"></a>

## GetComponent

GameObject에 붙은 특정 컴포넌트를 찾는 메서드입니다.

찾는 기능이 없으면 결과가 없는 경우를 처리해야 합니다.

함께 찾기: [GameObject](01_PC%EC%99%80_Unity.md#gameobject) · [Component](01_PC%EC%99%80_Unity.md#component) · [메서드](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#method)

<a id="setactive"></a>

## SetActive

GameObject를 켜거나 끄는 메서드입니다.

부모가 꺼져 있으면 자식을 켜도 씬에서 활성화되지 않습니다.

함께 찾기: [GameObject](01_PC%EC%99%80_Unity.md#gameobject) · [메서드](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#method)

<a id="quit"></a>

## Application.Quit · Quit

빌드된 프로그램의 종료를 요청하는 API입니다.

Editor에서 Play 종료 버튼을 대신하지 않습니다.

함께 찾기: [프로그램](01_PC%EC%99%80_Unity.md#program) · [Editor](01_PC%EC%99%80_Unity.md#editor) · [Play](01_PC%EC%99%80_Unity.md#play) · [API](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#api)

<a id="openurl"></a>

## Application.OpenURL

지정 주소를 해당 앱이나 브라우저로 여는 API입니다.

프로젝트 Btn_Close는 이 동작을 먼저 할 수 있습니다.

함께 찾기: [Project](01_PC%EC%99%80_Unity.md#project) · [API](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#api) · [Btn_Close](08_API%EC%99%80_%EC%B6%94%EA%B0%80%EC%84%A4%EC%A0%95.md#btnclose)

<a id="nextpost"></a>

## NextPost

Lab_PostSelection에서 다음 물체로 선택을 바꾸는 함수입니다.

On Click에 씬의 실제 컴포넌트를 연결합니다.

함께 찾기: [Component](01_PC%EC%99%80_Unity.md#component) · [On Click](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#onclick) · [Lab_PostSelection](10_%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8_%EC%BD%94%EB%93%9C_%EC%8B%9D%EB%B3%84%EC%9E%90.md#script-lab_postselection)

<a id="previouspost"></a>

## PreviousPost

Lab_PostSelection에서 이전 물체로 선택을 바꾸는 함수입니다.

0에서 마지막으로 돌아가도록 나머지 연산을 사용합니다.

함께 찾기: [나머지 연산](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#remainder) · [Lab_PostSelection](10_%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8_%EC%BD%94%EB%93%9C_%EC%8B%9D%EB%B3%84%EC%9E%90.md#script-lab_postselection)

<a id="btnclose"></a>

## Btn_Close

프로젝트 Lab_Exit의 종료 버튼용 함수 이름입니다.

Btn_Ads로 외부 주소를 연 뒤 Quit를 호출합니다.

함께 찾기: [Project](01_PC%EC%99%80_Unity.md#project) · [Application.Quit](08_API%EC%99%80_%EC%B6%94%EA%B0%80%EC%84%A4%EC%A0%95.md#quit) · [Btn_Ads](08_API%EC%99%80_%EC%B6%94%EA%B0%80%EC%84%A4%EC%A0%95.md#btnads) · [Lab_Exit](10_%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8_%EC%BD%94%EB%93%9C_%EC%8B%9D%EB%B3%84%EC%9E%90.md#script-lab_exit)

<a id="btnads"></a>

## Btn_Ads

프로젝트 Lab_Exit에서 작성자의 ArtStation 주소를 여는 함수입니다.

이름만 보고 순수 종료 작업으로 간주하지 않습니다.

함께 찾기: [Project](01_PC%EC%99%80_Unity.md#project) · [Lab_Exit](10_%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8_%EC%BD%94%EB%93%9C_%EC%8B%9D%EB%B3%84%EC%9E%90.md#script-lab_exit)

<a id="ziparchive"></a>

## ZipArchive

.NET에서 ZIP 항목을 읽고 쓰는 API입니다.

현재 ExtractTool은 첫 .usda와 이미지 항목을 꺼냅니다.

함께 찾기: [ZIP](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#zip) · [API](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#api)

<a id="runselection"></a>

## RunFromCurrentSelection

현재 선택 종류에 따라 변환 경로를 정하는 프로젝트 함수입니다.

FBX·USDZ·Hierarchy 선택을 다르게 처리합니다.

함께 찾기: [Project](01_PC%EC%99%80_Unity.md#project) · [Hierarchy](01_PC%EC%99%80_Unity.md#hierarchy) · [USDZ](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usdz) · [FBX](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#fbx)

<a id="convertusdz"></a>

## ConvertUsdZ

USDZ와 캐릭터를 바탕으로 변환을 진행하는 프로젝트 함수입니다.

입력 구조와 .usda 지원 제한이 있습니다.

함께 찾기: [Project](01_PC%EC%99%80_Unity.md#project) · [USDZ](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usdz)

<a id="extractusd"></a>

## ExtractUsdTextAndTextures

USDZ 안의 텍스트 장면과 이미지 추출을 담당하는 프로젝트 함수입니다.

Textures Only 경로도 USDA 읽기를 요구합니다.

함께 찾기: [Project](01_PC%EC%99%80_Unity.md#project) · [USDA](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usda) · [USDZ](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usdz)

<a id="processfbx"></a>

## ProcessFbx

선택하거나 생성한 FBX의 재질·텍스처·프리팹 처리를 하는 함수입니다.

이 함수 자체가 Controller나 Humanoid 매핑을 항상 만드는 것은 아닙니다.

함께 찾기: [Prefab](01_PC%EC%99%80_Unity.md#prefab) · [FBX](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#fbx) · [Texture](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#texture) · [Animator Controller](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#controller) · [Humanoid](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#humanoid)

<a id="applytextures"></a>

## ApplyTextures

찾은 텍스처를 재질 속성에 연결하는 프로젝트 함수입니다.

현재 ORM 채널을 URP 규칙으로 재배치하지 않습니다.

함께 찾기: [Project](01_PC%EC%99%80_Unity.md#project) · [Texture](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#texture) · [ORM](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#orm) · [URP](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#urp)

<a id="rootclean"></a>

## CreateRootHeightCleanClip

추정 Root의 Y 곡선을 기준 높이로 보정하는 프로젝트 함수입니다.

정상적인 점프 동작도 지울 수 있어 모든 클립에 좋은 보정은 아닙니다.

함께 찾기: [Project](01_PC%EC%99%80_Unity.md#project) · [Root](01_PC%EC%99%80_Unity.md#root)

<a id="loopblend"></a>

## BlendLoopBoundary

클립 끝부분을 시작값 쪽으로 섞는 프로젝트 함수입니다.

발 접지·속도 연속성까지 이해하는 보정은 아닙니다.

함께 찾기: [Project](01_PC%EC%99%80_Unity.md#project)

<a id="buildclip"></a>

## BuildAnimationClip

USDA 값에서 Unity 애니메이션 곡선을 직접 만드는 대체 경로 함수입니다.

기존 클립 복사 경로와 보정 절차가 다릅니다.

함께 찾기: [Unity](01_PC%EC%99%80_Unity.md#unity) · [USDA](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usda) · [Animation](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#animation)

<a id="configurefbx"></a>

## ConfigureFbxImporter

내보낸 FBX의 임포트 설정 등을 적용하는 프로젝트 함수입니다.

수정한 설정과 실제 Avatar 유효성을 별도로 봅니다.

함께 찾기: [Project](01_PC%EC%99%80_Unity.md#project) · [Import](01_PC%EC%99%80_Unity.md#import) · [FBX](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#fbx) · [Avatar](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#avatar)

<a id="findexporter"></a>

## TryFindFbxExporter

설치 패키지의 FBX 내보내기 기능을 찾는 프로젝트 함수입니다.

C# Reflection으로 타입·메서드를 찾습니다.

함께 찾기: [Project](01_PC%EC%99%80_Unity.md#project) · [Export](01_PC%EC%99%80_Unity.md#export) · [Package](01_PC%EC%99%80_Unity.md#package) · [FBX](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#fbx) · [C#](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#csharp) · [메서드](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#method) · [C# Reflection](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#reflection-code)

<a id="exportobject"></a>

## ModelExporter.ExportObject

FBX Exporter의 대상 내보내기 API입니다.

원본과 임시 복제본 중 무엇을 넘기는지 중요합니다.

함께 찾기: [Export](01_PC%EC%99%80_Unity.md#export) · [Exporter](01_PC%EC%99%80_Unity.md#exporter) · [FBX](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#fbx) · [FBX Exporter](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#fbx-exporter) · [API](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#api)

<a id="pumpqueue"></a>

## PumpImportQueue

Bridge의 완료 작업 큐에서 임포트할 일을 꺼내는 함수입니다.

Editor 갱신마다 한 건을 처리합니다.

함께 찾기: [Editor](01_PC%EC%99%80_Unity.md#editor) · [Import](01_PC%EC%99%80_Unity.md#import) · [VARCO Bridge](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#bridge)

<a id="processimport"></a>

## ProcessImport

Bridge에서 받은 형식에 따라 적절한 임포터로 분배하는 함수입니다.

ExtractTool의 변환 버튼과 별도 경로입니다.

함께 찾기: [Importer](01_PC%EC%99%80_Unity.md#importer) · [VARCO Bridge](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#bridge)

<a id="importtask"></a>

## ImportTask

Bridge 큐에서 처리할 가져오기 작업 자료형입니다.

다운로드 결과를 메인 스레드로 넘기는 데 씁니다.

함께 찾기: [자료형](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#type) · [Thread](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#thread) · [메인 스레드](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#main-thread) · [Download](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#download) · [VARCO Bridge](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#bridge)

<a id="importrequest"></a>

## ImportRequest

Bridge가 받은 가져오기 요청의 데이터 구조입니다.

요청을 받았다는 사실과 완료 결과는 다릅니다.

함께 찾기: [데이터](01_PC%EC%99%80_Unity.md#data) · [VARCO Bridge](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#bridge)

<a id="materialdef"></a>

## MaterialDef

Bridge 요청·메타데이터에서 재질 정보를 담는 자료형입니다.

Unity Material 에셋 자체와 같은 객체는 아닙니다.

함께 찾기: [데이터](01_PC%EC%99%80_Unity.md#data) · [Unity](01_PC%EC%99%80_Unity.md#unity) · [Metadata](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#metadata) · [Material](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#material) · [자료형](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#type) · [VARCO Bridge](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#bridge)

<a id="begin-camera"></a>

## beginCameraRendering

렌더 파이프라인이 카메라를 그리기 전에 알리는 이벤트입니다.

UVC_Reflections가 반사 렌더 준비에 사용합니다.

함께 찾기: [Render Pipeline](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#pipeline) · [Event](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#event) · [Camera](09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#camera) · [UVC_Reflections](10_%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8_%EC%BD%94%EB%93%9C_%EC%8B%9D%EB%B3%84%EC%9E%90.md#script-uvc_reflections)

<a id="renderrequest"></a>

## RenderRequest

파이프라인에 특정 카메라 렌더 작업을 요청하는 방식입니다.

해당 파이프라인의 지원 여부를 확인해야 합니다.

함께 찾기: [Camera](09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#camera)

<a id="executemenu"></a>

## ExecuteMenuItem

Unity Editor 메뉴 경로를 코드에서 실행하는 API입니다.

그 Unity 버전에 메뉴가 존재해야 성공합니다.

함께 찾기: [Unity](01_PC%EC%99%80_Unity.md#unity) · [Editor](01_PC%EC%99%80_Unity.md#editor) · [API](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#api)

<a id="genericmenu"></a>

## GenericMenu

Editor에서 항목을 고르는 메뉴를 만드는 API입니다.

CreatePrimitiveDropdown 코드의 메뉴 구성에 쓰입니다.

함께 찾기: [Editor](01_PC%EC%99%80_Unity.md#editor) · [API](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#api) · [CreatePrimitiveDropdown](10_%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8_%EC%BD%94%EB%93%9C_%EC%8B%9D%EB%B3%84%EC%9E%90.md#script-createprimitivedropdown)

<a id="toolbaroverlay"></a>

## ToolbarOverlay

Editor 오버레이에 툴바 버튼들을 넣는 기반 기능입니다.

등록한 버튼 ID 목록이 실제 표시 구성을 정합니다.

함께 찾기: [Editor](01_PC%EC%99%80_Unity.md#editor) · [Overlay](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#overlay)

<a id="decal-scaler"></a>

## DecalScaler

Lab_DecalScaler.cs 안에 정의된 실제 클래스 이름입니다.

파일명과 일치하지 않으므로 부착 문제를 확인해야 합니다.

함께 찾기: [.cs](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#cs-file) · [class](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#class) · [Lab_DecalScaler](10_%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8_%EC%BD%94%EB%93%9C_%EC%8B%9D%EB%B3%84%EC%9E%90.md#script-lab_decalscaler)

<a id="retarget-ready"></a>

## Retarget Ready

프로젝트 도구가 자체 조건으로 내는 리타기팅 준비 판정입니다.

True가 외관·발 접지·빌드까지 인증하지 않습니다.

함께 찾기: [Project](01_PC%EC%99%80_Unity.md#project) · [Retargeting](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#retarget)

<a id="bound-joints"></a>

## Bound joints · boundJointCount

클립 경로와 선택 뼈 계층이 맞는 항목 수를 나타내는 도구 값입니다.

일부 경로 일치가 모든 뼈의 정상 변형을 증명하지는 않습니다.

<a id="avatar-valid"></a>

## Avatar Valid

Unity Avatar 검사에서 유효하다고 나온 상태입니다.

자연스러운 동작·발 미끄러짐은 별도 확인입니다.

함께 찾기: [Unity](01_PC%EC%99%80_Unity.md#unity) · [Avatar](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#avatar)

<a id="retarget-clean"></a>

## RetargetClean

프로젝트 변환기가 만든 보정 클립 이름에 쓰는 표기입니다.

현재 독립 클립은 Legacy이며 무조건 Animator용 정답이 아닙니다.

함께 찾기: [Project](01_PC%EC%99%80_Unity.md#project) · [Animator](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#animator) · [Legacy Animation](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#legacy)

<a id="metallicglossmap"></a>

## _MetallicGlossMap

URP/Lit의 금속성·매끈함 지도 관련 셰이더 속성 이름입니다.

현재 ORM을 그대로 넣으면 채널 뜻이 맞지 않습니다.

함께 찾기: [Shader](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#shader) · [Metallic](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#metallic) · [Smoothness](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#smoothness) · [ORM](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#orm) · [URP](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#urp) · [Lit](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#lit)

<a id="occlusionmap-code"></a>

## _OcclusionMap

URP/Lit의 차폐 지도 셰이더 속성 이름입니다.

해당 셰이더가 읽는 채널을 맞춰야 합니다.

함께 찾기: [Shader](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#shader) · [URP](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#urp) · [Lit](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#lit)

<a id="planar-texture"></a>

## _PlanarReflectionTexture

프로젝트 평면 반사 코드가 공유하는 전역 텍스처 이름입니다.

여러 반사면이 같은 이름을 사용하면 서로 영향을 줄 수 있습니다.

함께 찾기: [Project](01_PC%EC%99%80_Unity.md#project) · [Texture](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#texture) · [Planar Reflection](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#planar-reflection)

<a id="hlsl"></a>

## HLSL

GPU 셰이더의 계산을 작성하는 언어입니다.

Shader Graph와 달리 소스 코드로 계산을 읽습니다.

함께 찾기: [Shader](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#shader) · [Shader Graph](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#shader-graph) · [소스 코드](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#source) · [GPU](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#gpu)

<a id="clip-function"></a>

## clip()

셰이더에서 조건에 따라 표면 조각을 버리는 함수입니다.

프로젝트 _alphaClip 이름만으로 이 함수가 호출된다고 판단하면 안 됩니다.

함께 찾기: [Project](01_PC%EC%99%80_Unity.md#project) · [Shader](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#shader) · [_alphaClip](09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#alpha-clip-name)

<a id="zwrite"></a>

## ZWrite

셰이더가 깊이 버퍼에 값을 기록할지 정하는 설정입니다.

투명 합성과 앞뒤 가림에 영향을 줍니다.

함께 찾기: [Shader](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#shader) · [Depth Buffer](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#depth-buffer)

<a id="cull-off"></a>

## Cull Off

일반적인 앞뒤 면 제외를 끄는 셰이더 설정입니다.

양면이 그려져도 조명 방향이 자동으로 완벽해지는 것은 아닙니다.

함께 찾기: [Shader](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#shader)

<a id="timeline"></a>

## Timeline

시간 선에 클립과 이벤트를 배치해 연출을 구성하는 Unity 도구입니다.

설치만으로 현재 씬에서 사용한다는 뜻은 아닙니다.

함께 찾기: [Unity](01_PC%EC%99%80_Unity.md#unity) · [Event](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#event)

<a id="visual-scripting"></a>

## Visual Scripting

노드 연결로 동작을 구성하는 Unity 도구입니다.

Shader Graph의 표면 계산과 목적이 다릅니다.

함께 찾기: [Unity](01_PC%EC%99%80_Unity.md#unity) · [Shader](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#shader) · [Shader Graph](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#shader-graph)

<a id="ai-navigation"></a>

## AI Navigation

이동 가능한 공간과 경로 탐색 등을 다루는 Unity 패키지입니다.

현재 프로젝트의 실제 이동 AI 구현을 입증하지 않습니다.

함께 찾기: [Unity](01_PC%EC%99%80_Unity.md#unity) · [Project](01_PC%EC%99%80_Unity.md#project) · [Package](01_PC%EC%99%80_Unity.md#package)

<a id="multiplayer-center"></a>

## Multiplayer Center

멀티플레이 관련 도구·서비스 선택을 돕는 Unity 기능입니다.

설치만으로 네트워크 게임이 구현되지는 않습니다.

함께 찾기: [Unity](01_PC%EC%99%80_Unity.md#unity)

<a id="test-framework"></a>

## Test Framework

Unity 테스트를 작성·실행하는 도구 묶음입니다.

패키지는 있지만 자체 테스트가 확인됐다는 뜻은 아닙니다.

함께 찾기: [Unity](01_PC%EC%99%80_Unity.md#unity) · [Package](01_PC%EC%99%80_Unity.md#package)

<a id="di"></a>

## DI · Dependency Injection

필요한 객체를 내부에서 직접 만들기보다 외부에서 전달하는 설계 방식입니다.

이 프로젝트에서 이를 사용한다고 추정하지 않습니다.

함께 찾기: [Project](01_PC%EC%99%80_Unity.md#project)

<a id="ecs"></a>

## ECS · Entity Component System

대상·데이터·처리를 나누어 구성하는 소프트웨어 구조입니다.

일반 GameObject 컴포넌트 구성을 곧 ECS라고 부르지 않습니다.

함께 찾기: [데이터](01_PC%EC%99%80_Unity.md#data) · [GameObject](01_PC%EC%99%80_Unity.md#gameobject) · [Component](01_PC%EC%99%80_Unity.md#component) · [소프트웨어](09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#software)

<a id="scenemanager"></a>

## SceneManager

Unity에서 씬을 불러오고 관리하는 API입니다.

현재 별도 게임 시작 로딩 코드가 확인된 것은 아닙니다.

함께 찾기: [Unity](01_PC%EC%99%80_Unity.md#unity) · [API](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#api)

<a id="shader-precision"></a>

## 정밀도 · Precision

수치 표현이 구분할 수 있는 세밀함입니다.

float와 double의 차이, 그림자 오차 등을 이해하는 데 필요합니다.

함께 찾기: [float](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#float) · [double](06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#double)

<a id="global-value"></a>

## 전역 값 · Global Value

여러 대상에서 공유하는 범위의 값입니다.

전역 반사 텍스처 하나를 여러 거울이 쓰면 독립적이지 않습니다.

함께 찾기: [Texture](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#texture)

<a id="animator-layer"></a>

## Animator Layer

Animator에서 동작 상태들을 나누어 섞는 층입니다.

GameObject Layer 번호나 USD Layer와 다른 기능입니다.

함께 찾기: [GameObject](01_PC%EC%99%80_Unity.md#gameobject) · [Layer](01_PC%EC%99%80_Unity.md#layer) · [USD](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd) · [USD Layer](03_USD%EC%99%80_%ED%8C%8C%EC%9D%BC%ED%98%95%EC%8B%9D.md#usd-layer) · [Animator](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#animator)

<a id="rendering-path"></a>

## Rendering Path

조명과 표면 그리기를 조직하는 렌더 경로 선택입니다.

현재 설정은 PC Forward+, Mobile Forward입니다.

함께 찾기: [Forward](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#forward) · [Forward+](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#forwardplus)

<a id="color-curves"></a>

## ColorCurves · Color Curves

색·밝기의 입력과 출력 관계를 곡선으로 조절하는 후처리입니다.

프로필에 저장된 이름과 현재 활성 효과를 구분합니다.

함께 찾기: [Post Processing](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#postprocessing) · [Volume Profile](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#profile)

<a id="channel-mixer"></a>

## ChannelMixer · Channel Mixer

색 출력 채널에 각 입력 채널을 어느 비율로 넣을지 정하는 색 보정입니다.

ORM 포장 원리와 달리 화면 색 보정 문맥입니다.

함께 찾기: [ORM](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#orm)

<a id="depth-of-field"></a>

## DepthOfField · Depth of Field · 피사계 심도

초점 거리에서 벗어난 부분의 흐림을 표현하는 효과입니다.

Motion Blur와 원인이 다릅니다.

함께 찾기: [Motion Blur](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#motionblur) · [Motion](07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#motion)

<a id="film-grain"></a>

## FilmGrain · Film Grain

필름 알갱이 같은 미세한 잡음을 더하는 효과입니다.

텍스처 해상도가 낮다는 의미는 아닙니다.

함께 찾기: [Resolution](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#resolution) · [Texture](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#texture)

<a id="lens-distortion"></a>

## LensDistortion · Lens Distortion

렌즈처럼 화면 위치가 휘어지는 왜곡 효과입니다.

모델 메시를 실제로 구부리는 것은 아닙니다.

<a id="chromatic"></a>

## ChromaticAberration · Chromatic Aberration · 색수차

색 성분별 위치 차이처럼 보이는 렌즈 효과입니다.

과하면 가장자리 색이 갈라져 보입니다.

<a id="panini"></a>

## PaniniProjection · Panini Projection

넓은 시야각의 화면 왜곡을 조절하는 투영 보정입니다.

현재 사용 중이라는 뜻은 아니며 프로필 항목을 읽을 때 참고합니다.

함께 찾기: [Field of View](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#fov) · [Volume Profile](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#profile)

<a id="split-toning"></a>

## SplitToning · Split Toning

어두운 부분과 밝은 부분에 다른 색조를 주는 보정입니다.

전체 색온도 하나를 바꾸는 것과 다릅니다.

함께 찾기: [Color Temperature](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#color-temperature)

<a id="shadows-tones"></a>

## ShadowsMidtonesHighlights

어두운·중간·밝은 범위별로 색을 조절하는 효과 이름입니다.

세 범위의 영향은 설정에 따라 섞입니다.

<a id="screen-flare"></a>

## ScreenSpaceLensFlare

화면 정보를 이용해 렌즈 빛 번짐·광채를 표현하는 효과입니다.

물리 광원이나 Bloom과 같은 설정이 아닙니다.

함께 찾기: [Bloom](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#bloom)

<a id="probe-options"></a>

## ProbeVolumesOptions

프로브 기반 조명 사용에 관한 옵션을 담는 Volume 항목입니다.

설정 존재와 해당 프로브 데이터의 실제 사용은 구분합니다.

함께 찾기: [데이터](01_PC%EC%99%80_Unity.md#data) · [Probe](04_%ED%91%9C%EB%A9%B4%EA%B3%BC_%EB%A0%8C%EB%8D%94%EB%A7%81.md#probe) · [Volume](05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#volume)
