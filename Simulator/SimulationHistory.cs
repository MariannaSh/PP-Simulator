

namespace Simulator;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = new List<SimulationTurnLog>();

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ?? throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {
        while (!_simulation.Finished)
        {
            _simulation.Turn();

            TurnLogs.Add(CreateTurnLog());
        }
    }

    private SimulationTurnLog CreateTurnLog()
    {
        var symbols = new Dictionary<Point, char>();

        for (int x = 0; x < SizeX; x++)
        {
            for (int y = 0; y < SizeY; y++)
            {
                var creaturesAtPosition = _simulation.Map.At(x, y);
                if (creaturesAtPosition != null && creaturesAtPosition.Count > 0)
                {
                    foreach (var creature in creaturesAtPosition)
                    {
                        symbols[new Point(x, y)] = creature.Symbol;
                    }
                }
            }
        }

        return new SimulationTurnLog
        {
            Mappable = _simulation.CurrentIMappable.ToString(),
            Move = _simulation.CurrentMoveName.ToString(),
            Symbols = symbols
        };
    }
}
