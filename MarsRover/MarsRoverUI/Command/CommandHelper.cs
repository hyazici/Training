using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverUI.Command
{
    static class CommandHelper
    {
        public static IList<ICommand> ParseCommands(string commandText)
        {
            IList<ICommand> commandList = new List<ICommand>();
            foreach (char item in commandText)
            {
                switch (item)
                {
                    case 'L':
                        commandList.Add(new TurnLeftCommand());
                        break;
                    case 'R':
                        commandList.Add(new TurnRightCommand());
                        break;
                    case 'M':
                        commandList.Add(new MoverForwardCommand());
                        break;
                    default:
                        throw new Exception(" Buraya düzgün birşeyler yaz");
                        
                }
            }
            return commandList;
        }
    }
}
