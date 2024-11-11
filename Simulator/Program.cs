namespace Simulator;

public class Program
{
    private static void Main(string[] args)
    {
        Point p = new(10, 25);
        Console.WriteLine(p.Next(Direction.Right));          // (11, 25)
        Console.WriteLine(p.NextDiagonal(Direction.Right));  // (11, 24)

        Lab5a();
  
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
        catch (ArgumentException ex) { Console.WriteLine(ex.Message); }

        Point p1 = new Point(1, 1);
        Point p2 = new Point(4, 5);
        Rectangle rect3 = new Rectangle(p1, p2);
        Console.WriteLine("Prostokąt utworzony z punktów: " + rect3.ToString());

        Point pointToCheck = new Point(3, 3);
        Console.WriteLine($"Czy {rect3} zawiera punkt {pointToCheck}? " + rect3.Contains(pointToCheck));

        Point pointOutSide = new Point(5, 6);
        Console.WriteLine($"Czy {rect3} zawiera punkt {pointOutSide}? " + rect3.Contains(pointOutSide)); 

    }

    
}