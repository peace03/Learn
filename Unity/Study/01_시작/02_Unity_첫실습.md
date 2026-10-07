# 02. Unity 첫 실습

> 모르는 단어는 [전문 용어 전체 색인](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4_%EC%82%AC%EC%A0%84.md)에서 영문·한글로 찾습니다. 이 장 맨 아래에는 등장 용어의 바로가기 목록이 있습니다.

## 시작 조건과 조작 확인

준비 A의 파일·경로·슬롯을 먼저 읽고 Unity Editor를 엽니다. 이 장에서 **루트**는 부모가 없는 최상위 물체, **활성**은 해당 물체를 사용할 수 있도록 켠 상태입니다. Hierarchy 왼쪽 삼각형은 자식 목록 펼치기이고, Inspector 맨 위 이름 왼쪽 체크는 물체 활성입니다. 둘을 혼동하지 않습니다.

씬 이름 뒤 `*`는 저장하지 않은 변경이 있다는 표시입니다. 숫자를 바꾸고 Enter → Scene/Game에서 결과 확인 → Ctrl+S 순서로 합니다. 새로 만든 씬 파일은 Project 창에 남고, 배치한 큐브는 Hierarchy에 보이면 맞습니다.

모델이 작거나 보이지 않을 때 마우스로 오래 찾지 말고 Hierarchy에서 대상을 고른 뒤 Scene 창 위에 마우스를 놓고 F를 누릅니다. Scene의 2D 버튼이 켜져 있다면 3D 관찰을 위해 끕니다. 창 자체가 없다면 아래 메뉴로 다시 엽니다.

목표: 원본을 보존하면서 실습 씬을 열고, 물체 하나를 배치하고, 실행과 편집을 구분합니다.

## 화면 여섯 곳

| 창 | 쉬운 뜻 | 하는 일 |
|---|---|---|
| Project | 부품 창고 | 파일·폴더·모델·재질 찾기 |
| Hierarchy | 지금 무대에 올라온 물체 목록 | 씬 오브젝트 선택 |
| Inspector | 선택한 것의 설정표 | 위치·재질·컴포넌트 수정 |
| Scene | 작업자가 돌아다니는 작업 화면 | 배치·편집 |
| Game | 실제 카메라의 화면 | 실행 결과 확인 |
| Console | 문제와 기록을 보여 주는 창 | 오류·경고·로그 읽기 |

창이 없으면 `Window > General`에서 `Hierarchy`, `Project`, `Inspector`, `Console`을 찾습니다. Scene·Game 탭도 이 메뉴에서 열 수 있습니다. 배치가 달라도 창의 역할은 같습니다.

## 1. 프로젝트 열기

1. Unity Hub에서 `Add` 또는 `Add project from disk`를 누릅니다.
2. `Assets`, `Packages`, `ProjectSettings`가 함께 있는 프로젝트 최상위 폴더를 선택합니다. `Assets` 자체를 선택하지 않습니다.
3. 가능하면 프로젝트에 기록된 `6000.6.0f1`로 엽니다.
4. 오른쪽 아래 임포트·컴파일 표시가 끝날 때까지 기다립니다.
5. `Window > General > Console`을 열어 빨간 오류를 확인합니다. 오류가 있으면 먼저 17장의 해당 항목을 읽습니다.

이미 프로젝트가 열려 있으면 이 단계는 건너뜁니다. 처음 열 때의 패키지 다운로드와 로그인 여부는 PC 환경에 따라 다릅니다.

## 2. 실습 폴더 만들기

1. Project 창에서 `Assets`를 클릭합니다.
2. 오른쪽 빈 곳을 우클릭 → `Create > Folder` → 이름을 `_Study`로 지정합니다.
3. `_Study` 안에 `Scenes`, `Materials`, `Profiles`, `Animations`, `Prefabs` 폴더를 같은 방법으로 만듭니다.
4. `Assets/VARCO_URP/04.Scenes/Lab_Varco3D_01`을 한 번 클릭합니다.
5. `Ctrl+D`로 복제합니다. 복제된 씬 이름을 `Study_Lab`으로 바꿉니다.
6. 복제된 씬을 Project 창의 `_Study/Scenes` 폴더로 드래그합니다.
7. `Study_Lab`을 더블클릭합니다. 저장 질문이 뜨면 이전 씬의 의도한 작업만 저장합니다.

**중요:** 씬 복사는 재질·프리팹·프로필까지 복제하지 않습니다. 공용 에셋을 바꾸는 실습에서는 그 에셋도 `Ctrl+D`로 복사하고 복사본을 다시 연결합니다.

## 3. 물체 선택과 시점 이동

1. Hierarchy에서 `Streetwear Robot_Walk`를 클릭합니다.
2. 마우스를 Scene 창 안에 두고 `F`를 눌러 선택 물체를 화면 중심에 놓습니다.
3. `Alt + 마우스 왼쪽 드래그`로 주위를 돕니다. 휠로 가까이·멀리 이동합니다.
4. `W`는 이동, `E`는 회전, `R`은 크기 도구입니다. 도구바 아이콘을 클릭해도 됩니다.
5. 화살표 한 축을 드래그하면 해당 축으로만 움직입니다. Inspector의 Transform 숫자를 입력하면 정확히 움직입니다.

Scene 창에서 우클릭을 누른 채 WASD로 시점을 움직일 수 있습니다. 이때 움직이는 것은 편집용 시점입니다. 게임에 들어갈 Main Camera 위치는 자동으로 바뀌지 않습니다.

