using Simulator;
using Xunit;

namespace TestSimulator
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData(5, 0, 10, 5)]  // Wartość w zakresie
        [InlineData(-1, 0, 10, 0)] // Wartość poniżej zakresu
        [InlineData(15, 0, 10, 10)] // Wartość powyżej zakresu
        public void Limiter_ShouldClampValue(int value, int min, int max, int expected)
        {
            // Act
            var result = Validator.Limiter(value, min, max);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("example", 3, 10, '#', "Example")] // Normalny tekst
        [InlineData(" short ", 3, 10, '#', "Short")] // Usunięcie białych znaków
        [InlineData("averylongstringvalue", 3, 9, '#', "Averylong")] // Skrócenie tekstu
        [InlineData("x", 5, 10, '#', "X####")] // Uzupełnienie tekstu
        [InlineData("", 3, 10, '#', "###")] // Pusty tekst
        public void Shortener_ShouldFormatStringCorrectly(string value, int min, int max, char placeholder, string expected)
        {
            // Act
            var result = Validator.Shortener(value, min, max, placeholder);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}