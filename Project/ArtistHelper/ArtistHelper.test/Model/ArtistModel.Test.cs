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
        
        [InlineData(1.0, 1.0)]
        [InlineData(1000.0, 1000.0)]
        [InlineData(4000.0, 2000.0)]
        [InlineData(-2000.0, 0.0)]
        [Theory(DisplayName = "DDD Value : Artist.Width<double> Value Test")]
        public void DDDTest_Width_double_Test(object value, double outValue)
        {
            // Arange

            // Act
            var width = new Width<double>(Convert.ToDouble(value));

            // Assert
            width.GetValue().Should().Be(outValue);
        }
        #endregion
    }
}
