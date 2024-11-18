using Simulator;
namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ShouldCreateRectangle_FromPoints()
    {
        // Arrange
        var p1 = new Point(1, 1);
        var p2 = new Point(4, 4);

        // Act
        var rect = new Rectangle(p1, p2);

        // Assert
        Assert.Equal(1, rect.X1);
        Assert.Equal(1, rect.Y1);
        Assert.Equal(4, rect.X2);
        Assert.Equal(4, rect.Y2);
    }

    [Fact]
    public void ToString_ShouldReturnCorrectStringRepresentation()
    {
        // Arrange
        var rect = new Rectangle(1, 1, 5, 5);

        // Act
        var result = rect.ToString();

        // Assert
        Assert.Equal("(1, 1):(5, 5)", result);
    }

    [Theory]
    [InlineData(0, 0, 0, 5)]   // x1 == x2
    [InlineData(0, 0, 5, 0)]   // y1 == y2
    public void Constructor_ShouldThrowArgumentException_WhenInvalidRectangle(int x1, int y1, int x2, int y2)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
    }

    [Theory]
    [InlineData(1, 1, 4, 4, 2, 2, true)] 
    [InlineData(1, 1, 4, 4, 0, 0, false)] 
    [InlineData(1, 1, 4, 4, 5, 5, false)] 
    [InlineData(1, 1, 4, 4, 4, 4, true)] 
    public void Contains_ShouldReturnCorrectResult(int x1, int y1, int x2, int y2, int px, int py, bool expected)
    {
        // Arrange
        var rectangle = new Rectangle(x1, y1, x2, y2);
        var point = new Point(px, py);

        //Act
        var result = rectangle.Contains(point);

        // Assert
        Assert.Equal(expected, result);
    }

}
