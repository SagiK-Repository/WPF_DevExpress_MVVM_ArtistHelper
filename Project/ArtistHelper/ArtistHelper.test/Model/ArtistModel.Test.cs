using ArtistHelper.Model;
using FluentAssertions;
using System;
using Xunit;

namespace ArtistHelper.test.Model
{
    public class ArtistModel_Test
    {
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
    }
}
