
namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    public SmallSquareMap(int size) : base(size, size) { }
    public SmallSquareMap(int sizeX, int sizeY) : base(sizeX, sizeY) 
    {
        if (sizeX != sizeY)
        {
            throw new ArgumentException("SmallMap must be square. SizeX must equal SizeY.");
        }
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
