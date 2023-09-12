namespace ooopsem
{
    public class BurningShipFractal : IFractal
    {
        private int width;
        private int height;
        private const int MAX_ITER = 1000;

        public BurningShipFractal(int width, int height)
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
                    int iter = CalculateBurningShip(real, imaginary);
                    window[x, y] = FracUtills.HsvToRgb((int)(255 * iter / (double)MAX_ITER), 255, iter < MAX_ITER ? 255 : 0);
                }
            }
        }

        public int CalculateBurningShip(double real, double imaginary)
        {
            int iter;
            double realTemp = 0;
            double imaginaryTemp = 0;

            for (iter = 0; iter < MAX_ITER; iter++)
            {
                double realTempAbs = Math.Abs(realTemp);
                double imaginaryTempAbs = Math.Abs(imaginaryTemp);

                if (realTempAbs * realTempAbs + imaginaryTempAbs * imaginaryTempAbs > 4) break;

                double realTemp2 = realTempAbs * realTempAbs - imaginaryTempAbs * imaginaryTempAbs + real;
                imaginaryTemp = 2 * Math.Abs(realTemp * imaginaryTemp) + imaginary;
                realTemp = realTemp2;
            }
            return iter;
        }
    }
}
