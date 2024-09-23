using App;
using Xunit.Abstractions;

namespace Tests
{
    public class ValidatorTests(ITestOutputHelper output)
    {
        private readonly ITestOutputHelper _output = output;

        [Theory]
        [InlineData(1.234, 3)]
        [InlineData(1.2341111, 7)]
        [InlineData(1.1234567891234567, 16)]
        public void ValidateDecimalPlaces_ValidInputs_ReturnsExpectedResult(double number, int maxDecimalPlaces)
        {
            Validator.ValidateDecimalPlaces(number, maxDecimalPlaces);
            _output.WriteLine("Testing with number: {number} and maxDecimalPlaces: {maxDecimalPlaces} - PASSED");
        }

        [Theory]
        [InlineData(1.234, 2)]
        public void ValidateDecimalPlaces_NumberHasMoreDecimalPlaces_ThrowsInvalidOperationException(double number, int maxDecimalPlaces)
        {
            Assert.Throws<InvalidOperationException>(() => Validator.ValidateDecimalPlaces(number, maxDecimalPlaces));
            _output.WriteLine($"Testing with number: {number} and maxDecimalPlaces: {maxDecimalPlaces} - PASSED");
        }
    }
}
