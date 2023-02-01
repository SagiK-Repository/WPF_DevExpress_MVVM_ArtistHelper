using ArtistHelper.Model;
using FluentAssertions;
using System;
using Xunit;

namespace ArtistHelper.test.Model
{
    public class ArtistModel_Test
    {
        #region Artist Test
        [Fact(DisplayName = "ArtistModel Test")]
        public void ArtistModelTest()
        {
            // Arange

            // Act
            var artist = new ArtistModel<int>()
            {
                Width = new Width<int>(10, 0, 1000),
                Height = new Height<int>(100, 0, 1000),
                LineGrid = new Grid<int>(10),
                MinWidth = new Width<int>(0, 0, 1000),
                MinHeight = new Height<int>(0, 0, 1000),
                EndPoint = new Point<int>(0, 0),
            };

            // Assert
            artist.Width.GetValue().Should().Be(10);
            artist.Height.GetValue().Should().Be(100);
            artist.LineGrid.GetValue().Should().Be(10);
            artist.MinWidth.GetValue().Should().Be(0);
            artist.MinHeight.GetValue().Should().Be(0);
            artist.EndPoint.X.GetValue().Should().Be(0);
            artist.EndPoint.Y.GetValue().Should().Be(0);
        }
        #endregion

        #region DDD Width Value Test
        [Fact(DisplayName = "DDD Value - Artist.Width Test")]
        public void DDDTest_Width_Test()
        {
            // Arange

            // Act
            var width = new Width(0);
            var width2 = new Width(0, 0, 100);
            var width3 = new Width(50);
            width3.ModifyValue(100);
            var width4 = new Width(-100, -200, 0);

            // Assert
            width.GetValue().Should().Be(0);
            width2.GetValue().Should().Be(0);
            width3.GetValue().Should().Be(100);
            width4.GetValue().Should().Be(-100);
        }
        
        [Fact(DisplayName = "DDD Value - Artist.Width MinMax Test")]
        public void DDDTest_Width_MinMax_Test()
        {
            // Arange

            // Act
            var minWidth1 = new Width(-10);
            var minWidth2 = new Width(-10, 0, 100);
            var maxWidth1 = new Width(4000);
            var maxWidth2 = new Width(4000, 0, 100);
            var width1 = new Width(50, 30, 100);
            var width2 = new Width(50, 30, 100);
            width1.ModifyValue(25);
            width2.ModifyValue(150);

            // Assert
            minWidth1.GetValue().Should().Be(0);
            minWidth2.GetValue().Should().Be(0);
            maxWidth1.GetValue().Should().Be(2000);
            maxWidth2.GetValue().Should().Be(100);
            width1.GetValue().Should().Be(30);
            width2.GetValue().Should().Be(100);
        }
        
        [Fact(DisplayName = "DDD Value - Artist.Width After MinMax Test")]
        public void DDDTest_Width_After_MinMax_Test()
        {
            // Arange
            var width1 = new Width(100);
            var width2 = new Width(100);
            var width3 = new Width(100);
            var width4 = new Width(100);
            var width5 = new Width(100);
            var width6 = new Width(100);
            var width7 = new Width(100);
            var width8 = new Width(100);
            string exception7 = "";
            string exception8 = "";

            // Act
            width1.SetMinValue(150);
            width2.SetMaxValue(50);
            width3.SetMinMaxValue(50, 150);
            width3.ModifyValue(25);
            width4.SetMinMaxValue(50, 150);
            width4.ModifyValue(175);
            try
            {
                width5.SetMinValue(5000);
            }catch(Exception e) 
            {
                exception7 = e.Message;
            }
            try
            {
                width6.SetMaxValue(-100);
            }catch(Exception e)
            {
                exception8 = e.Message;
            }
            try
            {
                width7.SetMinValue(5000);
            }
            catch (Exception) { }
            width7.ModifyValue(4500);
            try
            {
                width8.SetMaxValue(-100);
            }
            catch (Exception) { }
            width8.ModifyValue(-50);

            // Assert
            width1.GetValue().Should().Be(150);
            width2.GetValue().Should().Be(50);
            width3.GetValue().Should().Be(50);
            width4.GetValue().Should().Be(150);
            width5.GetValue().Should().Be(100);
            width6.GetValue().Should().Be(100);
            width7.GetValue().Should().Be(2000);
            width8.GetValue().Should().Be(0);
            exception7.Should().Be("입력 값이 2000보다 큽니다.");
            exception8.Should().Be("입력 값이 0보다 작습니다.");
        }
        #endregion

