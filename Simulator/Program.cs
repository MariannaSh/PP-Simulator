namespace Simulator;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        Animals animal = new Animals { Description = "Dogs" };
        Console.WriteLine(animal.Info);
    }

}