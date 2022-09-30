using iQuest.VendingMachine.PaymentModel;
using iQuest.VendingMachine.PresentationLayer.Views;
using iQuest.VendingMachine.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace VendingMachine.Test.PaymentTests
{
    [TestClass]
    public class ExecuteTest
    {
        private Mock<IBuyView> buyViewMock;
        private Mock<IPaymentAlgorithm> mockCardPayment;
        private Mock<IPaymentAlgorithm> mockCashPayment;
        private PaymentUseCase paymentUseCase;
        private IList<IPaymentAlgorithm> algorithms;

        [TestInitialize]
        public void TestInitialize()
        {

            buyViewMock = new Mock<IBuyView>();
            mockCardPayment = new Mock<IPaymentAlgorithm>();
            mockCashPayment = new Mock<IPaymentAlgorithm>();
            algorithms = new List<IPaymentAlgorithm> 
            { 
                mockCardPayment.Object,
                mockCashPayment.Object
            };
            paymentUseCase = new PaymentUseCase(algorithms, buyViewMock.Object);
        }

        [TestMethod]
        public void HavingPaymentUseCaseInstance_WhenExecuted_ThenUseChoosePaymentAlgorithm()
        {
            //arange
            mockCardPayment
                .Setup(x => x.Name)
                .Returns("card");
            mockCashPayment
                .Setup(x => x.Name)
                .Returns("cash");
            buyViewMock
               .Setup(x => x.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>()))
               .Returns(1);
            //act
            paymentUseCase.Execute(4);
            //assert
            buyViewMock.Verify(x => x.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>()));
        }

        [TestMethod]
        public void HavingPaymentUseCaseInstance_WhenExecuted_ThenUsePaymentMethod()
        {
            //arange
            mockCardPayment
               .Setup(x => x.Name)
               .Returns("card");
            mockCashPayment
                .Setup(x => x.Name)
                .Returns("cash");
            mockCardPayment
                .Setup(x => x.Run(It.IsAny<int>()));
            buyViewMock
               .Setup(x => x.AskForPaymentMethod(It.IsAny<List<PaymentMethod>>()))
               .Returns(1);
            //act
            paymentUseCase.Execute(4);
            //assert
            mockCardPayment.Verify(x => x.Run(4));
        }
    }
}
