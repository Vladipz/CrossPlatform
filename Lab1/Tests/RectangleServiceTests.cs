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
        public void GetCountOfRectangles_WhenCalledWithValidArguments_ReturnsCountOfRectangles(int w, int h, int expected)
        {
            // Act
            var result = RectanglesService.GetCountOfRectangles(w, h);

            // Assert
            Assert.Equal(expected, result);
            _output.WriteLine($"{nameof(GetCountOfRectangles_WhenCalledWithValidArguments_ReturnsCountOfRectangles)}w: {w}, h: {h}, result: {result} - passed");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1001)]
        public void GetCountOfRectangles_WhenCalledWithInvalid_W_Arguments_ThrowsArgumentOutOfRangeException(int w)
        {
            // Act
            int h = 1;
            void Act() => RectanglesService.GetCountOfRectangles(w, h);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(Act);
            _output.WriteLine($"{nameof(GetCountOfRectangles_WhenCalledWithInvalid_W_Arguments_ThrowsArgumentOutOfRangeException)}w: {w} - passed");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1001)]
        public void GetCountOfRectangles_WhenCalledWithInvalid_H_Arguments_ThrowsArgumentOutOfRangeException(int h)
        {
            // Act
            int w = 1;
            void Act() => RectanglesService.GetCountOfRectangles(w, h);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(Act);
            _output.WriteLine($"{nameof(GetCountOfRectangles_WhenCalledWithInvalid_W_Arguments_ThrowsArgumentOutOfRangeException)}h: {h} - passed");
        }
    }
}
