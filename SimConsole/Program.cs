using Simulator.Maps;
using Simulator;
using System.Text;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallSquareMap map = new(5);
        List<Creature> creatures = new() { new Orc("Gorbag"), new Elf("Elandor") };
        List<Point> points = new() { new Point(2, 2), new Point(3, 1) };
        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(map);


        while (!simulation.Finished)
        {
            Console.Clear();
            mapVisualizer.Draw();
            Console.WriteLine($"Current Move: {simulation.CurrentMoveName}");
            simulation.Turn();
            Thread.Sleep(1000); 
        }

        
        Console.Clear();
        mapVisualizer.Draw();
        Console.WriteLine("Simulation finished.");
    }
}
