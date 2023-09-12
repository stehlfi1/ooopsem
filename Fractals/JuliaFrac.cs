


namespace ooopsem;

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
    public Fractalparams GetDefaultParams()
    {
        return new Fractalparams { RE_START = -2, RE_END = 2, IM_START = -2, IM_END = 2 };
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

