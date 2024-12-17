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

        try
        {
            // Создание симуляции
            var simulation = new Simulation(bounceMap, creatures, points, moves);
            var mapVisualizer = new MapVisualizer(bounceMap);

            Console.WriteLine("SIMULATION!");
            Console.WriteLine("\n---Starting Positions---");
            Console.WriteLine("Initial layout of the map with creatures:");
            mapVisualizer.Draw(); 

            var simulationHistory = new SimulationHistory(simulation);

            while (!simulation.Finished)
            {
                
                Console.WriteLine("SIMULATION!");
                Console.WriteLine($"Turn {simulation._currentMoveIndex + 1}");

                simulation.Turn();
                mapVisualizer.Draw(); 
            }

            Console.WriteLine("Simulation finished!");

            Console.WriteLine("\n---Simulation History---");

            int[] turnsToShow = { 5, 10, 15, 20 ,30};
            var logVisualizer = new LogVisualizer(simulationHistory);

            foreach (var turn in turnsToShow)
            {
                if (turn - 1 < simulationHistory.TurnLogs.Count)
                {
                    Console.WriteLine($"\nTurn {turn}:");
                    logVisualizer.Draw(turn - 1);
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
