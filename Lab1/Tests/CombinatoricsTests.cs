using App;
using Xunit.Abstractions;

namespace Tests
{
    public class CombinatoricsTests(ITestOutputHelper output)
    {

        private readonly ITestOutputHelper _output = output;

        [Theory]
        [InlineData(0, 0)] // (0 + 1) * 0 / 2 = 0
        [InlineData(1, 1)] // (1 + 1) * 1 / 2 = 1
        [InlineData(2, 3)] // (2 + 1) * 2 / 2 = 3
        [InlineData(3, 6)] // (3 + 1) * 3 / 2 = 6
        [InlineData(4, 10)] // (4 + 1) * 4 / 2 = 10
        [InlineData(5, 15)] // (5 + 1) * 5 / 2 = 15
        [InlineData(10, 55)] // (10 + 1) * 10 / 2 = 55
        [InlineData(100, 5050)] // (100 + 1) * 100 / 2 = 5050
        public void CombinationsWithouRepetition_ValidInputs_ReturnsExpectedResult(ulong n, ulong expected)
        {
            // Act
            var result = Combinatorics.CombinationsWithouRepetition(n);

            // Assert
            Assert.Equal(expected, result);

            _output.WriteLine($"{nameof(CombinationsWithouRepetition_ValidInputs_ReturnsExpectedResult)}n: {n}, result: {result} - passed");
        }

    }
}
