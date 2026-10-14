# 용어 사전 01. PC와 · Unity

[전체 검색 색인](README.md) · [학습 목차](../README.md)

각 항목은 **뜻 → 작동 원리 또는 예 → 적용 조건** 순서입니다. 동일 개념의 한글·영문·약어는 한 항목에서 함께 찾습니다. 서로 다른 개념은 별도 항목으로 둡니다.

근거: [Unity 기본 개념](https://docs.unity3d.com/6000.0/Documentation/Manual/UnityOverview.html)

<a id="data"></a>

## 데이터 · Data

컴퓨터가 저장·계산할 수 있도록 표현한 정보입니다.

사진·위치·클릭 여부도 숫자로 기록합니다.

<a id="bit"></a>

## 비트 · Bit

0 또는 1을 담는 가장 작은 정보 단위입니다.

8비트는 256가지 조합을 표현합니다.

<a id="byte"></a>

## 바이트 · Byte

보통 8비트를 묶은 저장 크기 단위입니다.

파일 크기의 KB·MB는 바이트의 배수입니다.

<a id="file"></a>

## 파일 · File

이름을 붙여 저장한 데이터 묶음입니다.

이미지 PNG와 모델 FBX는 읽는 규칙이 다릅니다.

함께 찾기: [데이터](#data) · [FBX](03_USD와_파일형식.md#fbx) · [PNG](03_USD와_파일형식.md#png)

<a id="folder"></a>

## 폴더 · 디렉터리 · Directory · Folder

파일과 하위 폴더를 정리하는 장소입니다.

Assets 안에 Models 폴더를 둘 수 있습니다.

<a id="extension"></a>

## 확장자 · Extension

파일명 끝에서 형식의 힌트를 주는 표지입니다.

.usdc를 .usda로 바꿔도 내용은 변환되지 않습니다.

<a id="format"></a>

## 파일 형식 · File Format

파일 안 데이터를 어떤 순서와 뜻으로 기록하는지 정한 규칙입니다.

같은 3D 자료라도 FBX와 USD의 기록법은 다릅니다.

함께 찾기: [데이터](#data) · [3D](02_수학과_모델.md#3d) · [USD](03_USD와_파일형식.md#usd) · [FBX](03_USD와_파일형식.md#fbx)

<a id="text-file"></a>

## 텍스트 파일 · Text File

글자 부호 규칙을 사용해 내용을 읽고 쓸 수 있는 파일입니다.

USDA를 메모장으로 읽습니다.

함께 찾기: [USDA](03_USD와_파일형식.md#usda)

<a id="binary"></a>

## 바이너리 · Binary

일반 문장 대신 프로그램용 숫자 배치로 읽는 표현입니다.

USDC는 메모장으로 내용을 해석하기 어렵습니다. 텍스트도 실제 저장은 숫자입니다.

함께 찾기: [프로그램](#program) · [USDC](03_USD와_파일형식.md#usdc)

<a id="encoding"></a>

## 문자 인코딩 · Encoding

숫자와 글자를 대응시키는 약속입니다.

다른 인코딩으로 읽으면 한글이 깨질 수 있습니다.

<a id="utf8"></a>

## UTF-8

여러 언어의 글자를 바이트로 기록하는 문자 인코딩입니다.

이 자료와 USDA를 UTF-8로 읽습니다.

함께 찾기: [바이트](#byte) · [문자 인코딩](#encoding) · [USDA](03_USD와_파일형식.md#usda)

<a id="markdown"></a>

## Markdown · 마크다운 · md

일반 글자에 제목·표·링크 표시 규칙을 더한 문서 형식입니다.

줄 앞 #은 제목이며 .md 파일로 저장합니다.

<a id="path"></a>

## 경로 · Path

파일이나 장면 요소의 위치를 나타내는 주소입니다.

파일 경로와 뼈 계층 경로는 서로 다른 대상의 주소입니다.

<a id="absolute-path"></a>

## 절대 경로 · Absolute Path

드라이브 등 기준 위치부터 적은 전체 주소입니다.

C:/Project/Assets는 특정 PC 위치를 가리킵니다.

함께 찾기: [Project](#project)

<a id="relative-path"></a>

## 상대 경로 · Relative Path

현재 위치를 기준으로 적은 주소입니다.

../는 한 단계 위이며 문서 폴더를 통째로 옮겨도 내부 관계가 유지될 수 있습니다.

<a id="program"></a>

## 프로그램 · Program

데이터를 읽고 처리하는 명령 묶음입니다.

Unity Editor는 장면을 편집하는 프로그램입니다.

함께 찾기: [데이터](#data) · [Unity](#unity) · [Editor](#editor)

<a id="engine"></a>

## 게임 엔진 · Game Engine

화면·입력·소리·실행 등 공통 제작 기능을 제공하는 소프트웨어입니다.

Unity가 모양 자체나 게임 규칙까지 자동 제작하는 것은 아닙니다.

함께 찾기: [Unity](#unity) · [소프트웨어](09_보충_기초와_도구이름.md#software)

<a id="unity"></a>

## Unity · 유니티

이 프로젝트의 장면 편집과 실행에 사용하는 게임 엔진입니다.

프로젝트에 기록된 버전은 6000.6.0f1입니다.

함께 찾기: [게임 엔진](#engine) · [Project](#project)

<a id="hub"></a>

## Unity Hub

Unity 버전 설치와 프로젝트 목록을 관리하는 시작 프로그램입니다.

실제 물체 배치는 Editor에서 합니다.

함께 찾기: [프로그램](#program) · [Unity](#unity) · [Editor](#editor) · [Project](#project)

<a id="editor"></a>

## Editor · Unity Editor · 에디터

Unity 프로젝트를 편집하고 시험하는 제작 환경입니다.

배포한 게임의 Player와 구분합니다.

함께 찾기: [Unity](#unity) · [Player](#player) · [Project](#project)

<a id="player"></a>

## Player · 플레이어 실행 환경

빌드된 Unity 프로그램이 실행되는 환경입니다.

Project Settings의 Player 설정은 조작 캐릭터 설정이라는 뜻이 아닙니다.

함께 찾기: [프로그램](#program) · [Unity](#unity) · [Project](#project) · [Project Settings](#project-settings)

<a id="project"></a>

## Project · 프로젝트

제작에 필요한 에셋·패키지·설정 전체입니다. Project 창은 그 안의 에셋 목록을 보여 줍니다.

Hub에는 Assets·Packages·ProjectSettings가 함께 있는 루트를 등록합니다.

함께 찾기: [Package](#package) · [Project Settings](#project-settings)

<a id="asset"></a>

## Asset · 에셋

프로젝트가 저장하고 참조하는 제작 자료입니다.

이미지·모델·재질·씬이 모두 에셋일 수 있습니다.

함께 찾기: [Project](#project)

<a id="scene"></a>

## Scene · 씬

물체의 배치·관계·컴포넌트 값을 저장한 장면입니다. Scene 창은 이를 편집하는 화면입니다.

Game 화면의 카메라 시점과 Scene 편집 시점은 다릅니다.

함께 찾기: [Game](#game-view) · [Component](#component) · [Camera](09_보충_기초와_도구이름.md#camera)

<a id="game-view"></a>

## Game · Game 뷰

게임 카메라의 결과를 보는 Unity 창입니다.

Scene 시점만 돌려서는 Main Camera 구도가 바뀌지 않습니다.

함께 찾기: [Unity](#unity) · [Scene](#scene) · [Camera](09_보충_기초와_도구이름.md#camera)

<a id="hierarchy"></a>

## Hierarchy · 하이어라키 · 계층

열린 씬의 물체와 부모·자식 관계를 보여 주는 목록입니다.

파일 폴더 구조가 아니라 물체 관계입니다.

<a id="inspector"></a>

## Inspector · 인스펙터

선택한 파일 또는 물체의 값을 보는 설정 창입니다.

모델 파일 선택 시 임포트 탭, 씬 물체 선택 시 컴포넌트가 보입니다.

함께 찾기: [Component](#component) · [Import](#import)

<a id="console"></a>

## Console · 콘솔

오류·경고·로그를 표시하는 창입니다.

빨간 오류 하나를 클릭해 상세 글과 파일 위치를 읽습니다.

<a id="gameobject"></a>

## GameObject · 게임 오브젝트 · 오브젝트

씬에서 이름과 컴포넌트를 가진 대상입니다.

빈 GameObject에는 Transform은 있지만 보이는 메시가 없을 수 있습니다.

함께 찾기: [Component](#component) · [Transform](#transform)

<a id="component"></a>

## Component · 컴포넌트

GameObject에 붙는 기능 단위입니다.

Camera·Animator·직접 만든 스크립트가 예입니다.

함께 찾기: [GameObject](#gameobject) · [Animator](05_효과와_움직임과_UI.md#animator) · [Camera](09_보충_기초와_도구이름.md#camera)

<a id="transform"></a>

## Transform · 트랜스폼

위치·회전·크기와 부모 관계를 저장하는 컴포넌트입니다.

자식 Inspector 값은 보통 부모 기준입니다.

함께 찾기: [Inspector](#inspector) · [Component](#component)

<a id="instance"></a>

## Instance · 인스턴스

원본이나 정의를 바탕으로 만들어 실제로 쓰는 대상입니다.

한 프리팹을 씬에 세 번 놓으면 인스턴스 세 개입니다.

함께 찾기: [Prefab](#prefab)

<a id="reference"></a>

## Reference · 참조

다른 파일·객체를 가리키는 연결입니다.

재질이 이미지 파일을 가리킬 때 이미지 전체를 매번 복사하지 않습니다.

<a id="slot"></a>

## 슬롯 · Slot

다른 물체나 에셋을 연결하는 Inspector 입력 칸입니다.

정확한 타입의 파일을 놓으면 None 대신 이름이 표시됩니다.

함께 찾기: [Inspector](#inspector) · [None](#none)

<a id="none"></a>

## None

참조 칸에 아무 대상도 지정되지 않았다는 표시입니다.

필수 슬롯이면 올바른 대상을 연결해야 합니다.

<a id="missing"></a>

## Missing

필요한 대상이나 구성 요소를 찾을 수 없다는 표시입니다.

삭제된 스크립트·에셋 참조 등을 확인합니다.

<a id="prefab"></a>

## Prefab · 프리팹

물체·컴포넌트·자식 구성을 재사용하도록 저장한 에셋입니다.

씬 복사와 프리팹 원본 복사는 별도입니다.

함께 찾기: [Component](#component)

<a id="prefab-mode"></a>

## Prefab Mode

프리팹 원본을 편집하는 환경입니다.

여기서 저장한 변경은 사용하는 여러 인스턴스에 영향을 줄 수 있습니다.

함께 찾기: [Instance](#instance) · [Prefab](#prefab)

<a id="prefab-variant"></a>

## Prefab Variant

다른 프리팹을 바탕으로 차이만 추가한 프리팹입니다.

모든 프리팹이 Variant인 것은 아닙니다.

함께 찾기: [Prefab](#prefab) · [Variant](03_USD와_파일형식.md#variant)

<a id="override"></a>

## Override · 오버라이드

원래 값 대신 적용할 별도 지정값입니다.

프리팹 인스턴스 차이와 Volume 값 체크는 맥락이 다릅니다.

함께 찾기: [Instance](#instance) · [Prefab](#prefab) · [Volume](05_효과와_움직임과_UI.md#volume)

<a id="guid"></a>

## GUID

에셋을 구별하는 고유 식별자입니다.

.meta가 바뀌면 같은 파일명이어도 참조가 끊길 수 있습니다.

함께 찾기: [.meta](#meta)

<a id="fileid"></a>

## fileID

파일 안의 개별 객체나 하위 에셋을 구별하는 번호입니다.

GUID가 파일을, fileID가 그 안의 대상을 가리키는 참조가 있습니다.

함께 찾기: [GUID](#guid)

<a id="meta"></a>

## .meta · meta 파일

Unity의 에셋 식별자와 임포트 설정 등을 보관하는 파일입니다.

Assets 파일과 함께 보존합니다.

함께 찾기: [Unity](#unity) · [Import](#import)

<a id="import"></a>

## Import · 임포트

외부 파일을 프로그램이 쓸 데이터로 읽는 과정입니다.

완료해도 재질·움직임을 별도로 확인해야 합니다.

함께 찾기: [데이터](#data) · [프로그램](#program)

<a id="importer"></a>

## Importer · 임포터

임포트 규칙을 실행하는 도구입니다.

FBX Importer와 USD Importer의 지원 기능은 다릅니다.

함께 찾기: [Import](#import) · [USD](03_USD와_파일형식.md#usd) · [USD Importer](03_USD와_파일형식.md#usd-importer) · [FBX](03_USD와_파일형식.md#fbx)

<a id="export"></a>

## Export · 익스포트 · 내보내기

내부 데이터를 외부 파일 규칙으로 기록하는 작업입니다.

씬의 모델을 FBX로 내보냅니다.

함께 찾기: [데이터](#data) · [FBX](03_USD와_파일형식.md#fbx)

<a id="exporter"></a>

## Exporter · 익스포터

외부 형식으로 내보내는 도구입니다.

FBX Exporter가 있다고 모든 입력 USD를 해석하는 것은 아닙니다.

함께 찾기: [USD](03_USD와_파일형식.md#usd) · [FBX](03_USD와_파일형식.md#fbx) · [FBX Exporter](03_USD와_파일형식.md#fbx-exporter)

<a id="package"></a>

## Package · 패키지

설치·배포할 기능을 묶은 단위입니다.

Input System 패키지 설치만으로 이동 코드가 생기지는 않습니다.

함께 찾기: [Input System](05_효과와_움직임과_UI.md#inputsystem)

<a id="dependency"></a>

## Dependency · 의존성

어떤 기능이 동작하기 위해 필요한 다른 기능이나 파일입니다.

Bridge가 USD Importer를 요구합니다.

함께 찾기: [Importer](#importer) · [USD](03_USD와_파일형식.md#usd) · [USD Importer](03_USD와_파일형식.md#usd-importer) · [VARCO Bridge](06_코드와_통신과_검증.md#bridge)

<a id="upm"></a>

## UPM

Unity Package Manager라는 패키지 관리 체계입니다.

Packages의 요청과 해결된 패키지를 관리합니다.

함께 찾기: [Unity](#unity) · [Package](#package) · [Package Manager](#package-manager)

<a id="package-manager"></a>

## Package Manager

설치된 패키지와 버전을 보는 Unity 창입니다.

메뉴 Window의 Package Manager에서 실제 설치 상태를 확인합니다.

함께 찾기: [Unity](#unity) · [Package](#package)

<a id="manifest"></a>

## manifest.json · manifest

프로젝트가 요청한 패키지 목록 등의 설정 파일입니다.

외부 file 경로가 있으면 다른 PC에서 위치 문제가 날 수 있습니다.

함께 찾기: [Project](#project) · [Package](#package)

<a id="packages-lock"></a>

## packages-lock.json · packages-lock

실제로 해결된 패키지 버전과 의존 관계를 기록하는 파일입니다.

모든 PC의 설치 환경을 통째로 복제하는 것은 아닙니다.

함께 찾기: [Package](#package)

<a id="embedded"></a>

## Embedded Package · embedded

프로젝트 Packages 폴더 안에 소스가 포함된 패키지입니다.

현재 Bridge의 해결 방식으로 기록되어 있습니다.

함께 찾기: [Project](#project) · [Package](#package) · [VARCO Bridge](06_코드와_통신과_검증.md#bridge)

<a id="cache"></a>

## Cache · 캐시

다시 계산하거나 받을 비용을 줄이기 위한 재사용 데이터입니다.

Library는 주로 임포트된 데이터 등을 보관합니다.

함께 찾기: [데이터](#data) · [Import](#import) · [Library](#library)

<a id="library"></a>

## Library

Unity가 임포트 결과와 작업용 데이터를 관리하는 프로젝트 폴더입니다.

Assets 원본과 역할이 다르며 재생성에는 시간이 걸립니다.

함께 찾기: [데이터](#data) · [Unity](#unity) · [Project](#project) · [Import](#import)

<a id="project-settings"></a>

## Project Settings · ProjectSettings

프로젝트 전체의 입력·품질·플랫폼 등 설정입니다.

씬 복제만으로 이 설정은 분리되지 않습니다.

함께 찾기: [Project](#project) · [Platform](06_코드와_통신과_검증.md#platform)

<a id="play"></a>

## Play · 플레이 모드

Editor에서 게임 동작을 시험하는 상태입니다.

종료 시 씬 값은 대체로 돌아가지만 에셋 변경은 남을 수 있습니다.

함께 찾기: [Editor](#editor)

<a id="preview"></a>

## Preview · 프리뷰 · 미리보기

선택 에셋을 제한된 환경에서 관찰하는 기능입니다.

클립 미리보기가 실제 씬의 Animator 연결까지 검증하지는 않습니다.

함께 찾기: [Animator](05_효과와_움직임과_UI.md#animator)

<a id="dirty"></a>

## dirty · 미저장 상태

편집 내용이 저장 파일과 달라진 상태입니다.

씬 이름 옆 * 표시를 확인합니다.

<a id="undo"></a>

## Undo

지원되는 이전 편집을 취소하는 체계입니다.

파일 변환·삭제·외부 다운로드 전체를 되돌리는 백업은 아닙니다.

함께 찾기: [Download](06_코드와_통신과_검증.md#download)

<a id="active"></a>

## 활성 · Active

물체나 기능이 사용할 수 있게 켜진 상태입니다.

자식 자체가 켜져도 부모가 꺼져 있으면 함께 비활성입니다.

<a id="enabled"></a>

## Enabled

특정 컴포넌트를 켰는지 나타내는 설정입니다.

GameObject 전체 활성 조건도 따로 만족해야 합니다.

함께 찾기: [GameObject](#gameobject) · [Component](#component)

<a id="root"></a>

## Root · 루트

계층에서 기준이 되는 뿌리 또는 최상위 대상입니다.

Animator 루트·뼈 Root·씬 최상위 부모는 문맥에 따라 다릅니다.

함께 찾기: [Animator](05_효과와_움직임과_UI.md#animator)

<a id="parent"></a>

## 부모 · Parent

계층에서 자식을 포함하고 변환에 영향을 주는 대상입니다.

팔 부모를 움직이면 손 자식도 따라갑니다.

<a id="child"></a>

## 자식 · Child

다른 대상 아래에 속한 물체입니다.

Hierarchy 이름 위로 드래그하면 자식이 될 수 있습니다.

함께 찾기: [Hierarchy](#hierarchy)

<a id="layer"></a>

## Layer · 레이어 번호

Unity에서 카메라·물리 등의 처리 대상을 구분하는 물체 분류입니다.

USD Layer나 Animator Layer와 다른 체계입니다.

함께 찾기: [Unity](#unity) · [USD](03_USD와_파일형식.md#usd) · [USD Layer](03_USD와_파일형식.md#usd-layer) · [Animator](05_효과와_움직임과_UI.md#animator) · [Animator Layer](08_API와_추가설정.md#animator-layer) · [Camera](09_보충_기초와_도구이름.md#camera)

<a id="layer-mask"></a>

## Layer Mask

여러 Layer 중 처리할 것을 선택하는 필터입니다.

Volume Layer Mask는 카메라가 어느 Volume을 검사할지 정합니다.

함께 찾기: [Layer](#layer) · [Mask](04_표면과_렌더링.md#mask) · [Volume](05_효과와_움직임과_UI.md#volume) · [Camera](09_보충_기초와_도구이름.md#camera)

<a id="rendering-layer"></a>

## Rendering Layer

조명·데칼 등 렌더 영향 대상을 나누는 별도 분류입니다.

일반 GameObject Layer와 같다고 생각하면 안 됩니다.

함께 찾기: [GameObject](#gameobject) · [Layer](#layer)
