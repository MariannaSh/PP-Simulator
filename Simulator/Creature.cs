namespace Simulator;

internal class Creature
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
                value = value.Trim(); 
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                _name = "###";
            }
            else
            {
                
                if (value.Length > 25)
                {
                    value = value.Substring(0, 25).TrimEnd();
                }

                
                if (value.Length < 3)
                {
                    value = value.PadRight(3, '#');
                }

                
                if (char.IsLower(value[0]))
                {
                    value = char.ToUpper(value[0]) + value.Substring(1);
                }

                _name = value; 
            }
        }
    }


    public int Level
    {
        get => _level;
        init
        {
            if (value < 1)
                _level = 1;
            else if (value > 10)
                _level = 10;
            else
                _level = value;
        }
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

    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }

    public string Info => $"{Name} [{Level}]";


}

