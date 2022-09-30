using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.DataAccess;
using iQuest.VendingMachine.DataAccess.Reports;
using iQuest.VendingMachine.PresentationLayer.Views;
using iQuest.VendingMachine.Serialize;
using System;
using System.Linq;

namespace iQuest.VendingMachine.UseCases
{
    internal class VolumeUseCase : IUseCase
    {
        private readonly ISalesRepository salesRepository;
        private readonly IReportsView reportsView;
        private readonly IAuthenticationService authenticationService;
        private readonly IFileSerializer serializer;

        public VolumeUseCase(ISalesRepository salesRepository, IReportsView reportsView, IFileSerializer serializer, IAuthenticationService authenticationService)
        {
            this.salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
            this.reportsView = reportsView ?? throw new ArgumentNullException(nameof(reportsView));
            this.serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            reportsView.AskForPeriodOfTime();
            var startDate = reportsView.AskForStartDate().Date;
            var endDate = reportsView.AskForEndDate().Date;

            if (!ConflictWith(startDate, endDate))
            {
                var salesProducts = salesRepository.GetAllSales().Where(x => x.SaleDate.Date >= startDate || x.SaleDate.Date >= endDate)
                                                   .GroupBy(x => x.product.Name)
                                                   .Select(x => new Report { Name = x.Key, Quantity = x.ToList().Count() });
                var volumProducts = new VolumeReport() { StarDate = startDate, EndDate = endDate, Sales = salesProducts.ToList() };
                serializer.Serilizer(volumProducts, $"Volume Reports - {reportsView.DisplayCurrentDateTime()}.zip");
                reportsView.DisplayDoneWithGetReport();
            }
            else
                throw new Exception($"Conflict Exception between start date({startDate}) and end date({endDate})");
        }

        private bool ConflictWith(DateTime startDate, DateTime endDate)
        {
            return startDate > endDate;
        }
    }
}
