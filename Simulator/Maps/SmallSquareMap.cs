
namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    public readonly int Size;

    private readonly Rectangle _borders;

    public SmallSquareMap(int size)
    {

        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(size),
                "Rozmiar musi wynosić między 5 a 20");
        }
        Size = size;
        _borders = new Rectangle(0, 0, Size - 1, Size - 1);
    }

    public override bool Exist(Point p)
    {
        return _borders.Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {

        Point newPoint = p.Next(d);

        return Exist(newPoint) ? newPoint : p;

    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point newPoint = p.NextDiagonal(d);

        return Exist(newPoint) ? newPoint : p; 
    }

}