## 4. 큐브 배치

1. Hierarchy의 빈 곳 우클릭 → `3D Object > Cube`.
2. 이름을 `Study_Cube`로 바꿉니다.
3. Inspector > Transform에서 Position `(0, 0.5, 0)`, Rotation `(0, 0, 0)`, Scale `(1, 1, 1)`을 입력합니다.
4. Scene 창에서 `F`를 눌러 확인합니다. 바닥이 Y=0일 때 높이 1인 큐브의 밑면이 바닥에 닿습니다.
5. 물체가 기존 로봇과 겹치면 Position X를 `2`로 바꿉니다.
6. `Ctrl+S`로 씬을 저장합니다.

## 5. Game과 Play

Walk를 관찰하려면 복사 씬에서 `Streetwear Robot_Walk`의 활성 체크를 켜고, 같은 자리에 겹칠 수 있는 `Chibi Robot`·다른 캐릭터를 잠시 끕니다. 재확인한 원본 씬에서는 Walk가 비활성 상태입니다.

1. Game 탭을 클릭합니다. 현재 Main Camera가 담는 화면을 봅니다.
2. 위쪽 `▶ Play` 버튼을 한 번 누릅니다.
3. 켜 둔 Walk 캐릭터의 팔다리가 움직이는지 확인합니다. “Play 버튼이 켜졌다”와 “애니메이션이 정상이다”는 다른 결과입니다.
4. `Pause`로 멈추고, 한 프레임 진행 버튼으로 자세 변화를 봅니다.
5. Play를 다시 눌러 종료합니다.

일반적으로 Play 중 바꾼 씬 오브젝트 값은 종료할 때 돌아갑니다. 하지만 **재질·프로필 같은 프로젝트 에셋 편집, 파일 쓰기, Editor 도구 실행**은 저장될 수 있습니다. Play를 임시 백업처럼 사용하지 않습니다.

## 6. 카메라 구도 맞추기

1. Play를 끕니다.
2. Scene 시점을 원하는 구도로 맞춥니다.
3. Hierarchy에서 `Main Camera`를 선택합니다.
4. `GameObject > Align With View`를 누릅니다. Windows 기본 단축키는 `Ctrl+Shift+F`입니다.
5. Game 탭에서 결과를 확인합니다. Scene 창과 Game 창의 가로세로 비율이 다르면 구도도 달라질 수 있습니다.

원래 카메라 값이 필요하면 변경 전에 Transform 숫자를 기록합니다. 취소는 `Ctrl+Z`, 실습 결과 보존은 `Ctrl+S`입니다.

**확인 질문:** Scene 화면을 돌렸는데 Game 화면이 그대로인 이유는? 씬 복사본에서 재질 색을 바꾸면 원본 씬도 달라질 수 있는가?

**답:** 편집용 시점과 게임 카메라가 다릅니다. 같은 재질 에셋을 공유한다면 원본 씬에도 변경이 보입니다.

## 이 장의 용어 찾기

모르는 말은 아래 링크 또는 [전체 용어 색인](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4_%EC%82%AC%EC%A0%84.md)에서 찾습니다. 영문 UI 이름도 검색할 수 있습니다.

- PC와·Unity: [Component](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#component) · [Console](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#console) · [Editor](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#editor) · [GameObject](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#gameobject) · [Hierarchy](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#hierarchy) · [Import](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#import) · [Inspector](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#inspector) · [Package](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#package) · [Play](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#play) · [Prefab](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#prefab) · [Project](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#project) · [Project Settings](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#project-settings) · [Transform](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#transform) · [Unity](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#unity) · [Unity Hub](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/01_PC%EC%99%80_Unity.md#hub)

- 수학과·모델: [2D](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#2d) · [3D](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#3d) · [Cube](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#cube) · [Triangle](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/02_%EC%88%98%ED%95%99%EA%B3%BC_%EB%AA%A8%EB%8D%B8.md#triangle)

- 효과와·움직임과·UI: [Animation](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#animation) · [Volume Profile](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/05_%ED%9A%A8%EA%B3%BC%EC%99%80_%EC%9B%80%EC%A7%81%EC%9E%84%EA%B3%BC_UI.md#profile)

- 코드와·통신과·검증: [Download](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#download) · [Frame](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#frame) · [컴파일](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/06_%EC%BD%94%EB%93%9C%EC%99%80_%ED%86%B5%EC%8B%A0%EA%B3%BC_%EA%B2%80%EC%A6%9D.md#compile)

- 화면의·속성과·메뉴: [Align With View](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/07_%ED%99%94%EB%A9%B4%EC%9D%98_%EC%86%8D%EC%84%B1%EA%B3%BC_%EB%A9%94%EB%89%B4.md#align-view)

- 보충·기초와·도구이름: [Camera](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#camera) · [Pause](../90_%EC%B0%B8%EA%B3%A0/%EC%9A%A9%EC%96%B4%EC%82%AC%EC%A0%84/09_%EB%B3%B4%EC%B6%A9_%EA%B8%B0%EC%B4%88%EC%99%80_%EB%8F%84%EA%B5%AC%EC%9D%B4%EB%A6%84.md#pause)

<!-- study-navigation -->
[이전](01_%ED%94%84%EB%A1%9C%EC%A0%9D%ED%8A%B8_%EC%A7%80%EB%8F%84.md) · [목차](../README.md) · [다음](03_%ED%95%B5%EC%8B%AC_%EC%9A%A9%EC%96%B4%EC%99%80_%EC%A2%8C%ED%91%9C.md)
