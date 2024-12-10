using Simulator.Maps;
using Simulator;
using System.Text;

namespace SimConsole;

public class MapVisualizer
{
    private Map _map;

    public MapVisualizer(Map map)
    {
        _map = map;
    }

    public void Draw()
    {
        Console.Clear();
        Console.OutputEncoding = Encoding.UTF8;


        Console.Write(Box.TopLeft);
        for (int x = 0; x < _map.SizeX; x++)
        {
            Console.Write(Box.Horizontal);
        }
        Console.WriteLine(Box.TopRight);

        
        for (int y = 0; y < _map.SizeY; y++)
        {
            Console.Write(Box.Vertical);

            for (int x = 0; x < _map.SizeX; x++)
            {
                var creaturesAtPosition = _map.At(x, y);

                if (creaturesAtPosition == null || creaturesAtPosition.Count == 0)
                {
                    Console.Write(" "); 
                }
                else if (creaturesAtPosition.Count > 1)
                {
                    Console.Write("X"); 
                }
                else
                {
                    var creature = creaturesAtPosition[0];

                    if (creature is Orc orc)
                    {
                        Console.Write(orc.Symbol);
                    }
                    else if (creature is Elf elf)
                    {
                        Console.Write(elf.Symbol);
                    }
                    else if (creature is Birds bird)
                    {
                        Console.Write(bird.Symbol);
                    }
                    else if (creature is Animals animal)
                    {
                        Console.Write(animal.Symbol);
                    }
                    else
                    {
                        Console.Write("?");
                    }
                }
            }

            Console.WriteLine(Box.Vertical); 
        }

      
        Console.Write(Box.BottomLeft);
        for (int x = 0; x < _map.SizeX; x++)
        {
            Console.Write(Box.Horizontal);
        }
        Console.WriteLine(Box.BottomRight);
    }


    public void DrawSnapshot(SimulationSnapshot snapshot)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write(Box.TopLeft);
        for (int x = 0; x < _map.SizeX - 1; x++)
        {
            Console.Write($"{Box.Horizontal}{Box.TopMid}");
        }
        Console.WriteLine($"{Box.Horizontal}{Box.TopRight}");
        for (int y = _map.SizeY - 1; y >= 0; y--)
        {
            Console.Write(Box.Vertical);
            for (int x = 0; x < _map.SizeX; x++)
            {
                var point = new Point(x, y);
                if (snapshot.CreaturePositions.ContainsKey(point))
                {
                    var creatures = snapshot.CreaturePositions[point];
                    if (creatures.Count > 1)
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        var creature = creatures.First();
                        Console.Write(creature.Symbol);
                    }
                }
                else
                {
                    Console.Write(" ");
                }
                Console.Write(Box.Vertical);
            }
            Console.WriteLine();
            if (y > 0)
            {
                Console.Write(Box.MidLeft);
                for (int x = 0; x < _map.SizeX - 1; x++)
                {
                    Console.Write($"{Box.Horizontal}{Box.Cross}");
                }
                Console.WriteLine($"{Box.Horizontal}{Box.MidRight}");
            }
        }
        Console.Write(Box.BottomLeft);
        for (int x = 0; x < _map.SizeX - 1; x++)
        {
            Console.Write($"{Box.Horizontal}{Box.BottomMid}");
        }
        Console.WriteLine($"{Box.Horizontal}{Box.BottomRight}");
        Console.WriteLine();
    }


}