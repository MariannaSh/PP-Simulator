using Simulator.Maps;


namespace SimConsole;

public class MovementRecord
{
    public IMappable Mappable { get; }
    public string Direction { get; }

    public MovementRecord(IMappable mappable, string direction)
    {
        Mappable = mappable;
        Direction = direction;
    }
}