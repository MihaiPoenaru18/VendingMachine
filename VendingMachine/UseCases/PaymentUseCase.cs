using iQuest.VendingMachine.PaymentModel;
using iQuest.VendingMachine.PresentationLayer.Views;
using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine.UseCases
{
    internal class PaymentUseCase : IPaymentUseCase
    {
        private readonly IBuyView buyView;
        private readonly List<IPaymentAlgorithm> paymentAlgorithms;

        public PaymentUseCase(IEnumerable<IPaymentAlgorithm> paymentAlgorithms, IBuyView buyView)
        {
            if (paymentAlgorithms == null)
                throw new ArgumentNullException(nameof(paymentAlgorithms));

            this.paymentAlgorithms = new List<IPaymentAlgorithm>(paymentAlgorithms);
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));

        }

        public void Execute(float price)
        {

            IPaymentAlgorithm chosenPaymentAlgorithm = ChoosePaymentAlgorithm();
            if (chosenPaymentAlgorithm != null)
            {
                chosenPaymentAlgorithm.Run(price);
            }
            else
                throw new FormatException(" This payment algorithm it isn't exist!!!\n");
        }

        private IPaymentAlgorithm ChoosePaymentAlgorithm()
        {
            var paymentMethods = GetPaymentMethods();
            var chosenMethod = buyView.AskForPaymentMethod(paymentMethods);

            foreach (var paymentMethod in paymentMethods)
            {
                if (chosenMethod == paymentMethod.Id + 1)
                    return paymentAlgorithms[chosenMethod - 1];

            }
            return null;
        }

        private List<PaymentMethod> GetPaymentMethods()
        {
            var result = new List<PaymentMethod>();
            int i = 0;
            foreach (var paymentAlgorithm in paymentAlgorithms)
            {

                result.Add(new PaymentMethod
                {
                    Id = i,
                    Name = paymentAlgorithm.Name
                });
                i++;
            }
            return result;
        }

    }
}
