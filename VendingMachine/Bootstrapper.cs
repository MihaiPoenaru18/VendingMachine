using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.DataAccess;
using iQuest.VendingMachine.PaymentModel;
using iQuest.VendingMachine.PresentationLayer.Views;
using iQuest.VendingMachine.UseCases;
using Autofac;
using System.Reflection;
using iQuest.VendingMachine.PresentationLayer.Commands;
using iQuest.VendingMachine.Serialize;
using System;

namespace iQuest.VendingMachine
{
    internal class Bootstrapper
    {
        public void Run()
        {
            var vendingMachineApplication = BuildApplication();
            vendingMachineApplication.Resolve<IVendingMachineApplication>().Run();
        }

        private static IContainer BuildApplication()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainView>().As<IMainView>();
            builder.RegisterType<ShelfView>().As<IShelfView>();
            builder.RegisterType<LoginView>().As<ILoginView>();
            builder.RegisterType<BuyView>().As<IBuyView>();
            builder.RegisterType<ReportsView>().As<IReportsView>();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();

            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LiteDB"].ConnectionString;
            builder.Register(liteDB => new LiteDbProductRepository(connectionString)).As<IProductRepository>().SingleInstance();

            var reportType = System.Configuration.ConfigurationManager.AppSettings["RaportsType"];
            var zipPath = System.Configuration.ConfigurationManager.AppSettings["PathForZip"];
            var reportPath = System.Configuration.ConfigurationManager.AppSettings["PathForReport"];

            switch (reportType)
            {
                case ".xml":
                    builder.Register(liteDB => new ReportXmlSerializer(reportType, zipPath, reportPath)).As<IFileSerializer>().SingleInstance();
                    break;
                case ".json":
                    builder.Register(liteDB => new ReportJsonSerializer(reportType, zipPath, reportPath)).As<IFileSerializer>().SingleInstance();
                    break;
            }
           
            Assembly paymentMethod = typeof(IPaymentAlgorithm).Assembly;
            builder.RegisterAssemblyTypes(paymentMethod).As<IPaymentAlgorithm>();
            builder.RegisterType<PaymentUseCase>().As<IPaymentUseCase>();
            builder.RegisterType<CardPaymentTerminal>().As<ICardPaymentTerminal>();
            builder.RegisterType<CashPaymentTerminal>().As<ICashPaymentTerminal>();
            builder.RegisterType<SalesRepository>().As<ISalesRepository>();
            builder.RegisterType<UseCaseFactory>().As<IUseCaseFactory>();

            Assembly commandAssembly = typeof(ICommand).Assembly;
            builder.RegisterAssemblyTypes(commandAssembly).As<ICommand>();

            Assembly useCasesAssembly = typeof(IUseCase).Assembly;
            builder.RegisterAssemblyTypes(useCasesAssembly).AsSelf();

            builder.RegisterType<VendingMachineApplication>().As<IVendingMachineApplication>().SingleInstance();
            return builder.Build();
        }
    }
}
