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
- [x] 3. ArtistHelper 기본 구축
  - [x] 기본 구축
    - [x] 프로젝트 구축
    - [x] DevExpress
      - [x] DevExpress 설치
    - [x] MVVM
      - [x] MVVM 구조 구축
      - [x] MVVM 기본 세팅
    - [x] Test
      - [x] Test 기본 세팅
- [ ] 4. ArtistHelper 개발


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

# 3. ArtistHelper 기본 구축

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
  - DevExpress.Xpf.LayoutControl
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

<br><br>

## 3-4 Test

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

<br><br><br>

# 4. ArtistHelper 개발

## View(UI) 개발

### MainView.xaml

- MainViewModel.cs에 프로퍼티를 다음과 같이 구성한다.
  ```cs
  public class MainViewModel : ViewModelBase
  {    
      #region 프로퍼티
      public RibbonView RibbonViews
      {
          get { return GetProperty(() => RibbonViews); }
          set { SetProperty(() => RibbonViews, value); }
      }
      public RibbonViewModel RibbonViewModels
      {
          get { return GetProperty(() => RibbonViewModels); }
          set { SetProperty(() => RibbonViewModels, value); }
      }
      public PanelView PanelViews
      {
          get { return GetProperty(() => PanelViews); }
          set { SetProperty(() => PanelViews, value); }
      }
      public PanelViewModel PanelViewModels
      {
          get { return GetProperty(() => PanelViewModels); }
          set { SetProperty(() => PanelViewModels, value); }
      }
      #endregion
  }
  ```
- 다음과 같이 UserControl를 사용하여 View를 대입한다.
  ```xml
  <Window x:Class="ArtistHelper.View.MainView"
          xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
          xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
          xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
          xmlns:dxdo="http://schemas.devexpress.com/winfx/2008/xaml/docking"
          xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
          xmlns:local="clr-namespace:ArtistHelper.View"
          xmlns:ViewModels="clr-namespace:ArtistHelper.ViewModel"
          mc:Ignorable="d"
          Title="ArtistHelper"
          Height="800"
          Width="1000"
          d:DataContext="{d:DesignInstance {x:Type ViewModels:MainViewModel}}">
      <Grid>
          <!--#region Grid.RowDefinitions-->
          <Grid.RowDefinitions>
              <RowDefinition Height="Auto" />
              <RowDefinition Height="*" />
          </Grid.RowDefinitions>
          <!--#endregion-->
  
          <!--#region RibbonView-->
          <UserControl Content="{Binding RibbonViews}" />
          <!--#endregion-->
  
          <dxdo:LayoutGroup Caption="LeftLayout"
                            Grid.Row="1"
                            Margin="4">
  
              <!--#region PannelView-->
              <dxdo:LayoutPanel Caption="Control Tool"
                                MinWidth="250"
                                ItemWidth="250"
                                Content="{Binding PanelViews}"
                                AllowClose="False" />
              <!--#endregion-->
  
              <!--#region DrawView-->
              <dxdo:LayoutGroup ItemWidth="3*"
                                DestroyOnClosingChildren="False">
                  <dxdo:DocumentGroup DestroyOnClosingChildren="False"
                                      ClosePageButtonShowMode="InAllTabPageHeaders">
                  </dxdo:DocumentGroup>
              </dxdo:LayoutGroup>
              <!--#endregion-->
  
          </dxdo:LayoutGroup>
      </Grid>
  </Window>
  ```

<br>

### PanelView.xaml UI 개발

