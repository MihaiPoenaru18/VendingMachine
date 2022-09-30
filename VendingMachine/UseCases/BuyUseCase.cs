using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.DataAccess;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.PresentationLayer.Views;
using iQuest.VendingMachine.VendingMachineException;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VendingMachine.Test")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace iQuest.VendingMachine.UseCases
{
    internal class BuyUseCase : IUseCase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IProductRepository productsRepository;
        private readonly IBuyView buyView;
        private readonly IPaymentUseCase paymentUseCase;

        public BuyUseCase(IPaymentUseCase paymentUseCase,IAuthenticationService authenticationService, IProductRepository productsRepository, IBuyView buyView)
        {
            this.paymentUseCase = paymentUseCase ?? throw new ArgumentNullException(nameof(paymentUseCase));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
        }

        public void Execute()
        {
            int columnId = buyView.RequestProduct();

            Product product = productsRepository.GetProductByColumnId(columnId);

            if (product == null) throw new InvalidColumnException($"Your column Id({columnId}) is invalid !!! \n" +
                                                                  "Please try again");
            if (product.Quantity < 1) throw new InsufficientStockException($"Insufficient Stock for this {product.Name}\n" +
                                       $" Please choase a other product out of {product.Name}\n");

            paymentUseCase.Execute(product.Price);

            product.Quantity -= 1;
            productsRepository.UpdateProduct(product);

            buyView.DispenseProduct(product.Name);
        }
    }
}
