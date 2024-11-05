
namespace Simulator;

public class Orc : Creature
{
    private int _rage;
    private int _huntCount = 0;

    public int Rage
    {
        get => _rage;
        set
        {
            if (value < 0) _rage = 0;
            else if (value > 10) _rage = 10;
            else _rage = value;
        }
    }


    public void Hunt()
    {
        Console.WriteLine($"{Name} is hunting.");
        _huntCount++;

        if(_huntCount%2 == 0) { Rage++; }

    }

    public Orc() : base() { }

    public Orc(string name, int level = 1, int rage = 1)
        :base(name, level)
    {
        Rage = rage;
    }

    public override void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");
    }

    public override int Power
    {
        get { return 7 * Level + 3 * Rage; }
    }


}