- PanelView.xaml을 다음과 같이 구성한다.
  ```xml
  <UserControl x:Class="ArtistHelper.View.PanelView"
               xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
               xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
               xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
               xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
               xmlns:dxlc="http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol"
               xmlns:local="clr-namespace:ArtistHelper.View"
               xmlns:ViewModels="clr-namespace:ArtistHelper.ViewModel"
               mc:Ignorable="d"
               d:DataContext="{d:DesignInstance {x:Type ViewModels:PanelViewModel}}">
      <dxlc:LayoutControl Padding="4"
                          ItemSpace="4"
                          Orientation="Vertical">
          <!--#region Label & TextBox-->
          <dxlc:LayoutItem Label="Width"
                           VerticalAlignment="Top"
                           InputScope="Default">
              <TextBox MaxHeight="24"
                       MaxLength="50"/>
          </dxlc:LayoutItem>
          <dxlc:LayoutItem Label="Height"
                           VerticalAlignment="Top"
                           InputScope="Default">
              <TextBox MaxHeight="24"
                       MaxLength="50" />
          </dxlc:LayoutItem>
          <dxlc:LayoutItem Label="LineGrid"
                           VerticalAlignment="Top"
                           InputScope="Default">
              <TextBox MaxHeight="24"
                       MaxLength="50" />
          </dxlc:LayoutItem>
          <dxlc:LayoutItem Label="Rect Min Width"
                           VerticalAlignment="Top"
                           InputScope="Default">
              <TextBox MaxHeight="24"
                       MaxLength="50" />
          </dxlc:LayoutItem>
          <dxlc:LayoutItem Label="Rect Min Height"
                           VerticalAlignment="Top"
                           InputScope="Default">
              <TextBox MaxHeight="24"
                       MaxLength="50" />
          </dxlc:LayoutItem>
          <dxlc:LayoutItem Label="EndPoint X"
                           VerticalAlignment="Top"
                           InputScope="Default">
              <TextBox MaxHeight="24"
                       MaxLength="50" />
          </dxlc:LayoutItem>
          <dxlc:LayoutItem Label="EndPoint Y"
                           VerticalAlignment="Top"
                           InputScope="Default">
              <TextBox MaxHeight="24"
                       MaxLength="50" />
          </dxlc:LayoutItem>
          <dxlc:LayoutItem Label="Box Count"
                           VerticalAlignment="Top"
                           InputScope="Default">
              <TextBox MaxHeight="24"
                       MaxLength="50" />
          </dxlc:LayoutItem>
          <dxlc:LayoutItem Label="Figure Type"
                           VerticalAlignment="Top"
                           InputScope="Default">
              <ComboBox HorizontalAlignment="Left"
                        VerticalAlignment="Top"
                        Width="Auto">
                  <ComboBox.ItemTemplate>
                      <DataTemplate>
                          <StackPanel Orientation="Horizontal">
                              <TextBlock Text="{Binding Name}" />
                          </StackPanel>
                      </DataTemplate>
                  </ComboBox.ItemTemplate>
              </ComboBox>
          </dxlc:LayoutItem>
          <!--#endregion-->
  
      </dxlc:LayoutControl>
  </UserControl>
  ```
- MainViewModel.cs를 다음과 같이 구성한다.
  ```cs
  #region 생성자
  public MainViewModel()
  {
      Initialize();
  }
  #endregion

  #region 메소드
  void Initialize()
  {
      RibbonViewModels = new RibbonViewModel();
      RibbonViews = new RibbonView(RibbonViewModels);

      PanelViewModels = new PanelViewModel();
      PanelViews = new PanelView(PanelViewModels);
  }
  #endregion
  ```
  <img src="https://user-images.githubusercontent.com/66783849/214079359-4a0fd961-e649-4f45-b249-dc41fa82914c.png" width="350">

<br>

### RibbonView.xaml UI 개발

- RibbonView.xaml를 다음과 같이 구성한다.
  ```xml
  <UserControl x:Class="ArtistHelper.View.RibbonView"
               xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
               xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
               xmlns:dx="http://schemas.devexpress.com/winfx/2008/xaml/core"
               xmlns:dxr="http://schemas.devexpress.com/winfx/2008/xaml/ribbon"
               xmlns:dxb="http://schemas.devexpress.com/winfx/2008/xaml/bars"
               xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
               xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
               xmlns:local="clr-namespace:ArtistHelper.View"
               xmlns:ViewModels="clr-namespace:ArtistHelper.ViewModel"
               mc:Ignorable="d"
               d:DataContext="{d:DesignInstance {x:Type ViewModels:RibbonViewModel}}">
      <dxr:RibbonControl ShowApplicationButton="False"
                         ToolbarShowCustomizationButton="False"
                         RibbonStyle="Office2019"
                         RibbonHeaderVisibility="Collapsed">
          <dxr:RibbonPage Caption="Control">
              <dxr:RibbonPageGroup Caption="Image">
                  <dxb:BarButtonItem x:Name="newBtn"
                                     Content="New"
                                     KeyGesture="Ctrl+N"
                                     CloseSubMenuOnClick="True"
                                     BarItemDisplayMode="ContentAndGlyph"
                                     Glyph="{dx:DXImage SvgImages/Outlook Inspired/New.svg}"
                                     LargeGlyph="{dx:DXImage SvgImages/Outlook Inspired/New.svg}"/>
                  <dxb:BarButtonItem x:Name="saveBtn"
                                     Content="Save"
                                     KeyGesture="Ctrl+S"
                                     CloseSubMenuOnClick="True"
                                     BarItemDisplayMode="ContentAndGlyph"
                                     Glyph="{dx:DXImage SvgImages/Outlook Inspired/Save.svg}"
                                     LargeGlyph="{dx:DXImage SvgImages/Outlook Inspired/Save.svg}"/>
              </dxr:RibbonPageGroup>
          </dxr:RibbonPage>
      </dxr:RibbonControl>
  </UserControl>
  ```
  <img src="https://user-images.githubusercontent.com/66783849/214082371-284ccd8e-d176-4b7b-ad54-bd2d0df1b56d.png" width="350">

