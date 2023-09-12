/*

private void InitializeWindow()
    {
        for (int x = 0; x < WIDTH; x++)
        {
            for (int y = 0; y < HEIGHT; y++)
            {
                // Top border
                // Corners
                if ((x == 0 && y == 0) || 
                        (x == WIDTH - 1 && y == 0) || 
                        (x == 0 && y == HEIGHT - 1) || 
                        (x == WIDTH - 1 && y == HEIGHT - 1))
                {
                    window[x, y] = "+";
                }
                else if (y == 0)
                {
                    window[x, y] = "-";
                }
                // Bottom border
                else if (y == HEIGHT - 1)
                {
                    window[x, y] = "-";
                }
                // Left border
                else if (x == 0)
                {
                    window[x, y] = "|";
                }
                // Right border
                else if (x == WIDTH - 1)
                {
                    window[x, y] = "|";
                }
                
                // Inner space
                //else
                //{
                //    window[x, y] = ' ';
                //}
            }
        }
    }
/*
            var fractalFactory = new FractalFactory();
            var fractalDrawingStrategy = new FractalDrawingStrategy();

            fractalDrawingStrategy.SetFractal(fractalFactory.CreateFractal("Mandelbrot"));
            fractalDrawingStrategy.DrawFractal();
            Console.WriteLine();
            fractalDrawingStrategy.SetFractal(fractalFactory.CreateFractal("Julia"));
            fractalDrawingStrategy.DrawFractal();
            Console.WriteLine();
            fractalDrawingStrategy.SetFractal(fractalFactory.CreateFractal("Koch"));
            fractalDrawingStrategy.DrawFractal();
            Console.WriteLine();
            fractalDrawingStrategy.SetFractal(fractalFactory.CreateFractal("Sier"));
            fractalDrawingStrategy.DrawFractal();
            */


/*
public class JuliaSet : IFractal
{
    private int width;
    private int height;

    public JuliaSet(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public void Draw(string[,] window, Fractalparams currentParams)
    {
        double realC = -0.7;  // These constants define the shape of the Julia set
        double imaginaryC = 0.156;
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
                int value = CalculateJulia(real, imaginary, realC, imaginaryC);
                window[x, y] = FracUtills.HsvToRgb((int)(255 * value / 1000.0), 255, value < 1000 ? 255 : 0);  // Assuming 1000 is the max iteration
            }
        }
    }

    public int CalculateJulia(double real, double imaginary, double realC, double imaginaryC)
    {
        int maxIterations = 1000;
        int count;

        for (count = 0; count < maxIterations && (real * real + imaginary * imaginary) < 4.0; count++)
        {
            double realTemp = real * real - imaginary * imaginary + realC;
            imaginary = 2 * real * imaginary + imaginaryC;
            real = realTemp;
        }

        return count;
    }
}
*/