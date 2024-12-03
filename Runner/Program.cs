using Simulator.Maps;

namespace Simulator;

public class Program
{
    private static void Main(string[] args)
    {
        Lab5a();
        Lab5b();

    }

    static void Lab5a()
    {
        try
        {
            Rectangle rect1 = new Rectangle(5, 5, 1, 1);
            Console.WriteLine("Utworzono pomyślnie: " + rect1.ToString());
        }
        catch (ArgumentException ex) { Console.WriteLine(ex.Message); }

        try
        {
            Rectangle rect2 = new Rectangle(2, 2, 2, 6);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Błąd : " + ex.Message);
        }

        try
        {

            Point p1 = new Point(1, 1);
            Point p2 = new Point(4, 5);
            Rectangle rect3 = new Rectangle(p1, p2);
            Console.WriteLine("Prostokąt utworzony z punktów: " + rect3.ToString());

            Point pointToCheck = new Point(3, 3);
            Console.WriteLine($"Czy {rect3} zawiera punkt {pointToCheck}? " + rect3.Contains(pointToCheck));

            Point pointOutSide = new Point(5, 6);
            Console.WriteLine($"Czy {rect3} zawiera punkt {pointOutSide}? " + rect3.Contains(pointOutSide));
        }
        catch ( ArgumentException ex )
        {
            Console.WriteLine("Błąd: " + ex.Message);
        }
    }

    static void Lab5b()
    {
        try
        {
            SmallSquareMap map = new SmallSquareMap(8);
            Console.WriteLine("Mapa o rozmiarze: " + map.SizeX);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Błąd przy tworzeniu mapy: " + ex.Message);
        }

        try
        {
            SmallSquareMap map = new SmallSquareMap(8);
            Point startPoint = new Point(2, 2);
            Point nextPoint = map.Next(startPoint, Direction.Up);
            Console.WriteLine($"Po ruchu w górę punkt z {startPoint} to {nextPoint}");

            Point diagonalPoint = map.NextDiagonal(startPoint, Direction.Left);
            Console.WriteLine($"Po ukośnym ruchu w lewo do góry, punkt z {startPoint} to {diagonalPoint}");

            Point outOfMapPoint = new Point(7, 7);
            Point outOfMap = map.Next(outOfMapPoint, Direction.Up);
            Console.WriteLine($"Po ruchu poza mapę punkt z {outOfMapPoint} to {outOfMap} (powinno pozostać bez ruchu)");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Błąd: " + ex.Message);
        }
    }



}