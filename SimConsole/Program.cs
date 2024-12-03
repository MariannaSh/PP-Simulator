using Simulator.Maps;
using Simulator;
using System.Text;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;


        SmallTorusMap torusMap = new(8, 6);

        List<IMappable> creatures = new()
        {
            new Elf("Elandor"),
            new Orc("Gorbag"),
            new Animals { Description = "Rabbits", Size = 10 },
            new Birds { Description = "Eagles", Size = 5, CanFly = true },
            new Birds { Description = "Ostriches", Size = 4, CanFly = false }
        };

        List<Point> points = new List<Point>
        {
            new Point(2, 2),
            new Point(3, 1),
            new Point(4, 1),
            new Point(5, 1),
            new Point(6, 1),

        };

        string moves = "dlrludl";

        Simulation simulation = new Simulation(torusMap, creatures, points, moves);

        MapVisualizer mapVisualizer = new MapVisualizer(torusMap);

        mapVisualizer.Draw();
        Console.WriteLine("Press any key to start simulation...");
        Console.ReadKey();



        while (!simulation.Finished)
        {
            simulation.Turn();
            mapVisualizer.Draw();
            Console.WriteLine($"Current Move: {simulation.CurrentMoveName.ToUpper()}");
            Console.WriteLine("Press any key for next turn...");
            Console.ReadKey();
        }

        Console.WriteLine("Simulation Finished!");

    }
}
