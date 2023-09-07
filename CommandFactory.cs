
namespace ooopsem;

public static class FractalCommandFactory
{
    public static ICommand CreateCommand(string action, string fractalType, Fractalparams fractalparams)
    {
        if (fractalType == "Mandelbrot")
        {
            switch (action)
            {
                case "MoveUp":
                    return new MoveUpMandelbrotCommand(fractalparams);
                case "MoveDown":
                    return new MoveDownMandelbrotCommand(fractalparams);
                case "MoveLeft":
                    return new MoveLeftMandelbrotCommand(fractalparams);
                case "MoveRight":
                    return new MoveRightMandelbrotCommand(fractalparams);
                default:
                    throw new Exception("Unknown command");
            }
        }
        // You can add more fractal types here
        throw new Exception("Unknown fractal type");
    }
}
