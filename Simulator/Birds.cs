namespace Simulator;

internal class Birds : Animals
{
    public bool CanFly { get; set; } = true;

    public Birds(string description, uint size, bool canFly) : base()
    {
        Description = description;
        Size = size;
        CanFly = canFly;
    }

    public Birds() : base() { }

    public override string Info
    {
        get
        {
            string flyStatus = CanFly ? "(fly+)" : "(fly-)";
            return $"{Description} {flyStatus} <{Size}>";
        }
    }

}
