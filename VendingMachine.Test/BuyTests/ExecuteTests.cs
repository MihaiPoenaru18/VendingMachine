using Moq;
using iQuest.VendingMachine.Authentication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using iQuest.VendingMachine.DataAccess;
using iQuest.VendingMachine.PresentationLayer.Views;
using iQuest.VendingMachine.UseCases;
using iQuest.VendingMachine.VendingMachineException;
using iQuest.VendingMachine.PresentationLayer;

namespace VendingMachine.Test.BuyTests
{
    [TestClass]
    public class ExecuteTests
    {
        private Mock<IAuthenticationService> authenticationServiceMock;
        private Mock<IProductRepository> productsRepositoryMock;
        private Mock<IBuyView> buyViewMock;
        private Mock<IPaymentUseCase> paymentUseCaseMock;
        private BuyUseCase buyUseCase;


        [TestInitialize]
        public void TestInitialize()
        {
            authenticationServiceMock = new Mock<IAuthenticationService>();
            productsRepositoryMock = new Mock<IProductRepository>();
            buyViewMock = new Mock<IBuyView>();
            paymentUseCaseMock = new Mock<IPaymentUseCase>();
            buyUseCase = new BuyUseCase(paymentUseCaseMock.Object, authenticationServiceMock.Object, productsRepositoryMock.Object, buyViewMock.Object);
        }

        [TestMethod]
        public void HavingABuyUseCaseInstance_WhenExecuted_ThenUserRequestProduct()
        {
            //arange
            productsRepositoryMock
                .Setup(x => x.GetProductByColumnId(It.IsAny<int>()))
                .Returns(new Product
                {
                    ColumnID = 11,
                    Name = "KitKat",
                    Price = 4f,
                    Quantity = 50

                });

            //act
            buyUseCase.Execute();

            //assert
            buyViewMock.Verify(x => x.RequestProduct(), Times.Once);
        }

        [TestMethod]
        public void HavingABuyUseCaseInstance_WhenInvalidColumnExceptiont_ThrowsException()
        {
            //arange
            productsRepositoryMock
                .Setup(x => x.GetProductByColumnId(1));

            //act assert    
            Assert.ThrowsException<InvalidColumnException>(() =>
            {
                buyUseCase.Execute();
            });
        }

        [TestMethod]
        public void HavingABuyUseCaseInstance_WhenInsufficientStockException_ThrowsException()
        {
            //arange
            productsRepositoryMock
                .Setup(x => x.GetProductByColumnId(It.IsAny<int>()))
               .Returns(new Product
               {
                   ColumnID = 11,
                   Name = "KitKat",
                   Price = 4f,
                   Quantity = 0

               });

            Assert.ThrowsException<InsufficientStockException>(() =>
            {
                buyUseCase.Execute();
            });
        }

        [TestMethod]
        public void HavingABuyUseCaseInstance_WhenExecuted_ThenPaymentUseCase()
        {
            //arange
            productsRepositoryMock
                .Setup(x => x.GetProductByColumnId(It.IsAny<int>()))
               .Returns(new Product
               {
                   ColumnID = 11,
                   Name = "KitKat",
                   Price = 4.00f,
                   Quantity = 50

               });

            //act
            buyUseCase.Execute();

            //assert
            paymentUseCaseMock.Verify(x => x.Execute(4));
        }

        [TestMethod]
        public void HavingABuyUseCaseInstance_WhenExecuted_ThenUpdateProduct()
        {
            //arange
            productsRepositoryMock
                .Setup(x => x.GetProductByColumnId(It.IsAny<int>()))
                .Returns(new Product
                {

                    ColumnID = 11,
                    Name = "KitKat",
                    Price = 4f,
                    Quantity = 50
                });
            productsRepositoryMock
                .Setup(x => x.UpdateProduct(It.IsAny<Product>()));

            //act
            buyUseCase.Execute();

            //assert
            productsRepositoryMock.Verify(x => x.UpdateProduct(It.IsAny<Product>()), Times.Once);
        }

        [TestMethod]
        public void HavingABuyUseCaseInstance_WhenExecuted_ThenDispenseProduct()
        {
            //arange
            productsRepositoryMock
                .Setup(x => x.GetProductByColumnId(It.IsAny<int>()))
                .Returns(new Product
                {
                    ColumnID = 11,
                    Name = "KitKat",
                    Price = 4f,
                    Quantity = 50
                });

            //act
            buyUseCase.Execute();

            //assert
            buyViewMock.Verify(x => x.DispenseProduct(It.IsAny<string>()), Times.Once);
        }
    }
}
