namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    private readonly List<Creature>? [,] _fields ; //tablica creature ktora moze byc null

    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20) { throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too wide"); }

        if (sizeY > 20) { throw new ArgumentOutOfRangeException(nameof(sizeY), "Map too hight"); }

        _fields = new List<Creature>?[sizeX, sizeY];
    }

    public override void Add(Creature creature, Point position)
    {
        if (!Exist(position))
            throw new ArgumentOutOfRangeException("Pozycja jest poza granicami mapy.");

        if (_fields[position.X, position.Y] == null)
            _fields[position.X, position.Y] = new List<Creature>();

        _fields[position.X, position.Y]!.Add(creature); // Dodajemy stwora do listy
    }

    public override void Remove(Creature creature, Point position)
    {
        if (!Exist(position))
            throw new ArgumentException("Pozycja poza mapą.");

        _fields[position.X, position.Y]?.Remove(creature);
        if (_fields[position.X, position.Y]?.Count == 0)
            _fields[position.X, position.Y] = null;
    }

    public override List<Creature>? At(Point position)
    {
        if (!Exist(position))
            throw new ArgumentOutOfRangeException("Pozycja jest poza granicami mapy.");

        return _fields[position.X, position.Y]; // Zwraca listę stworów lub null
    }

    public override List<Creature>? At(int x, int y)
    {
        return At(new Point(x, y));
    }

}
