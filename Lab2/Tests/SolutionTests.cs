using App;

namespace Tests
{
    public class SolutionTests
    {
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
        }

        [Theory]
        [MemberData(nameof(TestCases2))]
        public void ValidateArray_ArrayLengthDoesNotMatchN_ThrowsInvalidOperationException(double[] inputArray, int n)
        {
            // Act
            void act() => Solution.FindProbability(inputArray, n);

            // Assert
            Assert.Throws<InvalidOperationException>(act);
        }
    }
}
