


namespace ooopsem;

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
using System;
using System.Collections.Generic;


public class JuliaSet : IFractal
{
    private int width;
    private int height;
    private const int MAX_ITER = 80;
    
    public JuliaSet(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public void Draw(string[,] window, Fractalparams currentParams)
    {
        Dictionary<int, int> histogram = new Dictionary<int, int>();
        Dictionary<(int, int), int> values = new Dictionary<(int, int), int>();
        
        double reStart = currentParams.RE_START;
        double reEnd = currentParams.RE_END;
        double imStart = currentParams.IM_START;
        double imEnd = currentParams.IM_END;

        double cReal = 0.285; //-0.7;
        double cImaginary = 0.01; //0.156; 

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                double real = reStart + (x / (double)width) * (reEnd - reStart);
                double imaginary = imStart + (y / (double)height) * (imEnd - imStart);

                int m = CalculateJulia(real, imaginary, cReal, cImaginary);
                values[(x, y)] = m;

                if (m < MAX_ITER)
                {
                    if (histogram.ContainsKey(m))
                    {
                        histogram[m]++;
                    }
                    else
                    {
                        histogram[m] = 1;
                    }
                }
            }
        }

        double total = histogram.Values.Sum();
        List<double> hues = new List<double>();
        double h = 0;
        for (int i = 0; i < MAX_ITER; i++)
        {
            if (histogram.ContainsKey(i))
            {
                h += histogram[i] / total;
            }
            hues.Add(h);
        }
        hues.Add(h);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int m = values[(x, y)];
                double hue = 255 - (255 * (hues[m] + hues[Math.Min(m + 1, MAX_ITER - 1)]) / 2);
                double saturation = 255;
                double value = m < MAX_ITER ? 255 : 0;

                window[x, y] = FracUtills.HsvToRgb(hue, saturation, value);
            }
        }
    }

    public int CalculateJulia(double real, double imaginary, double cReal, double cImaginary)
    {
        int count = 0;
        double zReal = real;
        double zImaginary = imaginary;

        while (count < MAX_ITER && (zReal * zReal + zImaginary * zImaginary) < 4.0)
        {
            double tempReal = zReal * zReal - zImaginary * zImaginary + cReal;
            zImaginary = 2 * zReal * zImaginary + cImaginary;
            zReal = tempReal;
            count++;
        }

        return count;
    }
    public void Set(Fractalparams currentParams)
    {
        currentParams.RE_START = -1;
        currentParams.RE_END = 1;
        currentParams.IM_START = -1.2;
        currentParams.IM_END = 1.2;

    }
}

