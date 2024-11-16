namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public readonly int Size;

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Rozmiar musi wynosić między 5 a 20");
        }
        Size = size;
    }

    public override bool Exist(Point p)
    {
        return p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;
    }
    public override Point Next(Point p, Direction d)
    {
        Point newPoint = p.Next(d);

        if (newPoint.X < 0) newPoint = new Point(Size - 1, newPoint.Y); // X wychodzi poza lewy brzeg
        if (newPoint.X >= Size) newPoint = new Point(0, newPoint.Y); // X wychodzi poza prawy brzeg
        if (newPoint.Y < 0) newPoint = new Point(newPoint.X, Size - 1); // Y wychodzi poza górny brzeg
        if (newPoint.Y >= Size) newPoint = new Point(newPoint.X, 0); // Y wychodzi poza dolny brzeg

        return newPoint;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point newDiagonalPoint = p.NextDiagonal(d);

        if (newDiagonalPoint.X < 0) newDiagonalPoint = new Point(Size - 1, newDiagonalPoint.Y); 
        if (newDiagonalPoint.X >= Size) newDiagonalPoint = new Point(0, newDiagonalPoint.Y); 
        if (newDiagonalPoint.Y < 0) newDiagonalPoint = new Point(newDiagonalPoint.X, Size - 1); 
        if (newDiagonalPoint.Y >= Size) newDiagonalPoint = new Point(newDiagonalPoint.X, 0); 

        return newDiagonalPoint;
    }
}
