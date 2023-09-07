//OONV PROJECT BY FILIP STEHLIK

//Program.cs

namespace ooopsem
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            
            Console.SetWindowSize(201, 105);
            FractalFactory factory = new FractalFactory();
            FractalWindow fractalWindow = new FractalWindow();
            fractalWindow.ConsoleMenu();
        }

    }   
}


//TODO:
//Move by not set value, but percentage
//More fractals
//Render by not writing, but dumping into buffer
 
//Buttton and menu build depending on fractal