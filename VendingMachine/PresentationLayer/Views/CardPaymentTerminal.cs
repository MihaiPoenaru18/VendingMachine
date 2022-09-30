using System;

namespace iQuest.VendingMachine.PresentationLayer.Views
{
    internal class CardPaymentTerminal : DisplayBase, ICardPaymentTerminal
    {
        public string AskForCardNumber()
        {
            Display("Please introduct your card  number: \n", color: ConsoleColor.Cyan);
            string cardNumberRead = Console.ReadLine();

            return cardNumberRead;
        }
    }
}
