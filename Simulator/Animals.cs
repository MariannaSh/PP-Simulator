namespace Simulator;

internal class Animals
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
                value = "###";
            }
            else
            {
                value = value.Trim();

                if (value.Length > 15) 
                {
                    value = value.Substring(0, 15).TrimEnd();
                }

                while (value.Length < 3)
                {
                    value += "#";
                }
            }

            if (char.IsLower(value[0]))
            {
                value = char.ToUpper(value[0]) + value.Substring(1);
            }

            _description = value;
        }
    }

    public string Info => $"{Description} <{Size}>";
}

