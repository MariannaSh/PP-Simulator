namespace Simulator;

public static class DirectionParser
{
    public static Direction[] Parse(string input)
    {
        List<Direction> direction = new List<Direction>();

        for (int i = 0; i < input.Length; i++)
        {
            char c = char.ToUpper(input[i]);

            if (c == 'U')
            {
                direction.Add(Direction.Up);
            }
            else if (c == 'R')
            {
                direction.Add(Direction.Right);
            }
            else if (c == 'D')
            {
                direction.Add(Direction.Down);
            }
            else if (c == 'L')
            {
                direction.Add(Direction.Left);
            }
        }

        return direction.ToArray();

    }
}
