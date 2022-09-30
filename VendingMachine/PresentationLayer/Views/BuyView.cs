using iQuest.VendingMachine.PaymentModel;
using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer.Views
{
    internal class BuyView : DisplayBase, IBuyView
    {
        public int RequestProduct()
        {
            Display("Choose a product through id: ", color: ConsoleColor.Cyan);
            string readID = Console.ReadLine();
            int id;
            try
            {
                id = Convert.ToInt32(readID);
                return id;
            }
            catch (FormatException)
            {
                Console.WriteLine("The ID should be a integer number not a string!!!");
            }
            return 0;
        }

        public void DispenseProduct(string productName)
        {
            Display($"This is your {productName}\n", color: ConsoleColor.Green);
        }

        public int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods)
        {

            Display("You can pay with: \n", color: ConsoleColor.Cyan);
            foreach (var paymentMethod in paymentMethods)
            {
                Display($"{paymentMethod.Id + 1}.{paymentMethod.Name}\n", color: ConsoleColor.Cyan);
            }
            Display("You need to insert the id for method you choose!\n", color: ConsoleColor.DarkCyan);
            Display("You can choose the method of pay: ", color: ConsoleColor.Cyan);

            string readIdMethod = Console.ReadLine();
            int id;
            try
            {
                id = Convert.ToInt32(readIdMethod);
                foreach (var paymentMethod in paymentMethods)
                {

                    if (id == paymentMethod.Id + 1)
                    {
                        return id;
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("The ID should be a integer number not a string!!!");
            }
            return 0;
        }
    }
}
