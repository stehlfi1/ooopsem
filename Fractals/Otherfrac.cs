
namespace ooopsem;
/*

public class KochSnowflake : IFractal
{
    private int depth;

    public KochSnowflake(int depth)
    {
        this.depth = depth;
    }

    public void Draw(string[,] window,  Fractalparams currentParams)
    {
        // Due to the limitations of the console, this won't look like a snowflake,
        // but it demonstrates the recursion used in the algorithm
        DrawKochLine(depth);
    }

    private void DrawKochLine(int depth)
    {
        if (depth == 0)
        {
            Console.Write("-");
        }
        else
        {
            DrawKochLine(depth - 1);
            Console.Write("/");
            DrawKochLine(depth - 1);
            Console.Write("\\");
            DrawKochLine(depth - 1);
        }
    }
}
public class SierpinskiTriangle : IFractal
{
    private int depth;

    public SierpinskiTriangle(int depth)
    {
        this.depth = depth;
    }

    public void Draw(string[,] window,  Fractalparams currentParams)
    {
        DrawTriangle(this.depth, 0, Console.WindowWidth);
    }

    private void DrawTriangle(int depth, int posX, int length)
    {
        if (depth == 0)
        {
            for (int i = 0; i < length; i++)
            {
                Console.SetCursorPosition(posX + i, depth);
                Console.Write('#');
            }
        }
        else
        {
            int newLength = length / 2;
            // Recursively draw smaller triangles
            DrawTriangle(depth - 1, posX, newLength); // Left triangle
            DrawTriangle(depth - 1, posX + newLength, newLength); // Right triangle
        }
    }
}
*/