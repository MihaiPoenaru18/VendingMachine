using iQuest.VendingMachine.PresentationLayer.Commands;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer.Views
{
    internal class MainView : DisplayBase, IMainView
    {
        public void DisplayApplicationHeader()
        {
            ApplicationHeaderControl applicationHeaderControl = new ApplicationHeaderControl();
            applicationHeaderControl.Display();
        }

        public ICommand ChooseCommand(IEnumerable<ICommand>commands )
        {
            CommandSelectorControl commandSelectorControl = new CommandSelectorControl
            {
                Commands = commands
            };
            return commandSelectorControl.Display();
        }
    }
}