using iQuest.VendingMachine.Authentication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using iQuest.VendingMachine.PresentationLayer.Commands;

namespace VendingMachine.Test.BuyTests
{
    [TestClass]
    public class CanExecuteTests
    {
        private Mock<IAuthenticationService> authenticationServiceMock;

        [TestInitialize]
        public void TestSetup()
        {
            authenticationServiceMock = new Mock<IAuthenticationService>();
        }

        [TestMethod]
        public void HavingNoAdminLoggedIn_CanExecuteIsTrue()
        {
            //arange 
            authenticationServiceMock
                .Setup(x => x.IsUserAuthenticated)
                .Returns(false);

            //act
            BuyCommand buyCommand = new BuyCommand(authenticationServiceMock.Object, Mock.Of<IUseCaseFactory>());

            //assert               
            Assert.IsTrue(buyCommand.CanExecute);
        }

        [TestMethod]
        public void HavingAdminLoggedIn_CanExecuteIsFalse()
        {
            //arange 
            authenticationServiceMock
                .Setup(x => x.IsUserAuthenticated)
                .Returns(true);

            //act
            BuyCommand buyCommand = new BuyCommand(authenticationServiceMock.Object, Mock.Of<IUseCaseFactory>());

            //assert               
            Assert.IsFalse(buyCommand.CanExecute);
        }
    }
}