        #region DDD Height Value Test
        [Fact(DisplayName = "DDD Value - Artist.Height Test")]
        public void DDDTest_Height_Test()
        {
            // Arange

            // Act
            var height = new Height(0);
            var height2 = new Height(0, 0, 100);
            var height3 = new Height(50);
            height3.ModifyValue(100);
            var height4 = new Height(-100, -200, 0);

            // Assert
            height.GetValue().Should().Be(0);
            height2.GetValue().Should().Be(0);
            height3.GetValue().Should().Be(100);
            height4.GetValue().Should().Be(-100);
        }
        
        [Fact(DisplayName = "DDD Value - Artist.Height MinMax Test")]
        public void DDDTest_Height_MinMax_Test()
        {
            // Arange

            // Act
            var minHeight1 = new Height(-10);
            var minHeight2 = new Height(-10, 0, 100);
            var maxHeight1 = new Height(4000);
            var maxHeight2 = new Height(4000, 0, 100);
            var height1 = new Height(50, 30, 100);
            var height2 = new Height(50, 30, 100);
            height1.ModifyValue(25);
            height2.ModifyValue(150);

            // Assert
            minHeight1.GetValue().Should().Be(0);
            minHeight2.GetValue().Should().Be(0);
            maxHeight1.GetValue().Should().Be(2000);
            maxHeight2.GetValue().Should().Be(100);
            height1.GetValue().Should().Be(30);
            height2.GetValue().Should().Be(100);
        }
        
        [Fact(DisplayName = "DDD Value - Artist.Height After MinMax Test")]
        public void DDDTest_Height_After_MinMax_Test()
        {
            // Arange
            var height1 = new Height(100);
            var height2 = new Height(100);
            var height3 = new Height(100);
            var height4 = new Height(100);
            var height5 = new Height(100);
            var height6 = new Height(100);
            var height7 = new Height(100);
            var height8 = new Height(100);
            string exception7 = "";
            string exception8 = "";

            // Act
            height1.SetMinValue(150);
            height2.SetMaxValue(50);
            height3.SetMinMaxValue(50, 150);
            height3.ModifyValue(25);
            height4.SetMinMaxValue(50, 150);
            height4.ModifyValue(175);
            try
            {
                height5.SetMinValue(5000);
            }catch(Exception e) 
            {
                exception7 = e.Message;
            }
            try
            {
                height6.SetMaxValue(-100);
            }catch(Exception e)
            {
                exception8 = e.Message;
            }
            try
            {
                height7.SetMinValue(5000);
            }
            catch (Exception) { }
            height7.ModifyValue(4500);
            try
            {
                height8.SetMaxValue(-100);
            }
            catch (Exception) { }
            height8.ModifyValue(-50);

            // Assert
            height1.GetValue().Should().Be(150);
            height2.GetValue().Should().Be(50);
            height3.GetValue().Should().Be(50);
            height4.GetValue().Should().Be(150);
            height5.GetValue().Should().Be(100);
            height6.GetValue().Should().Be(100);
            height7.GetValue().Should().Be(2000);
            height8.GetValue().Should().Be(0);
            exception7.Should().Be("입력 값이 2000보다 큽니다.");
            exception8.Should().Be("입력 값이 0보다 작습니다.");
        }
        #endregion

        #region DDD Grid Value Test
        [Fact(DisplayName = "DDD Value - Artist.Grid Test")]
        public void DDDTest_Grid_Test()
        {
            // Arange

            // Act
            var grid = new Grid(0);
            var grid2 = new Grid(0, 0, 100);
            var grid3 = new Grid(50);
            var grid4 = new Grid(-100, -200, 0);
            var grid5 = new Grid(0);
            grid5.ModifyValue(100);

            // Assert
            grid.GetValue().Should().Be(0);
            grid2.GetValue().Should().Be(0);
            grid3.GetValue().Should().Be(50);
            grid4.GetValue().Should().Be(-100);
            grid5.GetValue().Should().Be(50);
        }

        [Fact(DisplayName = "DDD Value - Artist.Grid MinMax Test")]
        public void DDDTest_Grid_MinMax_Test()
        {
            // Arange

            // Act
            var minGrid1 = new Grid(-10);
            var minGrid2 = new Grid(-10, 0, 100);
            var maxGrid1 = new Grid(4000);
            var maxGrid2 = new Grid(4000, 0, 100);
            var grid1 = new Grid(50, 30, 100);
            var grid2 = new Grid(50, 30, 100);
            grid1.ModifyValue(25);
            grid2.ModifyValue(150);

            // Assert
            minGrid1.GetValue().Should().Be(0);
            minGrid2.GetValue().Should().Be(0);
            maxGrid1.GetValue().Should().Be(50);
            maxGrid2.GetValue().Should().Be(100);
            grid1.GetValue().Should().Be(30);
            grid2.GetValue().Should().Be(100);
        }

