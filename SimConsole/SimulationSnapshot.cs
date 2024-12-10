using Simulator;
using Simulator.Maps;

namespace SimConsole;

public class SimulationSnapshot
{
    public Dictionary<Point, List<IMappable>> CreaturePositions { get; }
    public int CurrentTurn { get; }

    public SimulationSnapshot(Simulation simulation)
    {
        CurrentTurn = simulation._currentMoveIndex + 1;
        CreaturePositions = new Dictionary<Point, List<IMappable>>();

        // Zbieranie danych o wszystkich stworach na mapie
        for (int x = 0; x < simulation.Map.SizeX; x++)
        {
            for (int y = 0; y < simulation.Map.SizeY; y++)
            {
                var creaturesAtPosition = simulation.Map.At(x, y);
                if (creaturesAtPosition != null && creaturesAtPosition.Count > 0)
                {
                    CreaturePositions[new Point(x, y)] = new List<IMappable>(creaturesAtPosition);
                }
            }
        }
    }
}

