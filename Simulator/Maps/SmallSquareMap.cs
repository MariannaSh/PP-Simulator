
namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    public int Size { get; private set; }

    public SmallSquareMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Rozmiar mapy musi być pomiędzy 5 a 20.");
        }
        Size = size;
    }

    public override bool Exist(Point p)
    {
        return (p.X >= 0 && p.X < Size)
               && (p.Y >= 0 && p.Y < Size);
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
