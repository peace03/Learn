# URP 연결과 렌더링

[전체 주제 목차](../../README.md) · [전체 용어 사전](../../90_용어사전/README.md)

렌더 파이프라인은 물체를 고르고 그리기 작업을 배분합니다. **CPU**는 주로 규칙·준비 작업, **GPU**는 많은 정점과 픽셀의 계산을 나누어 처리합니다. **Renderer Feature**는 그림자·데칼 같은 추가 렌더 작업을 Renderer에 넣는 기능입니다. 파일이 있어도 현재 카메라가 쓰는 Renderer에 연결되지 않으면 효과가 없을 수 있습니다.

**SSAO**는 현재 카메라의 깊이·표면 방향 등을 이용해 주변이 막힌 정도를 근사합니다. **Screen Space Shadows**는 화면 공간에 그림자 결과를 준비해 사용하는 기능입니다. 둘 다 화면을 활용하지만 같은 효과가 아닙니다. **Screen Space**는 3D 방 전체의 주소가 아니라 화면 위 위치를 기준으로 하는 표현입니다.

## 렌더링은 3D를 2D 그림으로 만드는 계산이다

카메라는 어느 쪽을 볼지 정합니다. 렌더 파이프라인은 어떤 물체를 어떤 순서로, 어떤 빛 계산을 써서 그릴지 정합니다. 이 프로젝트는 **Universal Render Pipeline, URP**를 사용합니다.

한 프레임을 단순하게 풀면 다음과 같습니다.

```text
카메라에 필요한 물체 고르기 → 그림자 준비 → 표면 그리기 → 투명 효과 → 후처리 → 화면
```

실제 순서는 Renderer·기능·렌더링 경로에 따라 추가 단계가 생깁니다. **Render Pass**는 그 과정의 작업 한 단계입니다. **Render Graph**는 필요한 작업과 임시 자원의 관계를 표현하고 관리하는 체계입니다. 그래프를 사용한다고 모든 효과가 저절로 빨라지는 것은 아닙니다.

## 헷갈리는 설정 세 개

| 이름 | 역할 | 현재 프로젝트 |
|---|---|---|
| URP Asset | 화면 크기 비율·그림자·HDR 등 전체 렌더 설정 | `PC_RPAsset`, `Mobile_RPAsset` |
| Renderer Data | 렌더링 방식과 추가 기능 구성 | `PC_Renderer`, `Mobile_Renderer` |
| Volume Profile | Bloom·색 보정 같은 후처리 값 | `Lab_Studio` 등 |

연결 흐름은 `Graphics 기본값 또는 Quality별 설정 → URP Asset → Renderer Data`입니다. Quality에 별도 URP Asset이 있으면 그 설정을 먼저 봅니다. 카메라가 특정 Renderer를 선택할 수도 있습니다.

## 저장된 PC·Mobile 차이

경로: `Assets/VARCO_URP/07.Settings/URP Quality`.

| 항목 | PC | Mobile |
|---|---|---|
| Rendering Path | Forward+ | Forward |
| Render Scale | 1.0 | 0.8 |
| Depth Texture | 켬 | 끔 |
| Opaque Texture | 켬 | 끔 |
| HDR | 켬 | 켬 |
| MSAA | 1, 사실상 다중 샘플 없음 | 1 |
| Main Light Shadowmap Resolution | 8192 | 1024 |
| Additional Lights Shadowmap Resolution | 8192 | 2048 |
| Renderer Features | SSAO, Screen Space Shadows, Decal | 없음 |

Forward는 대체로 물체를 그리며 빛을 계산합니다. Forward+는 화면 공간 등을 구역으로 나눠 각 구역에 관련된 빛을 찾는 방식으로 많은 광원 처리를 돕습니다. 모든 장면에서 Forward+가 더 빠른 것은 아닙니다. 저장값 `m_RenderingMode: 2`는 현재 패키지의 enum에서 Forward+입니다.

**Depth Texture**는 카메라에서 표면까지의 깊이 정보, **Opaque Texture**는 불투명 물체를 그린 화면 사본입니다. 기능이 요구할 때 유용하지만 생성 비용과 메모리가 듭니다.

## 실습: 내 화면의 설정 추적

1. `Edit > Project Settings > Graphics`에서 기본 Render Pipeline Asset을 찾습니다. 프로젝트는 `PC_RPAsset`을 참조합니다.
2. `Quality`에서 선택된 품질과 Render Pipeline Asset을 확인합니다. 저장된 현재 품질은 PC입니다.
3. Project에서 `PC_RPAsset`을 클릭합니다. Inspector의 Renderer 목록에서 `PC_Renderer`를 찾습니다.
4. `PC_Renderer`를 클릭하고 Renderer Features 세 개를 읽습니다. 이 단계에서는 값을 바꾸지 않습니다.
5. Hierarchy > `Main Camera` > Camera에서 Rendering·Environment 관련 접힌 항목을 펼칩니다. Renderer는 저장 상태에서 기본값 사용, Post Processing은 켜져 있습니다.
