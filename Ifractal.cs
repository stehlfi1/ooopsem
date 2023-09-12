namespace ooopsem
{
    public interface IFractal
    {
        void Draw(string[,] window, Fractalparams currentParams);
        Fractalparams GetDefaultParams();
    }
}