        [Fact(DisplayName = "DDD Value - Artist.Grid After MinMax Test")]
        public void DDDTest_Grid_After_MinMax_Test()
        {
            // Arange
            var grid1 = new Grid(10);
            var grid2 = new Grid(10);
            var grid3 = new Grid(10);
            var grid4 = new Grid(10);
            var grid5 = new Grid(10);
            var grid6 = new Grid(10);
            var grid7 = new Grid(10);
            var grid8 = new Grid(10);
            string exception7 = "";
            string exception8 = "";

            // Act
            grid1.SetMinValue(25);
            grid2.SetMaxValue(5);
            grid3.SetMinMaxValue(50, 150);
            grid4.SetMinMaxValue(50, 150);
            grid4.ModifyValue(175);
            try
            {
                grid5.SetMinValue(5000);
            }
            catch (Exception e)
            {
                exception7 = e.Message;
            }
            try
            {
                grid6.SetMaxValue(-100);
            }
            catch (Exception e)
            {
                exception8 = e.Message;
            }
            try
            {
                grid7.SetMinValue(5000);
            }
            catch (Exception) { }
            grid7.ModifyValue(4500);
            try
            {
                grid8.SetMaxValue(-100);
            }
            catch (Exception) { }
            grid8.ModifyValue(-50);

            // Assert
            grid1.GetValue().Should().Be(25);
            grid2.GetValue().Should().Be(5);
            grid3.GetValue().Should().Be(50);
            grid4.GetValue().Should().Be(150);
            grid5.GetValue().Should().Be(10);
            grid6.GetValue().Should().Be(10);
            grid7.GetValue().Should().Be(50);
            grid8.GetValue().Should().Be(0);
            exception7.Should().Be("입력 값이 50보다 큽니다.");
            exception8.Should().Be("입력 값이 0보다 작습니다.");
        }
        #endregion

        #region DDD Position Value Test
        [Fact(DisplayName = "DDD Value - Artist.Position Test")]
        public void DDDTest_Position_Test()
        {
            // Arange

            // Act
            var position = new Position(0);
            var position2 = new Position(0, 0, 100);
            var position3 = new Position(-2000);
            var position4 = new Position(-100, -200, 0);
            var position5 = new Position(0);
            position5.ModifyValue(2000);

            // Assert
            position.GetValue().Should().Be(0);
            position2.GetValue().Should().Be(0);
            position3.GetValue().Should().Be(-1000);
            position4.GetValue().Should().Be(-100);
            position5.GetValue().Should().Be(1000);
        }

        [Fact(DisplayName = "DDD Value - Artist.Position MinMax Test")]
        public void DDDTest_Position_MinMax_Test()
        {
            // Arange

            // Act
            var minPosition1 = new Position(-2000);
            var minPosition2 = new Position(-10, 0, 100);
            var maxPosition1 = new Position(4000);
            var maxPosition2 = new Position(4000, 0, 100);
            var position1 = new Position(50, 30, 100);
            var position2 = new Position(50, 30, 100);
            position1.ModifyValue(25);
            position2.ModifyValue(150);

            // Assert
            minPosition1.GetValue().Should().Be(-1000);
            minPosition2.GetValue().Should().Be(0);
            maxPosition1.GetValue().Should().Be(1000);
            maxPosition2.GetValue().Should().Be(100);
            position1.GetValue().Should().Be(30);
            position2.GetValue().Should().Be(100);
        }

