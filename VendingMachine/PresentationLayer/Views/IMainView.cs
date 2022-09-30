using iQuest.VendingMachine.PresentationLayer.Commands;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer.Views
{
    internal interface IMainView
    {
        void DisplayApplicationHeader();

        ICommand ChooseCommand(IEnumerable<ICommand> commands);

    }
}
