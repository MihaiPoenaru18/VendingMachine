namespace iQuest.VendingMachine.Authentication
{
    public interface IAuthenticationService
    {
        bool IsUserAuthenticated { get; }

        void Logout();

        void Login(string password);
    }
}
