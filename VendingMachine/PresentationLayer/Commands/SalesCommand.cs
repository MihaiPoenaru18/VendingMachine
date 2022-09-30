using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.UseCases;
using System;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal class SalesCommand : ICommand
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUseCaseFactory factory;

        public SalesCommand(IAuthenticationService authenticationService, IUseCaseFactory factory)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public string Name => "sales";

        public string Description => "You can see all the sales for a period of time";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public void Execute()
        {
            factory.Create<SalesUseCase>().Execute();
        }
    }
}
