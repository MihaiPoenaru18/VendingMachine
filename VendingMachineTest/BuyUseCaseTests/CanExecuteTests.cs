using iQuest.VendingMachine.Authentication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using iQuest.VendingMachine.UseCases;
using iQuest.VendingMachine.DateLayer;
using iQuest.VendingMachine.PresentationLayer.Views;

namespace VendingMachineTest
{
    [TestClass]
    public class CanExecuteTests
    {
        private Mock<IAuthenticationService> authenticationService;
        private Mock<IProductRepository> productsRepository;
        private Mock<IBuyView> buyview;

        [TestInitialize]
        public void TestSetup()
        {
            authenticationService = new Mock<IAuthenticationService>();
            productsRepository = new Mock<IProductRepository>();
            buyview = new Mock<IBuyView>();
        }

        [TestMethod]
        public void HavingAdminLoggedIn_CanExecuteIsTrue()
        {
            authenticationService
                .Setup(x => x.IsUserAuthenticated)
                .Returns(false);
            BuyUseCase buyUseCase=new BuyUseCase(authenticationService.Object,productsRepository.Object,buy)
        }
    }
}
