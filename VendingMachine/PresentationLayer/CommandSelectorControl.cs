using iQuest.VendingMachine.PresentationLayer.Commands;
using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CommandSelectorControl : DisplayBase
    {
        public IEnumerable<ICommand> Commands { get; set; }

        public ICommand Display()
        {
            DisplayCommand();
            return SelectCommand();
        }

        private void DisplayCommand()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Available commands:");
            Console.WriteLine();

            foreach (ICommand command in Commands)
                DisplayCommand(command);
        }

        private static void DisplayCommand(ICommand command)
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(command.Name);

            Console.ForegroundColor = oldColor;

            Console.WriteLine(" - " + command.Description);
        }

        private ICommand SelectCommand()
        {
            while (true)
            {
                string rawValue = ReadCommandName();
                ICommand selectedCommand = FindCommand(rawValue);

                if (selectedCommand != null)
                    return selectedCommand;

                DisplayLine("Invalid command. Please try again.", ConsoleColor.Red);
            }
        }

        private ICommand FindCommand(string rawValue)
        {
            ICommand selectedCommand = null;

            foreach (ICommand x in Commands)
            {
                if (x.Name == rawValue)
                {
                    selectedCommand = x;
                    break;
                }
            }

            return selectedCommand;
        }
        
        private string ReadCommandName()
        {
            Console.WriteLine();
            Display("Choose command: ", ConsoleColor.Cyan);
            string rawValue = Console.ReadLine();
            Console.WriteLine();

            return rawValue;
        }
    }
}