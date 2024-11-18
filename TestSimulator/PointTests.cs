using Simulator;
namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Constructor_ShouldInitializePointCorrectly()
    {
        //Arrange
        int x = 5; int y=10;

        //Act
        var point = new Point(x, y);

        //Assert
        Assert.Equal(x, point.X);
        Assert.Equal(y, point.Y);
    }

    [Theory]
    [InlineData(9, 9, Direction.Up, 9, 10)]
    [InlineData(0, 0, Direction.Up, 0, 1)]
    [InlineData(0, 9, Direction.Left, -1, 9)]
    [InlineData(3, 5, Direction.Left, 2, 5)]
    [InlineData(9, 0, Direction.Right, 10, 0)]
    [InlineData(7, 8, Direction.Right, 8, 8)]
    [InlineData(0, 0, Direction.Down, 0, -1)]
    [InlineData(9, 9, Direction.Down, 9, 8)]
    public void Next_ShouldReturnCorrectPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var point = new Point(x, y);

        // Act
        var result = point.Next(direction);

        // Assert
        Assert.Equal(new Point(expectedX, expectedY), result);
    }

    [Theory]
    [InlineData(0, 0, Direction.Up, 1, 1)]
    [InlineData(19, 19, Direction.Up, 20, 20)]
    [InlineData(12, 13, Direction.Right, 13, 12)]
    [InlineData(19, 0, Direction.Right, 20, -1)]
    [InlineData(19, 19, Direction.Right, 20, 18)]
    [InlineData(12, 13, Direction.Left, 11, 14)]
    [InlineData(0, 19, Direction.Left, -1, 20)]
    [InlineData(0, 0, Direction.Down, -1, -1)]
    [InlineData(19, 19, Direction.Down, 18, 18)]
    public void NextDiagonal_ShouldReturnCorrectPoint(int x, int y, Direction d,
        int expectedX, int expectedY)
    {
        //Arrange
        var point = new Point(x, y);

        //Act
        var result = point.NextDiagonal(d);

        //Assert
        Assert.Equal(new Point(expectedX, expectedY), result);
    }

    [Theory]
    [InlineData(5, 5, (Direction)100)]
    [InlineData(5, 5, (Direction)(-1))]
    public void InvalidDirection_ShouldReturnOriginalPoint(int x, int y, Direction direction)
    {
        // Arrange
        var point = new Point(x, y);

        // Act
        var nextPoint = point.Next(direction);
        var diagonalPoint = point.NextDiagonal(direction);

        // Assert
        Assert.Equal(point, nextPoint);
        Assert.Equal(point, diagonalPoint);
    }

    }
