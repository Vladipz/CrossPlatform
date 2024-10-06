using App;
using Xunit.Abstractions;

namespace Tests
{
    public class RectangleServiceTests(ITestOutputHelper output)
    {
        private readonly ITestOutputHelper _output = output;

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 1, 3)]
        [InlineData(2, 2, 9)]
        public void GetCountOfRectanglesWhenCalledWithValidArgumentsReturnsCountOfRectangles(int w, int h, int expected)
        {
            // Act
            var result = RectanglesService.GetCountOfRectangles(w, h);

            // Assert
            Assert.Equal(expected, result);
            _output.WriteLine($"{nameof(GetCountOfRectanglesWhenCalledWithValidArgumentsReturnsCountOfRectangles)}w: {w}, h: {h}, result: {result} - passed");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1001)]
        public void GetCountOfRectanglesWhenCalledWithInvalidWArgumentsThrowsArgumentOutOfRangeException(int w)
        {
            // Act
            int h = 1;
            void Act() => RectanglesService.GetCountOfRectangles(w, h);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(Act);
            _output.WriteLine($"{nameof(GetCountOfRectanglesWhenCalledWithInvalidWArgumentsThrowsArgumentOutOfRangeException)}w: {w} - passed");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1001)]
        public void GetCountOfRectanglesWhenCalledWithInvalidHArgumentsThrowsArgumentOutOfRangeException(int h)
        {
            // Act
            int w = 1;
            void Act() => RectanglesService.GetCountOfRectangles(w, h);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(Act);
            _output.WriteLine($"{nameof(GetCountOfRectanglesWhenCalledWithInvalidWArgumentsThrowsArgumentOutOfRangeException)}h: {h} - passed");
        }
    }
}
