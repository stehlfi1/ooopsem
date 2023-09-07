
namespace ooopsem;

public class MoveUpMandelbrotCommand : ICommand
{
    private readonly Fractalparams _fractalparams;  // Assume Fractalfractalparams is a class that holds the parameters for rendering.
    private readonly double _delta = 0.1;

    public MoveUpMandelbrotCommand(Fractalparams fractalparams)
    {
        _fractalparams = fractalparams;
    }

    public void Execute()
    {
        // Move the fractal up by incrementing the imaginary parts.
        _fractalparams.IM_START += _delta;
        _fractalparams.IM_END += _delta;
    }

    public void Undo()
    {
        // Undo the move by decrementing the imaginary parts.
        _fractalparams.IM_START -= _delta;
        _fractalparams.IM_END -= _delta;
    }
}

public class MoveDownMandelbrotCommand : ICommand
{
    private readonly Fractalparams _fractalparams;
    private readonly double _delta = 0.1;

    public MoveDownMandelbrotCommand(Fractalparams fractalparams)
    {
        _fractalparams = fractalparams;
    }

    public void Execute()
    {
        _fractalparams.IM_START -= _delta;
        _fractalparams.IM_END -= _delta;
    }

    public void Undo()
    {
        _fractalparams.IM_START += _delta;
        _fractalparams.IM_END += _delta;
    }
}

public class MoveLeftMandelbrotCommand : ICommand
{
    private readonly Fractalparams _fractalparams;
    private readonly double _delta = 0.1;

    public MoveLeftMandelbrotCommand(Fractalparams fractalparams)
    {
        _fractalparams = fractalparams;
    }

    public void Execute()
    {
        _fractalparams.RE_START -= _delta;
        _fractalparams.RE_END -= _delta;
    }

    public void Undo()
    {
        _fractalparams.RE_START += _delta;
        _fractalparams.RE_END += _delta;
    }
}

public class MoveRightMandelbrotCommand : ICommand
{
    private readonly Fractalparams _fractalparams;
    private readonly double _delta = 0.1;

    public MoveRightMandelbrotCommand(Fractalparams fractalparams)
    {
        _fractalparams = fractalparams;
    }

    public void Execute()
    {
        _fractalparams.RE_START += _delta;
        _fractalparams.RE_END += _delta;
    }

    public void Undo()
    {
        _fractalparams.RE_START -= _delta;
        _fractalparams.RE_END -= _delta;
    }
}

public class ZoomInCommand : ICommand
{
    private readonly Fractalparams _fractalParams;
    private readonly double _zoomFactor = 0.7; // 70% zoom in

    public ZoomInCommand(Fractalparams fractalParams)
    {
        _fractalParams = fractalParams;
    }

    public void Execute()
    {
        double reMid = (_fractalParams.RE_START + _fractalParams.RE_END) / 2;
        double imMid = (_fractalParams.IM_START + _fractalParams.IM_END) / 2;
        
        double reRange = (_fractalParams.RE_END - _fractalParams.RE_START) * _zoomFactor;
        double imRange = (_fractalParams.IM_END - _fractalParams.IM_START) * _zoomFactor;

        _fractalParams.RE_START = reMid - reRange / 2;
        _fractalParams.RE_END = reMid + reRange / 2;
        _fractalParams.IM_START = imMid - imRange / 2;
        _fractalParams.IM_END = imMid + imRange / 2;
    }

    public void Undo()
    {
        // To undo zoom in (i.e., zoom out)
        double zoomOutFactor = 1 / _zoomFactor;
        double reMid = (_fractalParams.RE_START + _fractalParams.RE_END) / 2;
        double imMid = (_fractalParams.IM_START + _fractalParams.IM_END) / 2;

        double reRange = (_fractalParams.RE_END - _fractalParams.RE_START) * zoomOutFactor;
        double imRange = (_fractalParams.IM_END - _fractalParams.IM_START) * zoomOutFactor;

        _fractalParams.RE_START = reMid - reRange / 2;
        _fractalParams.RE_END = reMid + reRange / 2;
        _fractalParams.IM_START = imMid - imRange / 2;
        _fractalParams.IM_END = imMid + imRange / 2;
    }
}

public class ZoomOutCommand : ICommand
{
    private readonly Fractalparams _fractalParams;
    private readonly double _zoomFactor = 1.1; // 110% zoom out

    public ZoomOutCommand(Fractalparams fractalParams)
    {
        _fractalParams = fractalParams;
    }

    public void Execute()
    {
        double reMid = (_fractalParams.RE_START + _fractalParams.RE_END) / 2;
        double imMid = (_fractalParams.IM_START + _fractalParams.IM_END) / 2;
        
        double reRange = (_fractalParams.RE_END - _fractalParams.RE_START) * _zoomFactor;
        double imRange = (_fractalParams.IM_END - _fractalParams.IM_START) * _zoomFactor;

        _fractalParams.RE_START = reMid - reRange / 2;
        _fractalParams.RE_END = reMid + reRange / 2;
        _fractalParams.IM_START = imMid - imRange / 2;
        _fractalParams.IM_END = imMid + imRange / 2;
    }

    public void Undo()
    {
        // To undo zoom out (i.e., zoom in)
        double zoomInFactor = 1 / _zoomFactor;
        double reMid = (_fractalParams.RE_START + _fractalParams.RE_END) / 2;
        double imMid = (_fractalParams.IM_START + _fractalParams.IM_END) / 2;

        double reRange = (_fractalParams.RE_END - _fractalParams.RE_START) * zoomInFactor;
        double imRange = (_fractalParams.IM_END - _fractalParams.IM_START) * zoomInFactor;

        _fractalParams.RE_START = reMid - reRange / 2;
        _fractalParams.RE_END = reMid + reRange / 2;
        _fractalParams.IM_START = imMid - imRange / 2;
        _fractalParams.IM_END = imMid + imRange / 2;
    }
}
