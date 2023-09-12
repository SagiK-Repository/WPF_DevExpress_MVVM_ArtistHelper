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
                BoxCount = new Count<int>(1, 0, 10)
            };

            // Assert
            artist.Width.GetValue().Should().Be(10);
            artist.Height.GetValue().Should().Be(100);
            artist.LineGrid.GetValue().Should().Be(10);
            artist.MinWidth.GetValue().Should().Be(0);
            artist.MinHeight.GetValue().Should().Be(0);
            artist.EndPoint.X.GetValue().Should().Be(0);
            artist.EndPoint.Y.GetValue().Should().Be(0);
            artist.BoxCount.GetValue().Should().Be(1);
        }
        #endregion

        #region DDD Width Value Test
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
        
        [InlineData(1.0, 1.0)] // 일반 부여
        [InlineData(4000.0, 2000.0)] // 최대 초과
        [InlineData(-2000.0, 0.0)] // 최소 초과
        [Theory(DisplayName = "DDD Value : Artist.Width<double> Value Test")]
        public void DDDTest_Width_double_Test(double value, double outValue)
        {
            // Arange

            // Act
            var width = new Width<double>(value);

            // Assert
            width.GetValue().Should().Be(outValue);
        }
        
        [InlineData(1.0, 0.0, 2.0, 1.0)] // 일반 부여
        [InlineData(1.0, 100.0, 200.0, 100.0)] // 최소 초과
        [InlineData(1.0, -100.0, -10.0, -10.0)] // 최대 초과
        [Theory(DisplayName = "DDD Value : Artist.Width<double> MinMax Value Test")]
        public void DDDTest_Width_double_MinMax_Test(double value, double minValue, double maxValue, double outValue)
        {
            // Arange

            // Act
            var width = new Width<double>(value, minValue, maxValue);

            // Assert
            width.GetValue().Should().Be(outValue);
        }

        [InlineData(1.0, 4000.0, 2.0, 1.0,
            "입력 값이 2000보다 큽니다.")] // 최소 예외
        [InlineData(1.0, 0.0, -100.0, 1.0,
            "입력 값이 0보다 작습니다.")] // 최대 예외
        [Theory(DisplayName = "DDD Value : Artist.Width<double> Exception Test")]
        public void DDDTest_Width_double_Exception_Test(double value, double minValue, double maxValue, double outValue, string exceptionMessage)
        {
            // Arange
            string exception = string.Empty;
            var width = new Width<double>(value);

            // Act
            try
            {
                width.SetMinMaxValue(minValue, maxValue);
            }
            catch(Exception ex)
            {
                exception = ex.Message;
            }

            // Assert
            width.GetValue().Should().Be(outValue);
            exception.Should().Be(exceptionMessage);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 1)]
        public void Width_Constructor_ShouldThrowException(double minValue, double maxValue)
        {
            // Arrange

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Width<double>(0.0f, minValue, maxValue));
        }
        #endregion

        #region DDD Height Value Test
        [InlineData(1, 1.0)] // 일반 부여
        [InlineData(4000, 2000.0)] // 최대 초과
        [InlineData(-2000, 0.0)] // 최소 초과
        [Theory(DisplayName = "DDD Value : Artist.Height<int> Value Test")]
        public void DDDTest_Height_int_Test(object value, double outValue)
        {
            // Arange

            // Act
            var height = new Height<int>(Convert.ToInt32(value));

            // Assert
            height.GetValue().Should().Be(outValue);
        }

        [InlineData(1.0, 1.0)] // 일반 부여
        [InlineData(4000.0, 2000.0)] // 최대 초과
        [InlineData(-2000.0, 0.0)] // 최소 초과
        [Theory(DisplayName = "DDD Value : Artist.Height<double> Value Test")]
        public void DDDTest_Height_double_Test(double value, double outValue)
        {
            // Arange

            // Act
            var height = new Height<double>(value);

            // Assert
            height.GetValue().Should().Be(outValue);
        }

        [InlineData(1.0, 0.0, 2.0, 1.0)] // 일반 부여
        [InlineData(1.0, 100.0, 200.0, 100.0)] // 최소 초과
        [InlineData(1.0, -100.0, -10.0, -10.0)] // 최대 초과
        [Theory(DisplayName = "DDD Value : Artist.Height<double> MinMax Value Test")]
        public void DDDTest_Height_double_MinMax_Test(double value, double minValue, double maxValue, double outValue)
        {
            // Arange

            // Act
            var height = new Height<double>(value, minValue, maxValue);

            // Assert
            height.GetValue().Should().Be(outValue);
        }
        #endregion

        #region DDD Grid Value Test
        [InlineData(1, 1.0)] // 일반 부여
        [InlineData(100, 50.0)] // 최대 초과
        [InlineData(-100, 0.0)] // 최소 초과
        [Theory(DisplayName = "DDD Value : Artist.Grid<int> Value Test")]
        public void DDDTest_Grid_int_Test(object value, double outValue)
        {
            // Arange

            // Act
            var grid = new Grid<int>(Convert.ToInt32(value));

            // Assert
            grid.GetValue().Should().Be(outValue);
        }

        [InlineData(1.0, 1.0)] // 일반 부여
        [InlineData(100.0, 50.0)] // 최대 초과
        [InlineData(-100.0, 0.0)] // 최소 초과
        [Theory(DisplayName = "DDD Value : Artist.Grid<double> Value Test")]
        public void DDDTest_Grid_double_Test(double value, double outValue)
        {
            // Arange

            // Act
            var grid = new Grid<double>(value);

            // Assert
            grid.GetValue().Should().Be(outValue);
        }

        [InlineData(1.0, 0.0, 2.0, 1.0)] // 일반 부여
        [InlineData(1.0, 100.0, 200.0, 100.0)] // 최소 초과
        [InlineData(1.0, -100.0, -10.0, -10.0)] // 최대 초과
        [Theory(DisplayName = "DDD Value : Artist.Grid<double> MinMax Value Test")]
        public void DDDTest_Grid_double_MinMax_Test(double value, double minValue, double maxValue, double outValue)
        {
            // Arange

            // Act
            var grid = new Grid<double>(value, minValue, maxValue);

            // Assert
            grid.GetValue().Should().Be(outValue);
        }
        #endregion

        #region DDD Position Value Test
        [InlineData(1, 1.0)] // 일반 부여
        [InlineData(2000, 1000.0)] // 최대 초과
        [InlineData(-1000, -1000.0)] // 최소 초과
        [Theory(DisplayName = "DDD Value : Artist.Position<int> Value Test")]
        public void DDDTest_Position_int_Test(object value, double outValue)
        {
            // Arange

            // Act
            var position = new Position<int>(Convert.ToInt32(value));

            // Assert
            position.GetValue().Should().Be(outValue);
        }

        [InlineData(1.0, 1.0)] // 일반 부여
        [InlineData(2000.0, 1000.0)] // 최대 초과
        [InlineData(-1000.0, -1000.0)] // 최소 초과
        [Theory(DisplayName = "DDD Value : Artist.Position<double> Value Test")]
        public void DDDTest_Position_double_Test(double value, double outValue)
        {
            // Arange

            // Act
            var position = new Position<double>(value);

            // Assert
            position.GetValue().Should().Be(outValue);
        }

        [InlineData(1.0, 0.0, 2.0, 1.0)] // 일반 부여
        [InlineData(1.0, 100.0, 200.0, 100.0)] // 최소 초과
        [InlineData(1.0, -1000.0, 1000.0, 1.0)] // 최대 초과
        [Theory(DisplayName = "DDD Value : Artist.Position<double> MinMax Value Test")]
        public void DDDTest_Position_double_MinMax_Test(double value, double minValue, double maxValue, double outValue)
        {
            // Arange

            // Act
            var position = new Position<double>(value, minValue, maxValue);

            // Assert
            position.GetValue().Should().Be(outValue);
        }
        #endregion

        #region DDD Count Value Test
        [InlineData(1, 1)] // 일반 부여
        [InlineData(200, 100)] // 최대 초과
        [InlineData(-100, 0)] // 최소 초과
        [Theory(DisplayName = "DDD Value : Artist.Count<int> Value Test")]
        public void DDDTest_Count_int_Test(object value, int outValue)
        {
            // Arange

            // Act
            var count = new Count<int>(Convert.ToInt32(value));

            // Assert
            count.GetValue().Should().Be(outValue);
        }

        [InlineData(1, 0, 2, 1)] // 일반 부여
        [InlineData(1, 100, 200, 100)] // 최소 초과
        [InlineData(1, -100, -10, -10)] // 최대 초과
        [Theory(DisplayName = "DDD Value : Artist.Count<T> MinMax Value Test")]
        public void DDDTest_Count(object value, int minValue, int maxValue, int outValue)
        {
            // Arange

            // Act
            var count = new Count<int>(Convert.ToInt32(value), minValue, maxValue);

            // Assert
            count.GetValue().Should().Be(outValue);
        }
        #endregion
    }
}
