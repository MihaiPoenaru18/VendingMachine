using iQuest.VendingMachine.PresentationLayer;
using System;

namespace iQuest.VendingMachine
{
    public class Sales 
    {
        public string PaymentMethod { get; set; }

        public DateTime SaleDate { get; set; }

        public Product product { get; set; }
    }
}
