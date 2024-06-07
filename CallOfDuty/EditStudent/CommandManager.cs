using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallOfDuty.EditStudent
{
    class CommandManager
    {
        Dictionary<string, (string descr, UserCommand)> commands = new();

        public void RegisterCommand(string key, string descr, UserCommand command)
        {
            commands.Add(key, (descr, command));
        }

        public void Execute(string? command)
        {
            if (commands.ContainsKey(command))
            {
                commands[command].Item2.Execute();
            }
        }

        public void ListCommand()
        {
            foreach (var command in commands.Keys)
            {
                Console.WriteLine($"{command} - {commands[command].descr}");
            }
        }
    }
}
