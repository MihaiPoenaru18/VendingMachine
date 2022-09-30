using iQuest.VendingMachine.PaymentModel;
using iQuest.VendingMachine.PresentationLayer.Views;
using iQuest.VendingMachine.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace VendingMachine.Test.PaymentTests
{ 
    [TestClass]
    public class ConstractorTests
    {
        [TestMethod]
        public void HavingANullPaymentAlgorithm_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new PaymentUseCase(null, Mock.Of<IBuyView>());
            });
        }

        [TestMethod]
        public void HavingANullBuyView_WhenInitializingTheUseCase_ThrowsException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
             {
                 new PaymentUseCase(Mock.Of<IList<IPaymentAlgorithm>>(), null);
             });
        }
    }

}
