using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.DataAccess;
using iQuest.VendingMachine.DataAccess.Reports;
using iQuest.VendingMachine.PresentationLayer.Views;
using iQuest.VendingMachine.Serialize;
using System.Linq;
using System;

namespace iQuest.VendingMachine.UseCases
{
    internal class StockUseCase : IUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly IReportsView reportsView;
        private readonly IAuthenticationService authenticationService;
        private readonly IFileSerializer serializer;

        public StockUseCase(IProductRepository productRepository, IReportsView reportsView, IFileSerializer serializer, IAuthenticationService authenticationService)
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.reportsView = reportsView ?? throw new ArgumentNullException(nameof(reportsView));
            this.serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            var stockProducts = productRepository.GetAllProduct()
                                                .Select(x => new Report { Name = x.Name, Quantity = x.Quantity }).ToList();
            serializer.Serilizer(new StockReport (stockProducts), $"Stock Report - {reportsView.DisplayCurrentDateTime()}.zip");
            reportsView.DisplayDoneWithGetReport();
        }
    }
}