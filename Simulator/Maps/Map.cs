﻿
namespace Simulator.Maps;
/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    //Add(IMappable, Point)
    //Remove(IMappable, Point)
    //Move(),
    //At(Point) albo x, y 

    private readonly Rectangle _borders;
    public int SizeX { get; }
    public int SizeY { get; }

    protected Map(int sizeX, int sizeY) 
    {

        if (sizeX < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow");
        }
        if (sizeY < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Too short");
        }

        SizeX = sizeX;
        SizeY = sizeY;
        _borders = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }



    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p) =>_borders.Contains(p);

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);


    public abstract void Add(IMappable mappable, Point position);

    public abstract void Remove(IMappable mappable, Point position);

    public void Move(IMappable mappable, Point from, Point to)
    {
        if (!Exist(from) || !Exist(to)) throw new ArgumentException("Jedna z pozycji jest poza mapą!");
        Remove(mappable, from);
        Add(mappable, to);
    }

    public abstract List<IMappable>? At(Point position);

    public abstract List<IMappable>? At(int x, int y);

}