        [Fact(DisplayName = "DDD Value - Artist.Position After MinMax Test")]
        public void DDDTest_Position_After_MinMax_Test()
        {
            // Arange
            var position1 = new Position(10);
            var position2 = new Position(10);
            var position3 = new Position(10);
            var position4 = new Position(10);
            var position5 = new Position(10);
            var position6 = new Position(10);
            var position7 = new Position(10);
            var position8 = new Position(10);
            string exception7 = "";
            string exception8 = "";

            // Act
            position1.SetMinValue(25);
            position2.SetMaxValue(-10);
            position3.SetMinMaxValue(50, 150);
            position4.SetMinMaxValue(50, 150);
            position4.ModifyValue(175);
            try
            {
                position5.SetMinValue(5000);
            }
            catch (Exception e)
            {
                exception7 = e.Message;
            }
            try
            {
                position6.SetMaxValue(-5000);
            }
            catch (Exception e)
            {
                exception8 = e.Message;
            }
            try
            {
                position7.SetMinValue(5000);
            }
            catch (Exception) { }
            position7.ModifyValue(4500);
            try
            {
                position8.SetMaxValue(-2000);
            }
            catch (Exception) { }
            position8.ModifyValue(-1500);

            // Assert
            position1.GetValue().Should().Be(25);
            position2.GetValue().Should().Be(-10);
            position3.GetValue().Should().Be(50);
            position4.GetValue().Should().Be(150);
            position5.GetValue().Should().Be(10);
            position6.GetValue().Should().Be(10);
            position7.GetValue().Should().Be(1000);
            position8.GetValue().Should().Be(-1000);
            exception7.Should().Be("입력 값이 1000보다 큽니다.");
            exception8.Should().Be("입력 값이 -1000보다 작습니다.");
        }
        #endregion

        #region DDD Point Value Test
        [Fact(DisplayName = "DDD Value - Artist.Point Test")]
        public void DDDTest_Point_Test()
        {
            // Arange

            // Act
            var point = new Point();
            var point2 = new Point(0, 0);
            var point3 = new Point(-2000, 2000);
            var point4 = new Point(0, 0);
            point4.X.ModifyValue(2000);
            point4.Y.ModifyValue(-2000);

            // Assert
            point.X.GetValue().Should().Be(0);
            point.Y.GetValue().Should().Be(0);
            point2.X.GetValue().Should().Be(0);
            point2.Y.GetValue().Should().Be(0);
            point3.X.GetValue().Should().Be(-1000);
            point3.Y.GetValue().Should().Be(1000);
            point4.X.GetValue().Should().Be(1000);
            point4.Y.GetValue().Should().Be(-1000);
        }

        [Fact(DisplayName = "DDD Value - Artist.Point MinMax Test")]
        public void DDDTest_Point_MinMax_Test()
        {
            // Arange

            // Act
            var minMaxPoint = new Point()
            {
                X = new Position(-10, 0, 100),
                Y = new Position(110, 0, 100)
            };
            var point = new Point() 
            {
                X = new Position(50, 30, 100),
                Y = new Position(50, 30, 100)
            };
            point.X.ModifyValue(25);
            point.Y.ModifyValue(150);

            // Assert
            minMaxPoint.X.GetValue().Should().Be(0);
            minMaxPoint.Y.GetValue().Should().Be(100);
            point.X.GetValue().Should().Be(30);
            point.Y.GetValue().Should().Be(100);
        }

        [Fact(DisplayName = "DDD Value - Artist.Point After MinMax Test")]
        public void DDDTest_Point_After_MinMax_Test()
        {
            // Arange
            var point1 = new Point(10, 10);
            var point2 = new Point(10, 10);
            var point3 = new Point(10, 10);
            var point4 = new Point(10, 10);
            var point5 = new Point(10, 10);
            string exception7 = "";
            string exception8 = "";

            // Act
            point1.X.SetMinValue(25);
            point1.Y.SetMinValue(75);
            point2.X.SetMaxValue(-10);
            point2.Y.SetMinMaxValue(50, 150);
            point3.X.SetMinMaxValue(50, 150);
            point3.X.ModifyValue(175);
            try
            {
                point3.Y.SetMinValue(5000);
            }
            catch (Exception e)
            {
                exception7 = e.Message;
            }
            try
            {
                point4.X.SetMaxValue(-5000);
            }
            catch (Exception e)
            {
                exception8 = e.Message;
            }
            try
            {
                point4.Y.SetMinValue(5000);
            }
            catch (Exception) { }
            point4.Y.ModifyValue(4500);
            try
            {
                point5.X.SetMaxValue(-2000);
            }
            catch (Exception) { }
            point5.X.ModifyValue(-1500);

            // Assert
            point1.X.GetValue().Should().Be(25);
            point1.Y.GetValue().Should().Be(75);
            point2.X.GetValue().Should().Be(-10);
            point2.Y.GetValue().Should().Be(50);
            point3.X.GetValue().Should().Be(150);
            point3.Y.GetValue().Should().Be(10);
            point4.X.GetValue().Should().Be(10);
            point4.Y.GetValue().Should().Be(1000);
            point5.X.GetValue().Should().Be(-1000);
            point5.Y.GetValue().Should().Be(10);
            exception7.Should().Be("입력 값이 1000보다 큽니다.");
            exception8.Should().Be("입력 값이 -1000보다 작습니다.");
        }
        #endregion
    }
}
