using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client._Patterns_Designs._Command_Pattern
{
    public class CommandHandler
    {
        private List<ICommand> commandList = new List<ICommand>();
        private int index;

        public void AddCommand(ICommand command)
        {
            if(index < commandList.Count)
                commandList.RemoveRange(index, commandList.Count - index);

            commandList.Add(command);
            command.Execute();
            index++;
        }

        public void UndoCommand()
        {
            if(!commandList.Any())
                return;

            if (index > 0)
            {
                commandList[index -1].Undo();
                index--;
            }
        }

        public void RedoCommand()
        {
            if (commandList.Count == 0)
            {
                return;
            }

            if (index < commandList.Count)
            {
                index++;
                commandList[index - 1].Execute();
            }
        }
    }
}
