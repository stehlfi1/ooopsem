//gui.cs
using System;
using Pastel;
using System.Collections.Generic;

namespace ooopsem;
public class FractalWindow
{
    private readonly int WIDTH;
    private readonly int HEIGHT;
    private string[,] window;
    private Fractalparams _currentParams = new Fractalparams();
    private Stack<ICommand> commandHistory = new Stack<ICommand>();
    private string currentFractalType = "Mandelbrot"; // Initialize with default fractal
    private FractalCommandInvoker invoker = new FractalCommandInvoker();

    public FractalWindow()
    {
        WIDTH = Config.Instance.Width;
        HEIGHT = Config.Instance.Height;
        window = new string[WIDTH, HEIGHT];
    }

    public void ConsoleMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Fractal Console App");
            Console.WriteLine("1. Mandelbrot");
            Console.WriteLine("2. Julia");
            Console.WriteLine("3. Lya");
            Console.WriteLine("4. Colatz");
            Console.WriteLine("5. Burningship");
            Console.WriteLine("Q. Quit");

            var input = Console.ReadKey();

            switch (input.KeyChar)
            {
                case '1':
                    currentFractalType = "Mandelbrot";
                    DrawFractal();
                    break;
                case '2':
                    currentFractalType = "Julia";
                    DrawFractal();
                    break;
                case '3':
                    currentFractalType = "Lya";
                    DrawFractal();
                    break;
                case '4':
                    currentFractalType = "Colatz";
                    DrawFractal();
                    break;
                case '5':
                    currentFractalType = "Burn";
                    DrawFractal();
                    break;
                case 'Q':
                case 'q':
                    return;
            }
        }
    }

    public void DrawFractal()
    {
        var fractalFactory = new FractalFactory();
        IFractal currentFractal = fractalFactory.CreateFractal(currentFractalType, WIDTH, HEIGHT);
        _currentParams = currentFractal.GetDefaultParams();
        currentFractal.Draw(window, _currentParams);

        ConsoleKeyInfo keyInfo;
        bool exit = false;

        while (!exit)
        {
            RenderWindow();
            keyInfo = Console.ReadKey(true);
            ICommand? command = null;
            string currentFractalType ="Generic";
            switch (keyInfo.Key)
            {
                case ConsoleKey.Q:
                    exit = true;
                    break;
                case ConsoleKey.W:
                    command = FractalCommandFactory.CreateCommand("MoveUp", currentFractalType, _currentParams);
                    break;
                case ConsoleKey.S:
                    command = FractalCommandFactory.CreateCommand("MoveDown", currentFractalType, _currentParams);
                    break;
                case ConsoleKey.D:
                    command = FractalCommandFactory.CreateCommand("MoveLeft", currentFractalType, _currentParams);
                    break;
                case ConsoleKey.A:
                    command = FractalCommandFactory.CreateCommand("MoveRight", currentFractalType, _currentParams);
                    break;
                case ConsoleKey.Z:
                    command = FractalCommandFactory.CreateCommand("ZoomIn", currentFractalType, _currentParams);
                    break;
                case ConsoleKey.X:
                    command = FractalCommandFactory.CreateCommand("ZoomOut", currentFractalType, _currentParams);
                    break;
                case ConsoleKey.U:
                    invoker.Undo(1);
                    currentFractal.Draw(window, _currentParams);
                    break;
                case ConsoleKey.R:
                    invoker.Redo(1);
                    currentFractal.Draw(window, _currentParams);
                    break;
            }

            if (command != null)
            {
                invoker.Execute(command);
                currentFractal.Draw(window, _currentParams);
            }
        }
    }

    private void RenderWindow()
    {
        Console.Clear();
        for (int y = 0; y < HEIGHT; y++)
        {
            for (int x = 0; x < WIDTH; x++)
            {
                Console.Write(" ".PastelBg(window[x, y]));
            }
            Console.WriteLine();
        }
    }
     public void UpdateParams(double reStart, double reEnd, double imStart, double imEnd, Fractalparams currentParams)
    {
        currentParams.RE_START = reStart;
        currentParams.RE_END = reEnd;
        currentParams.IM_START = imStart;
        currentParams.IM_END = imEnd;
    }
}


   



