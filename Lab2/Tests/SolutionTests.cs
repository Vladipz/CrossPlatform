using App;
using Xunit.Abstractions;

namespace Tests
{
    public class SolutionTests(ITestOutputHelper output)
    {
        private readonly ITestOutputHelper _output = output;

        private static readonly double[] TestArray1 = [1, 0.1, 0.9];
        private static readonly double[] TestArray2 = [1.0, 1.0, 1.0];
        private static readonly double[] TestArray3 = [0.0, 0.0, 0.0];

        public static IEnumerable<object[]> TestCases =>
        [
            [TestArray1, 3, 0.18],
            [TestArray2, 3, 1.0],
            [TestArray3, 3, 0.0],
        ];
        public static IEnumerable<object[]> TestCases2 =>
        [
          [TestArray1, 2],
          [TestArray2, 2],
          [TestArray3, -1],
        ];

        [Theory]
        [MemberData(nameof(TestCases))]
        public void FindProbability_ValidInputs_ReturnsExpectedResult(double[] inputArray, int n, double expected)
        {
            // Act
            var result = Solution.FindProbability(inputArray, n);

            // Assert
            Assert.Equal(expected, result, 3);
            _output.WriteLine($"{nameof(FindProbability_ValidInputs_ReturnsExpectedResult)}: Expected: {expected}, Actual: {result} - PASSED");
        }

        [Theory]
        [MemberData(nameof(TestCases2))]
        public void ValidateArray_ArrayLengthDoesNotMatchN_ThrowsInvalidOperationException(double[] inputArray, int n)
        {
            // Act
            void act() => Solution.FindProbability(inputArray, n);

            // Assert
            Assert.Throws<InvalidOperationException>(act);
            _output.WriteLine($"{nameof(ValidateArray_ArrayLengthDoesNotMatchN_ThrowsInvalidOperationException)}: PASSED");
        }
    }
}
