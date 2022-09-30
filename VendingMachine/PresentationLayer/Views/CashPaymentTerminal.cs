using System;

namespace iQuest.VendingMachine.PresentationLayer.Views
{
    internal class CashPaymentTerminal : DisplayBase, ICashPaymentTerminal
    {
        public float AskForMoney()
        {
            Display("You need to introduct money in veding machine for product\n" +
                    "You can introduct 1$ or 5$ or 10$\n", color: ConsoleColor.Cyan);
            Display("Please introduct money:", color: ConsoleColor.DarkCyan);
            string readMoney = Console.ReadLine();
            int money;
            try
            {
                money = Convert.ToInt32(readMoney);
                return money;
            }
            catch (FormatException)
            {
                Display("Your money should be float not string\n", color: ConsoleColor.Red);
            }
            return 0;
        }

        public void GiveBackChange(float restOfMoney)
        {
            Display($"This is your rest of money:{restOfMoney}$\n", color: ConsoleColor.Green);
        }

    }
}
