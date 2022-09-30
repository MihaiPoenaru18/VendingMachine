using System;

namespace iQuest.VendingMachine.DataAccess.Reports
{
    public class SalesReport 
    {
        public DateTime Date { set; get; }
        public string Name { set; get; }
        public float Price { set; get; }
        public string PaymentMethod { set; get; }
    }
}