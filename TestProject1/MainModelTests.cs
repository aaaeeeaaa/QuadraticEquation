using Exercise1.Entities;
using Exercise1.Models;

namespace Exercise1.Test
{
    public class MainModelTests
    {

        [Theory]
        [InlineData("1 2 1\n2 3 1\n3 4 1", 3)] // Три корректных уравнения
        [InlineData("", 0)] // Пустая строка
        [InlineData("invalid input", 0)] // Некорректная строка
        [InlineData("1 2 1\ninvalid\n3 4 1", 2)] // Смешанный ввод: две корректные строки, одна некорректная
        public void GetQuadEqs_TheoryTests(string input, int expectedCount)
        {
            // Arrange
            var @class = new MainModel();

            // Act
            var result = @class.GetQuadEqs(input);

            // Assert
            if (expectedCount == 0)
            {
                Assert.Null(result);
            }
            else
            {
                Assert.NotNull(result);
                Assert.Equal(expectedCount, result.Count);
            }
        }


        [Theory]
        [InlineData("1 2 3", 1f, 2f, 3f, "")]
        [InlineData("1.5 2.5 3.5", 1.5f, 2.5f, 3.5f, "")]//Точки
        [InlineData("1,5 2,5 3,5", 1.5f, 2.5f, 3.5f, "")]
        [InlineData("1 2", null, null, null, null)] //Неполный список коэффициентов
        [InlineData("invalid input", null, null, null, null)] //Некорректный ввод
        public void GetQuadEq_ShouldReturnExpectedResult(string input, float? expectedA, float? expectedB, float? expectedC, string expectedLog)
        {
            // Arrange
            var @class = new MainModel();

            // Act
            var result = @class.GetQuadEq(input);

            // Assert
            if (expectedA == null || expectedB == null || expectedC == null)
            {
                Assert.Null(result);
            }
            else
            {
                Assert.NotNull(result);
                Assert.Equal(expectedA, result.A);
                Assert.Equal(expectedB, result.B);
                Assert.Equal(expectedC, result.C);
                Assert.Equal(expectedLog, result.Log);
            }
        }
    }
}