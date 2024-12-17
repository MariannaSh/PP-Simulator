using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;

namespace SimWeb.Pages;
public class SimGridModel : PageModel
{
    public char[,] Grid { get; private set; }
    public int CurrentTurn { get; set; }
    public string CurrentMappableInfo { get; private set; }
    private int _maxTurn;
    private static readonly Dictionary<char, string> _symbolToImagePath = new Dictionary<char, string>
    {
        { 'O', "/img/orc.png" },
        { 'E', "/img/elf.png" },
        { 'b', "/img/nonflying.png" },
        { 'B', "/img/bird.png" },
        { 'A', "/img/rabbit.png" },
        { 'X', "/img/all.png" }
    };

    public SimGridModel()
    {
        Grid = new char[1, 1];
        CurrentTurn = 0; 
        _maxTurn = App.SimulationHistory.TurnLogs.Count - 1;
        CurrentMappableInfo = string.Empty;
    }

    public void OnGet()
    {
  
        CurrentTurn = HttpContext.Session.GetInt32("CurrentTurn") ?? 0;
        if (CurrentTurn < 0) CurrentTurn = 0;
        if (CurrentTurn > _maxTurn) CurrentTurn = _maxTurn;


        SetGrid(CurrentTurn);
    }

    public void OnPostNextTurn()
    {
    
        CurrentTurn = HttpContext.Session.GetInt32("CurrentTurn") ?? 0;
        if (CurrentTurn < _maxTurn) CurrentTurn++;
        HttpContext.Session.SetInt32("CurrentTurn", CurrentTurn);

        SetGrid(CurrentTurn);
    }

    public void OnPostPreviousTurn()
    {
        CurrentTurn = HttpContext.Session.GetInt32("CurrentTurn") ?? 0;
        if (CurrentTurn > 0) CurrentTurn--;
        HttpContext.Session.SetInt32("CurrentTurn", CurrentTurn);

        SetGrid(CurrentTurn);
    }

    private void SetGrid(int turn)
    {
        var currentSimulation = App.SimulationHistory;
        var turnLog = currentSimulation.TurnLogs.ElementAtOrDefault(turn);
        if (turnLog == null) return;

        var symbols = turnLog.Symbols;
        var map = App.SimulationHistory.GetMap();
        Grid = new char[map.SizeY, map.SizeX];

        for (int y = map.SizeY - 1; y >= 0; y--)
        {
            for (int x = 0; x < map.SizeX; x++)
            {
                var point = new Point(x, map.SizeY - 1 - y);
                if (symbols.ContainsKey(point))
                    Grid[y, x] = symbols[point];
                else
                    Grid[y, x] = ' ';
            }
        }

        CurrentMappableInfo = turn == 0 ? "Starting Positions" : $"{turnLog.Mappable.ToString()} moves {turnLog.Move.ToString()}";
    }

    public string GetImagePath(char symbol) => _symbolToImagePath.ContainsKey(symbol) ? _symbolToImagePath[symbol] : "/img/all.png";
}
