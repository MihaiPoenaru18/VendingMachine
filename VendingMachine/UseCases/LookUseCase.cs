using iQuest.VendingMachine.DataAccess;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.PresentationLayer.Views;
using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine.UseCases
{
    internal class LookUseCase : IUseCase
    {
        private readonly IShelfView shelfView;
        private readonly IProductRepository productsRepository;

        public LookUseCase(IShelfView shelfView, IProductRepository productsRepository)
        {
            this.shelfView = shelfView ?? throw new ArgumentNullException(nameof(shelfView));
            this.productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
        }

        public void Execute()
        {
            IEnumerable<Product> allProducts = productsRepository.GetAllProduct();
            var productsForView = new List<Product>();

            foreach (var product in allProducts)
                if (product.Quantity > 0)
                    productsForView.Add(product);

            shelfView.DisplayProducts(productsForView);
        }
    }
}
