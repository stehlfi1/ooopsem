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

