using Simulator.Maps;

namespace Simulator;

public abstract class Creature
{
    public Map? Map { get; private set; }
    public Point Position {get; private set;}

    public void InitMapAndPosition(Map map, Point position) { }

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


    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public string Greeting { get; }

    public abstract string Info { get; }


    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";

    public string[] Go(Direction[] directions)
    {
        //Map.Next()
        //Map.Next() == Position - > bez ruchu
        //Map.Move()


        var result = new string[directions.Length];
        for (int i = 0; i<directions.Length; i++)
        {
            result[i] = Go(directions[i]);
        }
        return result;
    }

    public abstract int Power { get; }

    //out
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

}

