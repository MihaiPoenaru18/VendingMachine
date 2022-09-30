using iQuest.VendingMachine.UseCases;
using System;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal class LookCommand : ICommand
    {
        private IUseCaseFactory factory;

        public LookCommand(IUseCaseFactory factory)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public string Name => "look";

        public string Description => "You can see all the products.";

        public bool CanExecute => true;
        
        public void Execute()
        {
            factory.Create<LookUseCase>().Execute();
        }
    }
}