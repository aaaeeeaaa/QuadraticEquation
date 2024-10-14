using Exercise1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Test
{
    public class QuadEqTests
    {
        [Theory]
        [InlineData(1, -2, 1, "x^2-2x+1=0")]
        [InlineData(-1, 3, -2, "-x^2+3x-2=0")]
        [InlineData(2, 0, -3, "2x^2-3=0")]
        [InlineData(1, 1, 1, "x^2+x+1=0")]
        [InlineData(1, 0, 0, "x^2=0")]
        [InlineData(0, 1, -1, "x-1=0")]
        public void GetQuadEqString_ShouldReturnCorrectString(float a, float b, float c, string expected)
        {
            // Arrange
            var quad = new QuadEq(a, b, c);

            // Act
            var result = quad.GetQuadEqString();

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(null, null, "Нет корней", "Нет корней")]
        [InlineData(1.0, null, "Один корень", "Один корень\nx = 1;")]
        [InlineData(2.0, 3.0, null, "x1 = 2; x2 = 3")]
        public void GetQuadResultsString_ShouldReturnCorrectString(object x1, object x2, string log, string expected)
        {
            // Arrange
            var quadResult = new QuadResult { X1 = x1, X2 = x2, log = log };

            var quad = new QuadEq(1, 1, 1) { Result = quadResult }; // Коэффициенты не важны для этого теста 
            
            // Act
            var result = quad.GetQuadResultsString();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
