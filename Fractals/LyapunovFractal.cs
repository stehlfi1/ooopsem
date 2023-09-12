namespace ooopsem
{
    public class LyapunovFractal : IFractal
    {
        private int width;
        private int height;
        private const int MAX_ITER = 1000;
        public Fractalparams GetDefaultParams()
        {
            return new Fractalparams { RE_START = -2, RE_END = 2, IM_START = -2, IM_END = 2 };
        }
        public LyapunovFractal(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw(string[,] window, Fractalparams currentParams)
        {
            double R_START = currentParams.RE_START;
            double R_END = currentParams.RE_END;
            double X_START = currentParams.IM_START;
            double X_END = currentParams.IM_END;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    double r = R_START + (x / (double)width) * (R_END - R_START);
                    double x_init = X_START + (y / (double)height) * (X_END - X_START);
                    double lyapunov = CalculateLyapunov(r, x_init);
                    window[x, y] = FracUtills.HsvToRgb((int)(255 * Math.Abs(lyapunov) / 2), 255, lyapunov >= 0 ? 255 : 0);
                }
            }
        }

        public double CalculateLyapunov(double r, double x_init)
        {
            double x = x_init;
            double sum = 0;

            for (int i = 0; i < MAX_ITER; i++)
            {
                double derivative = r * (1 - 2 * x);
                sum += Math.Log(Math.Abs(derivative));
                x = r * x * (1 - x);
            }

            return sum / MAX_ITER;
        }
    }
}
