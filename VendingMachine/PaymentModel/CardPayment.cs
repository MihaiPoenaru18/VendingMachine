using iQuest.VendingMachine.PresentationLayer.Views;
using iQuest.VendingMachine.VendingMachineException;
using System;

namespace iQuest.VendingMachine.PaymentModel
{
    internal class CardPayment : IPaymentAlgorithm
    {
        private readonly ICardPaymentTerminal cardPaymentTerminal;

        public  CardPayment(ICardPaymentTerminal cardPaymentTerminal)
        {
            this.cardPaymentTerminal = cardPaymentTerminal ?? throw new ArgumentNullException(nameof(cardPaymentTerminal));
        }

        public string Name => "card ";

        public void Run(float price)
        {
            if (!IsCardNumberValid(cardPaymentTerminal.AskForCardNumber()))
            {
                throw new InvalidCardNumber("Your card number is invalid!!!");
            }
        }

        private bool IsCardNumberValid(String cardNumber)
        {
            int digitLength = cardNumber.Length;
            int sum = 0;
            bool verification = false;

            for (int i = digitLength - 1; i >= 0; i--)
            {
                int doubleDigit = cardNumber[i] - '0';
                if (verification == true)
                    doubleDigit *= 2;
                sum += doubleDigit / 10;
                sum += doubleDigit % 10;
                verification = !verification;
            }
            return (sum % 10 == 0);
        }
    }
}
