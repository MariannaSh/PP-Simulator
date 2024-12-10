using Simulator.Maps;
using Simulator;
using System.Text;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        BigBounceMap bounceMap = new(8, 6);

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
            new Point(0, 0),
            new Point(7, 0),
            new Point(0, 5),
            new Point(7, 5),
            new Point(3, 3),
        };

        string moves = "dlurdruldlurdruldrul";

        //Simulation simulation = new Simulation(bounceMap, creatures, points, moves);
        //MapVisualizer mapVisualizer = new MapVisualizer(bounceMap);

        try
        {
            var simulation = new Simulation(bounceMap, creatures, points, moves);

            var simulationHistory = new SimulationHistory(simulation);

            while (!simulation.Finished)
            {
                Console.Clear();
                Console.WriteLine("SIMULATION!");
                Console.WriteLine($"Turn {simulation._currentMoveIndex + 1}");

                simulation.Turn();

                var mapVisualizer = new MapVisualizer(bounceMap);
                mapVisualizer.Draw();

                System.Threading.Thread.Sleep(500);
            }

            Console.WriteLine("Simulation finished!");
            Console.WriteLine("\n=== Simulation History ===");
            int[] turnsToShow = { 5, 10, 15, 20 };

            foreach (var turn in turnsToShow)
            {
                if (turn - 1 < simulationHistory.TotalTurns)
                {
                    Console.WriteLine($"\nTurn {turn}:");
                    var snapshot = simulationHistory.GetSnapshot(turn - 1);

                    var mapVisualizer = new MapVisualizer(bounceMap);
                    mapVisualizer.DrawSnapshot(snapshot);
                }
                else
                {
                    Console.WriteLine($"\nTurn {turn}: Not available (simulation finished earlier)");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

}