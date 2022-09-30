using iQuest.VendingMachine.PaymentModel;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer.Views
{
    internal interface IBuyView
    {
        int RequestProduct();

        void DispenseProduct(string productName);

        public int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods);
    }
}
