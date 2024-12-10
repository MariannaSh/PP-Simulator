
using Simulator;


namespace SimConsole;

public class SimulationHistory
{
    private List<SimulationSnapshot> _snapshots;

    public int TotalTurns => _snapshots.Count;

    public SimulationHistory(Simulation simulation)
    {
        _snapshots = new List<SimulationSnapshot>();

        
        while (!simulation.Finished)
        {
            simulation.Turn(); 
            _snapshots.Add(new SimulationSnapshot(simulation)); 
        }
    }

    public SimulationSnapshot GetSnapshot(int index)
    {

        return _snapshots[index];
    }
}
