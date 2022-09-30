using iQuest.VendingMachine.Authentication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using iQuest.VendingMachine.UseCases;
using iQuest.VendingMachine.DataAccess;
using iQuest.VendingMachine.PresentationLayer.Views;
using System;

namespace VendingMachine.Test.BuyTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void HavingANullPaymentUseCase_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new BuyUseCase(null, Mock.Of<IAuthenticationService>(), Mock.Of<IProductRepository>(), Mock.Of<IBuyView>());
            });
        }
        [TestMethod]
        public void HavingANullAuthenticationService_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new BuyUseCase( Mock.Of<IPaymentUseCase>(),null, Mock.Of<IProductRepository>(), Mock.Of<IBuyView>());
            });
        }

        [TestMethod]
        public void HavingANullProductRepository_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new BuyUseCase(Mock.Of<IPaymentUseCase>(), Mock.Of<IAuthenticationService>(), null, Mock.Of<IBuyView>());
            });
        }

        [TestMethod]
        public void HavingANullBuyView_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new BuyUseCase(Mock.Of<IPaymentUseCase>(), Mock.Of<IAuthenticationService>(), Mock.Of<IProductRepository>(), null);
            });
        }
    }
}
