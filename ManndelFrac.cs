    
namespace ooopsem;
    

public class MandelbrotSet : IFractal
{
    private int width;
    private int height;
    private const int MAX_ITER = 1000;

    public MandelbrotSet(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    // MandelbrotSet changes
    public void Draw(string[,] window, Fractalparams currentParams)
    {
        // Use the currentParams for drawing
        double RE_START = currentParams.RE_START;
        double RE_END = currentParams.RE_END;
        double IM_START = currentParams.IM_START;
        double IM_END = currentParams.IM_END;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                double real = RE_START + (x / (double)width) * (RE_END - RE_START);
                double imaginary = IM_START + (y / (double)height) * (IM_END - IM_START);
                int m = CalculateMandelbrot(real, imaginary);
                window[x, y] = FracUtills.HsvToRgb((int)(255 * m / (double)MAX_ITER), 255, m < MAX_ITER ? 255 : 0);
            }
        }
    }

    public int CalculateMandelbrot(double real, double imaginary)
    {
        int maxIterations = 1000;
        double realTemp = real;
        double imaginaryTemp = imaginary;
        int count;

        for (count = 0; count < maxIterations && (realTemp * realTemp + imaginaryTemp * imaginaryTemp) < 4.0; count++)
        {
            double realTemp2 = realTemp * realTemp - imaginaryTemp * imaginaryTemp + real;
            imaginaryTemp = 2 * realTemp * imaginaryTemp + imaginary;
            realTemp = realTemp2;
        }

        return count;
    }
    
}




