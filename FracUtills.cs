
namespace ooopsem;

public static class FracUtills
{

    // Convert HSV to RGB color
    public static string HsvToRgb(double h, double s, double v)
    {
        int hi = Convert.ToInt32(Math.Floor(h / 60)) % 6;
        double f = h / 60 - Math.Floor(h / 60);

        s = s / 255;
        v = v / 255;
        double value = v;
        double p = v * (1 - s);
        double q = v * (1 - f * s);
        double t = v * (1 - (1 - f) * s);

        if (hi == 0)
            return $"{ToHex(value)}{ToHex(t)}{ToHex(p)}";
        else if (hi == 1)
            return $"{ToHex(q)}{ToHex(value)}{ToHex(p)}";
        else if (hi == 2)
            return $"{ToHex(p)}{ToHex(value)}{ToHex(t)}";
        else if (hi == 3)
            return $"{ToHex(p)}{ToHex(q)}{ToHex(value)}";
        else if (hi == 4)
            return $"{ToHex(t)}{ToHex(p)}{ToHex(value)}";
        else
            return $"{ToHex(value)}{ToHex(p)}{ToHex(q)}";
    }

    public static string ToHex(double value)
    {
        return ((int)(value * 255)).ToString("X2");
    }

}