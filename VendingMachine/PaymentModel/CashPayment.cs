using iQuest.VendingMachine.PresentationLayer.Views;
using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PaymentModel
{
    internal class CashPayment : IPaymentAlgorithm
    {
        private readonly ICashPaymentTerminal cashPaymentTerminal;
        private readonly IList<float> validBanknoteValues = new List<float> { 1, 5, 10 };

        public CashPayment(ICashPaymentTerminal cashPaymentTerminal)
        {
            this.cashPaymentTerminal = cashPaymentTerminal ?? throw new ArgumentNullException(nameof(cashPaymentTerminal));
        }

        public string Name => "cash";

        public void Run(float price)
        {
            float total = 0;
            while (total < price)
            {
                float money = cashPaymentTerminal.AskForMoney();
                if (IsBanknoteValueValid(money))
                {
                    total += money;
                }
                else
                    throw new FormatException("Your banknote is invalid!!!\nPlease try again\n");
            }

            if (total > price)
            {
                cashPaymentTerminal.GiveBackChange(total - price);
            }
            
        }

        private bool IsBanknoteValueValid(float banknote)
        {
            return validBanknoteValues.Contains(banknote);
        }
    }
}
