namespace iQuest.VendingMachine.PresentationLayer.Commands
{
    internal interface IUseCaseFactory
    {
         T Create<T>() where T : IUseCase;
    }
}