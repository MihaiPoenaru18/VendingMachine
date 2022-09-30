namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal interface ICommand
    {
        string Name { get; }

        string Description { get; }

        bool CanExecute { get; }

        void Execute();
    }
}