namespace Simulator;

public class Animals
{
    private string _description = "Unknown";
    public uint Size { get; set; } = 3;

    public required string Description
    {
        get => _description;

        init
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _description = "###";
            }
            else
            {
                _description = Validator.Shortener(value, 3, 15, '#');
            }

            if (_description.Length > 0 && char.IsLower(_description[0]))
            {
                _description = char.ToUpper(_description[0]) + _description.Substring(1);
            }
        }
    }

    public virtual string Info => $"{Description} <{Size}>";

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}

