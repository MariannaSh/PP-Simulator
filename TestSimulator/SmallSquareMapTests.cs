using Simulator;
using Simulator.Maps;
namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        // Arrange
        int size = 10;
        // Act
        var map = new SmallSquareMap(size);
        // Assert
        Assert.Equal(size, map.Size);
    }

    [Theory]
    [InlineData(4)] // Mniejszy niż minimalny rozmiar
    [InlineData(21)] // Większy niż maksymalny rozmiar

    public void
        Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException
        (int size)
    {
        // Act & Assert
        // The way to check if method throws anticipated exception:
        Assert.Throws<ArgumentOutOfRangeException>(() =>
             new SmallSquareMap(size));
    }

    [Theory]
    [InlineData(3, 4, 5, true)] 
    [InlineData(15, 15, 15, false)] 
    [InlineData(19, 19, 20, true)]
    [InlineData(15, 16, 14, false)]
    [InlineData(20, 20, 20, false)]

    public void Exist_ShouldReturnCorrectValue(int x, int y,
        int size, bool expected)
    {
        // Arrange
        var map = new SmallSquareMap(size);
        var point = new Point(x, y);
        // Act
        var result = map.Exist(point);
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(9,9, Direction.Up, 9,9)]
    [InlineData(0,0, Direction.Up, 0,1)]
    [InlineData(0,9, Direction.Left, 0,9)]
    [InlineData(3, 5, Direction.Left, 2, 5)]
    [InlineData(9,0, Direction.Right, 9,0)]
    [InlineData(7, 8, Direction.Right, 8, 8)]
    [InlineData(0, 0, Direction.Down, 0, 0)]
    [InlineData(9, 9, Direction.Down, 9, 8)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(10);
        var point = new Point(x, y);

        // Act
        var nextPoint = map.Next(point, direction);

        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(0,0, Direction.Up, 1,1)]
    [InlineData(19,19, Direction.Up, 19,19)]
    [InlineData(12,13, Direction.Right, 13,12)]
    [InlineData(19, 0, Direction.Right, 19, 0)]
    [InlineData(19, 19, Direction.Right, 19, 19)]
    [InlineData(12, 13, Direction.Left, 11, 14)]
    [InlineData(0, 19, Direction.Left, 0, 19)]
    [InlineData(0, 0, Direction.Down, 0, 0)]
    [InlineData(19, 19, Direction.Down, 18, 18)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(20);
        var point = new Point(x, y);
        // Act
        var nextPoint = map.NextDiagonal(point, direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

}
