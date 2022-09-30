using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.UseCases;
using System;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal class BuyCommand : ICommand 
    {
        private readonly IAuthenticationService authenticationService;

        private readonly IUseCaseFactory factory;

        public BuyCommand(IAuthenticationService authenticationService,IUseCaseFactory factory) 
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public string Name => "buy";

        public string Description => "You can buy a product.";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public void Execute()
        {
            factory.Create<BuyUseCase>().Execute();
        }
    }
}
