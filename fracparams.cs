
namespace ooopsem;
public class Fractalparams
{
    public double RE_START { get; set; } = -2;
    public double RE_END { get; set; } = 1;
    public double IM_START { get; set; } = -1;
    public double IM_END { get; set; } = 1;

    // You can add other parameters like zoom level, iteration count etc. if necessary

    public Fractalparams()
    {
    }

    public Fractalparams(double reStart, double reEnd, double imStart, double imEnd)
    {
        this.RE_START = reStart;
        this.RE_END = reEnd;
        this.IM_START = imStart;
        this.IM_END = imEnd;
    }

    // You could also add methods to modify these parameters, or copy them from another FractalParams instance
}
