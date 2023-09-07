//COMMAND

namespace ooopsem;
public interface ICommand
{
    void Execute();
    void Undo();
}
