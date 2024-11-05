namespace Simulator;

public abstract class Creature
{
    private string _name = "Unknown";
    private int _level = 1;

    public string Name
    {
        get => _name;
        init
        {

            if (value == null) 
            {
                value = "###"; 
            }
            else
            {
                _name = Validator.Shortener(value.Trim(), 3, 25, '#');
                if (_name.Length > 0 && char.IsLower(_name[0]))
                {
                    _name = char.ToUpper(_name[0]) + _name.Substring(1);
                }
            }
        }
    }


    public int Level
    {
        get => _level;
        init => _level = Validator.Limiter(value, 1, 10);
    }

    public void Upgrade()
    {
        if (_level < 10)
        {
            _level++;
        }
    }


    public Creature(string name = "Unknown", int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public abstract void SayHi();

    public abstract string Info { get; }


    public void Go(Direction direction) 
    {
        Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}.");   
    }

    public void Go(Direction[] directions)
    {
        for (int i = 0; i<directions.Length; i++)
        {
            Go(directions[i]);
        }
    }

    public void Go(string direction)
    {
        Go(DirectionParser.Parse(direction));
    }


    public abstract int Power { get; }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

}

