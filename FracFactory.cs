//FracFactory
namespace ooopsem;

public class FractalFactory
{
    public IFractal CreateFractal(string type, int width, int height)
    {
        switch (type)
        {
            case "Mandelbrot":
                return new MandelbrotSet(width, height);
            case "Julia":
                return new JuliaSet(width, height);
            case "Lya":
                return new LyapunovFractal(width, height);
            case "Colatz":
                return new CollatzFractal(width,height);
            case "Burn":
                return new BurningShipFractal(width,height);
            case "Koch":
                return new MandelbrotSet(width, height);//new KochSnowflake(1); NOT IMPLEMENTED
            case "Sier":
                return new MandelbrotSet(width, height); //new SierpinskiTriangle(5);  NOT IMPLEMENTED
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
