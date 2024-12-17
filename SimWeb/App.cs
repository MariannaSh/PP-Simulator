using Simulator.Maps;
using Simulator;

namespace SimWeb;

public class App
{
    public static SimulationHistory SimulationHistory { get; set; }
    static App()
    {
        var map = new BigTorusMap(8, 6);
        List<IMappable> creatures = new()
        {
            new Elf("Elandor"),
            new Orc("Gorbag"),
            new Animals { Description = "Rabbits", Size = 3 },
            new Birds { Description = "Eagles", Size = 2, CanFly = true },
            new Birds { Description = "Ostriches", Size = 2, CanFly = false }
        };

        List<Point> points = new List<Point>
        {
            new Point(2, 2),
            new Point(3, 1),
            new Point(5, 5),
            new Point(7, 3),
            new Point(0, 4)
        };
        string moves = "dlurdruldlurdrulrd";
        var simulation = new Simulation(map, creatures, points, moves);
        SimulationHistory = new SimulationHistory(simulation);
    }
}
