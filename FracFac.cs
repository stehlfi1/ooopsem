
namespace ooopsem;

public class FractalFactory
{
    public IFractal CreateFractal(string type)
    {
        switch (type)
        {
            case "Mandelbrot":
                return new MandelbrotSet(200, 100);
            case "Julia":
                return new JuliaSet(200, 100);
            case "Koch":
                return new KochSnowflake(1);
            case "Sier":
                return new SierpinskiTriangle(5);
            default:
                throw new ArgumentException("Invalid fractal type");
        }
    }
}
public class FractalDrawingStrategy
{
    private IFractal? _fractal;
    private Fractalparams _currentParams;

    public FractalDrawingStrategy(Fractalparams currentParams)
    {
        _currentParams = currentParams;
    }

    public void SetFractal(IFractal fractal)
    {
        _fractal = fractal;
    }

    public void DrawFractal(string[,] window)
    {
        if (_fractal != null)
        {
            _fractal.Draw(window, _currentParams);
        }
    }

    // If you wish to update the params externally, you can have a method to do that.
    // In FractalDrawingStrategy class
    public void UpdateParams(double reStart, double reEnd, double imStart, double imEnd, Fractalparams currentParams)
    {
        currentParams.RE_START = reStart;
        currentParams.RE_END = reEnd;
        currentParams.IM_START = imStart;
        currentParams.IM_END = imEnd;
    }

   
}