<br><br>

## ViewModel(기능) 개발

### RibbonViewModel.cs 개발

- RibbonViewModel에 Command를 연결하고, MainViewModel로 Messenger를 전달한다.
  ```cs
  #region 커멘드
  public ICommand NewCommand { get; set; }
  public ICommand SaveCommand { get; set; }
  #endregion

  #region 생성자
  public RibbonViewModel()
  {
      SaveCommand = new DelegateCommand(_saveCommandAction);
      NewCommand = new DelegateCommand(_newCommandAction);
  }
  #endregion

  #region 메소드
  private void _saveCommandAction()
  {
      Messenger.Default.Send("SavePanel");
  }

  private void _newCommandAction()
  {
      Messenger.Default.Send("NewPanel");
  }
  #endregion
  ```
  ```xml
  <dxb:BarButtonItem x:Name="newBtn"
                     Content="New"
                     KeyGesture="Ctrl+N"
                     CloseSubMenuOnClick="True"
                     Command="{Binding Path=NewCommand}"
                     BarItemDisplayMode="ContentAndGlyph"
                     Glyph="{dx:DXImage SvgImages/Outlook Inspired/New.svg}"
                     LargeGlyph="{dx:DXImage SvgImages/Outlook Inspired/New.svg}"/>
  <dxb:BarButtonItem x:Name="saveBtn"
                     Content="Save"
                     KeyGesture="Ctrl+S"
                     CloseSubMenuOnClick="True"
                     Command="{Binding Path=SaveCommand}"
                     BarItemDisplayMode="ContentAndGlyph"
                     Glyph="{dx:DXImage SvgImages/Outlook Inspired/Save.svg}"
                     LargeGlyph="{dx:DXImage SvgImages/Outlook Inspired/Save.svg}"/>
  ```
- MainViewModel은 다음과 같이 추가한다.
  ```cs
  #region 메소드
  void Initialize()
  {
      RibbonViewModels = new RibbonViewModel();
      RibbonViews = new RibbonView(RibbonViewModels);

      PanelViewModels = new PanelViewModel();
      PanelViews = new PanelView(PanelViewModels);

      Messenger.Default.Register<string>(this, OnMessage);
  }
  #endregion

  #region Messenger Method
  private void OnMessage(string text)
  {
      if (text == null || text.Length == 0)
          return;

      var messengerType = StringToMessenger(text);

      switch (messengerType)
      {
          case _messengerType.SavePanel:
              MessageBox.Show("SavePanel");
              break;

          case _messengerType.NewPanel:
              MessageBox.Show("NewPanel");
              break;

          default:
              break;
      }
  }

  private _messengerType StringToMessenger(string message)
  {
      var type = default(_messengerType);
      foreach (_messengerType t in Enum.GetValues(typeof(_messengerType)))
          if (t.ToString().StartsWith(message, StringComparison.CurrentCultureIgnoreCase))
          {
              type = t;
              break;
          }

      return type;
  }
  #endregion
  ```
  <img src="https://user-images.githubusercontent.com/66783849/214090404-f345efc8-2755-4d46-83fc-de5b2c4e5250.png" width="350">

<br>

### ArtistModel.cs 개발

  ```cs
  #region 프로퍼티
  public int Width { get; set; } // 이미지 가로 사이즈
  public int Height { get; set; } // 이미지 세로 사이즈
  public int LineGrid { get; set; } // 선 굵기
  public int MinWidth { get; set; } // 사각형 최소 가로 길이
  public int MinHeight { get; set; } // 사각형 최소 세로 길이
  public int EndPointX { get; set; } // 종점 x
  public int EndPointY { get; set; } // 종점 y
  public int BoxCount { get; set; } // 사각형 개수
  public int FigureType { get; set; } // 도형 종류
  public string Name { get; set; }
  #endregion

  #region 생성자
  public ArtistModel(int width, int height, int lineGrid, int
  {
      Width = width;
      Height = height;
      LineGrid = lineGrid;
      MinWidth = minWidth;
      MinHeight = minHeight;
      EndPointX = endPointX;
      EndPointY = endPointY;
      BoxCount = boxCount;
      FigureType = figureType;
  }
  public ArtistModel(ArtistModel artists)
  {
      Width = artists.Width;
      Height = artists.Height;
      LineGrid = artists.LineGrid;
      MinWidth = artists.MinWidth;
      MinHeight = artists.MinHeight;
      EndPointX = artists.EndPointX;
      EndPointY = artists.EndPointY;
      BoxCount = artists.BoxCount;
      FigureType = artists.FigureType;
  }
  #endregion
  ```

<br>

### PanelViewModel.cs 개발

<br>

###

<br><br>

##

###