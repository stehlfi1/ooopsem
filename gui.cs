
//gui.cs
using System;
using Pastel;

namespace ooopsem;

public class FractalWindow
{
    private const int WIDTH = 200;
    private const int HEIGHT = 100;
    private string[,] window = new string[WIDTH, HEIGHT];
    private Fractalparams _currentParams = new Fractalparams();
    private Stack<ICommand> commandHistory = new Stack<ICommand>();
    private string currentFractalType = "Mandelbrot"; // Initialize with default fractal

    public void ConsoleMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Fractal Console App");
            Console.WriteLine("1. Mandelbrot");
            Console.WriteLine("2. Julia");
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
                case 'Q':
                case 'q':
                    return;
            }
        }
    }

    public void DrawFractal()
    {
        var fractalFactory = new FractalFactory();
        var fractalDrawingStrategy = new FractalDrawingStrategy(_currentParams);

        fractalDrawingStrategy.SetFractal(fractalFactory.CreateFractal(currentFractalType));
        fractalDrawingStrategy.DrawFractal(window);

        if (currentFractalType == "Julia"){fractalDrawingStrategy.UpdateParams(-1, 1, -1.2, 1.2, _currentParams);}

        ConsoleKeyInfo keyInfo;
        bool exit = false;
        while (!exit) // Keep this loop for continuous interaction
        {
            RenderWindow();

            keyInfo = Console.ReadKey(true);
            ICommand? command = null;
            string currentFractalType = "Mandelbrot";

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
                case ConsoleKey.Z: // Zoom In
                    command = new ZoomInCommand(_currentParams);
                    break;
                case ConsoleKey.X: // Zoom Out
                    command = new ZoomOutCommand(_currentParams);
                    break;
                case ConsoleKey.U:  // Undo the last action
                    if (commandHistory.Count > 0)
                    {
                        var lastCommand = commandHistory.Pop();
                        lastCommand.Undo();
                        fractalDrawingStrategy.DrawFractal(window);
                        command = null;
                    }
                    break;
                    // Add additional commands if needed
            }
            
            if (command != null)
            {
                command.Execute();
                commandHistory.Push(command);
                fractalDrawingStrategy.DrawFractal(window);  // Redraw the fractal with updated _currentParams
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
}

