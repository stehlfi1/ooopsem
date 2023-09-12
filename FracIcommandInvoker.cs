using System.Collections.Generic;

namespace ooopsem
{
    public class FractalCommandInvoker
    {
        private List<ICommand> commands = new List<ICommand>();
        private int current = 0;

        public void Execute(ICommand command)
        {
            command.Execute();
            commands.Add(command);
            current++;
        }

        public void Undo(int levels)
        {
            for (int i = 0; i < levels; i++)
            {
                if (current > 0)
                {
                    ICommand command = commands[--current];
                    command.Undo();
                }
            }
        }

        public void Redo(int levels)
        {
            for (int i = 0; i < levels; i++)
            {
                if (current < commands.Count)
                {
                    ICommand command = commands[current++];
                    command.Execute();
                }
            }
        }
    }
}