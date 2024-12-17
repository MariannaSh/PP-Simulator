using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    public int _currentMoveIndex = 0;

    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// IMappables moving on the map.
    /// </summary>
    public List<IMappable> IMappables { get; }

    /// <summary>
    /// Starting positions of mappables.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of mappables moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first mappable, second for second and so on.
    /// When all mappables make moves, 
    /// next move is again for first mappable and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// IMappable which will be moving current turn.
    /// </summary>
    public IMappable CurrentIMappable 
    {  
        get => IMappables[_currentMoveIndex % IMappables.Count];
    }


    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName 
    {
        get => Moves[_currentMoveIndex % Moves.Length].ToString().ToLower();
    }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if mappables' list is empty,
    /// if number of mappables differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables,
        List<Point> positions, string moves)
    {
        if (mappables.Count == 0 || mappables == null)
            throw new ArgumentException("Lista stworów nie może być pusta");

        if (mappables.Count != positions.Count || positions == null)
            throw new ArgumentException("Liczba stworów musi odpowiadać liczbie pozycji");

        if (string.IsNullOrEmpty(moves))
        {
            throw new ArgumentException("Moves string cannot be empty or null.");
        }

        Map = map ?? throw new ArgumentNullException(nameof(map));
        IMappables = mappables;
        Positions = positions;
        Moves = moves;

        for (int i = 0; i < mappables.Count; i++)
        {
            mappables[i].InitMapAndPosition(map, positions[i]);
        }
    }

    /// <summary>
    /// Makes one move of current mappable in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("Simulation has already finished.");
        }

        char moveChar = Moves[_currentMoveIndex % Moves.Length];

        Direction direction;
        try
        {
            direction = DirectionParser.Parse(moveChar.ToString())[0];
        }
        catch (Exception)
        {
            throw new InvalidOperationException($"Invalid move character: '{moveChar}'. Valid moves: 'U', 'D', 'L', 'R'.");
        }

        // Применяем движение
        CurrentIMappable.Go(direction);

        _currentMoveIndex++;

        // Проверка завершения симуляции после хода
        if (_currentMoveIndex >= Moves.Length)
        {
            Finished = true;
        }
    }
}