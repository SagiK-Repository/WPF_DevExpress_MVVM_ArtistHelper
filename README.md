문서정보 : 2022.11.06. 작성, 작성자 [@SAgiKPJH](https://github.com/SAgiKPJH)

<br>

# WPF_DevExpress_MVVM_ArtistHelper
DevExpress MVVM WPF로 만든 ArtistHelper

### 목표
- [x] : 1. DevExpress WPF 설치
- [ ] : 2. 개발 계획 세우기

### 제작자
[@SAgiKPJH](https://github.com/SAgiKPJH)

### 참조

- [참조링크](참조링크)

<br>

---

<br>

# 1. DevExpress WPF 설치

- [DevExpress 설치 사이트](https://www.devexpress.com/Products/Try/) (유료)
- 무료로는 30일 Trials를 사용하자.
- 설치 후 VisualStudio에서 새로만들 때 DevExpress 전용이 생성되는 것을 확인할 수 있다.

<br>

# 2. 개발 계획 세우기

- Dexpress MVVM 활용한 WPF를 만든다.
- MVVM구조로 제작한다.

### 세부 구조
- View, ViewModel : 쪼갤 수 있는 부분은 전부 쪼갠다. 기본적으로 Docking 기능을 지원한다.
  - Ribbon
    - Create Button : Artist 창 생성
    - Save Image : 제작된 Artist 창을 저장한다.
  - Pannel
    - Width EditText
    - Height EditText
    - LineGrid EditText
    - MinWidth EditText
    - MinHeight EditText
    - EndPointX EditText
    - EndPointY EditText
    - BoxCount EditText
    - FigureType EditText
  - DrawDock
    - Artist 창으로, 그림 결과가 나타난다. 
- Model : Artist 작업에 필요한 변수들을 저장한다.
  - Width : 이미지 가로 사이즈
  - Height : 이미지 세로 사이즈
  - LineGrid : 선 굵기
  - MinWidth : 사각형 최소 가로 길이
  - MinHeight : 사각형 최소 세로 길이
  - EndPointX : 종점 x
  - EndPointY : 종점 y
  - BoxCount : 사각형 개수
  - FigureType : 도형 종류
- cs 파일
  - DrawFigure.cs : 각종 도형을 요구에 맞게 그린다. (In : W, H, FigureType, LineGrid)
    - Rect
    - Circle
    - 타원
    - 변형도형
  - Artist.cs : Artist 작업을 진행한다. (In : W, H, FigureType, LineGrid, EndPoint x y, BoxCount)
