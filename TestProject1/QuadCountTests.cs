using Exercise1.Entities;
using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Test
{
    public class QuadCountTests
    {

        [Theory]
        [InlineData(1, -2, 1, 1.0f, null, "Один корень. Дискриминант = 0")]
        [InlineData(1, -3, 2, 2.0f, 1.0f, null)] // Два корня: x1 = 2, x2 = 1
        [InlineData(1, 0, 1, null, null, "Нет корней. Отрицательный дискриминант")]
        public void Count_ShouldCalculateRootsCorrectly(float a, float b, float c, float? expectedX1, float? expectedX2, string expectedLog)
        {
            // Arrange
            var quad = new QuadEq(a, b, c);
            var yourClass = new QuadCount();

            // Act
            yourClass.Count(quad);

            // Assert
            Assert.Equal(expectedX1, quad.Result.X1 as float?);
            Assert.Equal(expectedX2, quad.Result.X2 as float?);
            Assert.Equal(expectedLog, quad.Result.log);
        }
    }
}
