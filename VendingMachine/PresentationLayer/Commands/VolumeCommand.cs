using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.UseCases;
using System;

namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal class VolumeCommand : ICommand
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IUseCaseFactory factory;

        public VolumeCommand(IAuthenticationService authenticationService, IUseCaseFactory factory)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public string Name => "volume";

        public string Description => "You can see all quantity of products, which were sold";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public void Execute()
        {
            factory.Create<VolumeUseCase>().Execute();
        }
    }
}
