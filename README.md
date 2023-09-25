문서정보 : 2023.01.08.~09.25. 작성, 작성자 [@SAgiKPJH](https://github.com/SAgiKPJH)

<img src="https://github.com/SagiK-Repository/WPF_DevExpress_MVVM_ArtistHelper/assets/66783849/9f99eaff-eee9-455c-a125-ef9e00c8d984"/>

<br/>

# WPF_DevExpress_MVVM_ArtistHelper
DevExpress MVVM WPF로 만든 ArtistHelper

### Version 정보

Date | Version
-- | --
~ 2023-09-25 | v0.1.2


### 목표

- [x] [1. ArtistHelper 프로그램 개요](#1-artisthelper-프로그램-개요)
  - [x] [개요](#1-1-개요)
  - [x] [요구사항](#1-2-요구사항)
  - [x] [요구사항 총족을 위한 기술적 내용](#1-3-요구사항-총족을-위한-기술적-내용)
- [x] [2. ArtistHelper 설계](#2-artisthelper-설계)
  - [x] [개발 환경 설계](#2-1-개발환경-설계)
- [x] [3. ArtistHelper 개발](#3-artisthelper-개발)
  - [x] [프로젝트 생성](#3-1-프로젝트-생성)
  - [x] [DevExpress 적용](#3-2-devexpress-적용)
  - [x] [MVVM 적용](#3-3-mvvm-적용)
  - [x] [Test 적용](#3-4-test-적용)
  - [x] [DDD 구조 적용](#3-5-ddd-구조-설계)

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

### Code 설계

- DDD 구조 설계
- MVVM 구조 설계

<br><br><br>

# 3. ArtistHelper 개발

## 3-1 프로젝트 생성

<details><summary>접기/펼치기</summary>

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

</details>

<br><br>

## 3-2 DevExpress 적용

<details><summary>접기/펼치기</summary>

- DevExpress 설치
  - [DevExpress 사이트](https://www.devexpress.com/products/net/controls/wpf/)
- DevExpress 참조 추가
  - DevExpress.Data.Desktop
  - DevExpress.Data
  - DevExpress.DataAccess
  - DevExpress.Drawing
  - DevExpress.Images
  - DevExpress.Mvvm
  - DevExpress.Office.Core
  - DevExpress.Pdf.Core
  - DevExpress.Pdf.Drawing
  - DevExpress.Printing.Core
  - DevExpress.RichEdit.Core
  - DevExpress.Xpf.Core
  - DevExpress.Xpf.Docking
  - DevExpress.Xpf.Layout.Core
  - DevExpress.Xpf.LayoutControl
  - DevExpress.Xpf.Ribbon  
  - DevExpress.Themes.Office2019Coroful
  - DevExpress.Xpo  
  <img src="https://user-images.githubusercontent.com/66783849/214018272-67d2e82d-8f95-48c2-94c7-6cde4e82a52c.png" width="350">  
  <img src="https://user-images.githubusercontent.com/66783849/214018323-cf6a1e81-13cd-44ff-917c-2b09f876ebf2.png" width="350">

</details>

<br><br>

## 3-3 MVVM 적용

<details><summary>접기/펼치기</summary>

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
    - (+) `Title="ArtistHelper" Height = 800, Width = 1000`
    - (+) `xmlns:ViewModels="clr-namespace:ArtistHelper.ViewModel"`
    - (+) `d:DataContext="{d:DesignInstance {x:Type ViewModels:MainViewModel}}"`
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
          xmlns:ViewModels="clr-namespace:ArtistHelper.ViewModel"
          mc:Ignorable="d"
          d:DataContext="{d:DesignInstance {x:Type ViewModels:DrawViewModel}}">
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

</details>

<br><br>

## 3-4 Test 적용

<details><summary>접기/펼치기</summary>

### 프로젝트 구성
- Test 프로젝트 구성
  - `단위 테스트 프로젝트(.NET Framework)` 프로젝트 생성
- Test Nuget Pakage 구성 (참조-NuGet패키지관리)
  - xUnit 추가
  - xUnit.runner.visualstudio 추가
  - FluentAssertion 추가
- 프로젝트 폴더 및 파일 구성
  - ViewModel
    - DrawViewModel.Test.cs
    - MainViewModel.Test.cs
    - RibbonViewModel.Test.cs
    - PanelViewModel.Test.cs
  - Model
    - ArtistModel.Test.cs
    - PanelModel.Test.cs
    - DrawModel.Test.cs  
  <img src="https://user-images.githubusercontent.com/66783849/214026846-2a32e517-e4e6-4fae-842c-06ce4346543d.png">


### Test 코드 구성

- Test의 품질을 보다 향상시키기 위해, 다음 4가지를 고려하여 Test를 작성하였다.
  - Test는 기능별로 따로 구분해야 한다. (value Test, MinMax Test, Exception Test등)
  - Test의 함수는 간단해야 한다. (Arange, Act, Assert 각각 한 줄)
  - 빠르고 직관적인 Test (Fact만 사용하는 것이 아닌, Theory를 활용한다)
  - 최대한 많이, 시간이 오래걸리더라도 정성들여 작성한다.
- 다음과 같이 Test 코드를 재구성하였다.
  ```cs
  [InlineData(1, 1.0)]
  [InlineData(1000, 1000.0)]
  [InlineData(4000, 2000.0)]
  [InlineData(-2000, 0.0)]
  [Theory(DisplayName = "DDD Value : Artist.Width<int> Value Test")]
  public void DDDTest_Width_int_Test(object value, double outValue)
  {
      // Arange

      // Act
      var width = new Width<int>(Convert.ToInt32(value));

      // Assert
      width.GetValue().Should().Be(outValue);
  }
  ```

<br>

### Test 코드 예시

- Value Test  
  ```cs
  [InlineData(1, 1.0)] // 일반 부여
  [InlineData(4000, 2000.0)] // 최대 초과
  [InlineData(-2000, 0.0)] // 최소 초과
  [Theory(DisplayName = "DDD Value : Artist.Width<int> Value Test")]
  public void DDDTest_Width_int_Test(object value, double outValue)
  {
      // Arange
  
      // Act
      var width = new Width<int>(Convert.ToInt32(value));
  
      // Assert
      width.GetValue().Should().Be(outValue);
  }
  ```  

</details>

<br><br>

## 3-5 DDD 구조 설계

<details><summary>접기/펼치기</summary>

- 최소단위 DDD 구성
  ```cs
  public class Width<T> : ValueObject where T : struct
  {
      private double _minValue = 0;
      private double _maxValue = 2000;
      private double _value;
      private bool _exceptionSwitch = false;
  
      public Width() => _value = 0.0;
  
      public Width(T value)
      {
          ModifyValue(Convert.ToDouble(value));
      }
      public Width(double value)
      {
          ModifyValue(value);
      }
      public Width(T value, T minValue, T maxValue)
      {
          SetMinValue(Convert.ToDouble(minValue));
          SetMaxValue(Convert.ToDouble(maxValue));
          ModifyValue(Convert.ToDouble(value));
      }
      public Width(T value, double minValue, double maxValue)
      {
          SetMinValue(minValue);
          SetMaxValue(maxValue);
          ModifyValue(Convert.ToDouble(value));
      }
      public Width(double value, double minValue, double maxValue)
      {
          SetMinValue(minValue);
          SetMaxValue(maxValue);
          ModifyValue(value);
      }

      // ...
  ```

</details>
