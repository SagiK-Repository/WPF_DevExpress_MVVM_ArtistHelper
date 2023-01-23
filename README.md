문서정보 : 2023.01.08.~ 작성, 작성자 [@SAgiKPJH](https://github.com/SAgiKPJH)

<br>

# WPF_DevExpress_MVVM_ArtistHelper
DevExpress MVVM WPF로 만든 ArtistHelper

### 목표

- [x] 1. ArtistHelper 프로그램 개요
  - [x] 개요
  - [x] 요구사항
  - [x] 요구사항 총족을 위한 기술적 내용
- [ ] 2. ArtistHelper 설계
  - [ ] 개발 환경 설계
- [ ] 3. ArtistHelper 개발
  - [x] 기본 구축
    - [x] 프로젝트 구축
    - [x] DevExpress
      - [x] DevExpress 설치
    - [x] MVVM
      - [x] MVVM 구조 구축
    - [ ] Test
      - [ ] Test 기본 세팅

### 제작자
[@SAgiKPJH](https://github.com/SAgiKPJH)

### 참조

- [참조링크](참조링크)

<br>

---

# 1. ArtistHelper 프로그램 개요

## 1-1 개요

 세상에는 수많은 예술작품이 있는데, 예술작품을 만드는데 있어서 다양한 규칙 및 조건에 의해 형태와 틀, 디자인 너머서는 의미까지 정해진다. 이를 위해서 수학을 사용하는 경우가 많은데, 복잡할 수록 계산하는데 오래 걸리고 원하는 결과가 나타나기 까지 오래걸리기 마련이다.
<br>
 우리는 한 작품의 규칙과 틀을 위해서 수학적 모델을 사용하여 하나의 도우미를 제작하려고 한다. 의뢰인으로부터 받은 조건에 맞는 프로그램을 제작하고, 원하는 결과를 빠르게 얻을 수 있도록 하고자 한다.

<br>

## 1-2 요구사항

- 예술작품 제작을 위한 실시간 이미지 제작 프로그램
- 수학적 규칙에 따른 결과물 이미지가 나타나야 한다
- 작품에 필요한 입력값을 쉽게 넣을 수 있다
- 다양한 값을 넣고 비교를 해볼 수 있다
- 이미지로 저장할 수 있다

<br>

## 1-3 요구사항 총족을 위한 기술적 내용

- 개발 언어 C#
- DeskTop에서 동작하므로 WPF로 제작한다
- DevExpress를 사용하여 디자인을 설정한다
- DevExpress의 Docking을 활용하여 여러 결과물을 비교할 수 있게 한다
- 쉬운 관리를 위하여 MVVM구조를 활용한다
- 품질관리를 위해 Test를 구성한다
- Git을 이용해 코드를 관리한다

<br><br><br>

# 2. ArtistHelper 설계

## 2-1 개발환경 설계

### Visual Studio

- Visual Studio 2022
- Debug, Release(배포)
- AnyCPU (x32, x64)

### Project

- WPF 앱 (.NET Framework)
- .Net Framework 4.8
- DevExpress 22.2.3

### Test

- xUnit
- FluentAssertion


<br><br><br>

# 3. ArtistHelper 개발

## 3-1 기본 구축

### 프로젝트 구축

- 프로젝트 생성
  - `WPF 앱(.NET Framework)` 프로젝트 생성 (.Net Framework 4.8)  
  <img src="https://user-images.githubusercontent.com/66783849/214012083-ec8c1da4-c97c-47a6-b0d8-cf98a56011df.png" width="650">
- 폴더 구축  
  - View 폴더 생성
  - ViewModel 폴더
  - Model 폴더
  - Interface 폴더
  - MainWindow.xaml 삭제  
  <img src="https://user-images.githubusercontent.com/66783849/214014928-460bdfef-7a63-46c2-9bf1-9810222d728a.png">

<br><br>

## 3-2 DevExpess

- DevExpress 설치
  - [DevExpress 사이트](https://www.devexpress.com/products/net/controls/wpf/)
- DevExpress 참조 추가
  - DevExpress.Data.Desktop
  - DevExpress.Data
  - DevExpress.Mvvm
  - DevExpress.Xpf.Core
  - DevExpress.Xpf.Docking
  - DevExpress.Xpf.Layout.Core
  - DevExpress.Xpf.Ribbon  
  <img src="https://user-images.githubusercontent.com/66783849/214018272-67d2e82d-8f95-48c2-94c7-6cde4e82a52c.png" width="350">  
  <img src="https://user-images.githubusercontent.com/66783849/214018323-cf6a1e81-13cd-44ff-917c-2b09f876ebf2.png" width="350">


<br><br>

## 3-3 MVVM

### MVVM 구조 구축
- View 폴더 생성
  - DrawView.xaml 생성 (WPF 창 생성)
  - MainView.xaml
  - PannelView.xaml
  - RibbonView.xaml
- ViewModel 폴더
  - DrawViewModel.cs
  - MainViewModel.cs
  - PannelViewModel.cs
  - RibbonViewModel.cs
- Model 폴더
  - ArtistModel.cs
  - PanelModel.cs
  - DrawModel.cs
- Interface 폴더
  - IWindowView.cs  
  <img src="https://user-images.githubusercontent.com/66783849/214014621-eb28b550-a95d-4515-b532-55f4f005ee4a.png" width="350">

<br>

### MVVM 기본 세팅

- App.xaml
  - `StartupUri="MainWindow.xaml"` 제거
  ```xml
  <Application x:Class="ArtistHelper.App"
               xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
               xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
               xmlns:local="clr-namespace:ArtistHelper">
      <Application.Resources>
           
      </Application.Resources>
  </Application>
  ```
- MainViewModel, MainView 세팅
  - MainView.xaml를 다음과 같이 세팅한다.
    - `Title="ArtistHelper" Height = 800, Width = 1000`
  - MainViewModel.cs를 다음과 같이 세팅한다.
    - 특히 public으로 선언하는 것을 주의할 것
  ```cs
  namespace ArtistHelper.ViewModel
  {
      public class MainViewModel
      {
          #region 변수
          #endregion
          
          #region 프로퍼티
          #endregion
          
          #region 생성자
          #endregion
  
          #region 메소드
          #endregion
      }
  }
  ```
  - IWindowView.cs를 다음과 같이 구성한다.
  ```cs
  using System.Windows;
  
  public interface IWindowView
  {
      void Show();
  
      void Close();
  
      Visibility Visibility { get; set; }
  }
  ```
  - MainView.xaml.cs를 다음과 같이 세팅한다.
  ```cs
  using ArtistHelper.ViewModel;
  using System.Windows;
  
  namespace ArtistHelper.View
  {
      public partial class MainView : Window, IWindowView
      {
          public MainView(MainViewModel mainViewModel)
          {
              InitializeComponent();
              DataContext = mainViewModel;
          }
      }
  }
  ```
- App.xaml.cs 세팅
  ```cs
  using ArtistHelper.View;
  using ArtistHelper.ViewModel;
  using System.Windows;
  
  namespace ArtistHelper
  {
      public partial class App : Application
      {
          protected override void OnStartup(StartupEventArgs e)
          {
              base.OnStartup(e);
  
              MainViewModel mainViewModel = new MainViewModel();
              MainView mainView = new MainView(mainViewModel);
  
              mainView.Show();
  
          }
      }
  }
  ```
- ViewModel - View 관계 세팅
  - 모든 ViewModel 및 View를 다음과 같이 세팅한다.
  - DrawView.xaml
    - UserControl로 바꾼다.
    - `Title`, `Width`, `Height`을 제거한다
  ```xml
  <UserControl x:Class="ArtistHelper.View.DrawView"
          xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
          xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
          xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
          xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
          xmlns:local="clr-namespace:ArtistHelper.View"
          mc:Ignorable="d">
      <Grid>
          
      </Grid>
  </UserControl>
  ```
  - DrawView.xaml.cs
    - 상속을 UserControl로 변경한다
  ```cs
  namespace ArtistHelper.View
  {
      public partial class DrawView : UserControl
      {
          public DrawView(DrawViewModel drawViewModel)
          {
              InitializeComponent();
              DataContext = drawViewModel;
          }
      }
  }
  ```
  - DrawViewModel.cs
  ```cs
  namespace ArtistHelper.ViewModel
  {
      public class DrawViewModel
      {
          #region 변수
          #endregion
          
          #region 프로퍼티
          #endregion
          
          #region 생성자
          #endregion
  
          #region 메소드
          #endregion
      }
  }
  ```
- <kbd>Ctrl</kbd> + <kbd>F5</kbd>를 통해 빌드 후 디버깅 실행해본다
- 프로세스 실행에 의한 오류시, 오류창에 나타난 프로세스 번호를 제거한다.
  - cmd를 열어 `taskkill /pid 24960 /f`를 입력한다. (숫자는 해당하는 Process 번호 입력)  
  <img src="https://user-images.githubusercontent.com/66783849/214023972-f6be3614-554e-40ee-8730-bfbcc84065e8.png" width="350">

<br><br>

## 3-4 Test