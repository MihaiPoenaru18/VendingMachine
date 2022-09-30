using iQuest.VendingMachine.PresentationLayer;
using System.Collections.Generic;
using System.Linq;

namespace iQuest.VendingMachine.DataAccess
{
    internal class SalesRepository : ISalesRepository
    {
        private readonly IEnumerable<Sales> sales = new List<Sales>
        {
            new Sales
            {
                 product = new Product()
                {
                      ColumnID = 1,
                      Name = "KitKat",
                      Price=4f,
                      Quantity = 10,
                },
                PaymentMethod = "cash",
                SaleDate = new System.DateTime(2022,3,2)
            },

            new Sales
            {
                 product = new Product()
                {
                    ColumnID = 2,
                    Name = "CocaCola",
                    Price = 3.00f,
                    Quantity = 12,
                },
                 PaymentMethod = "card",
                SaleDate = new System.DateTime(2022,1,4)
            },

            new Sales
            {
                 product = new Product()
                {
                    ColumnID = 3,
                    Name = "Chio Chips",
                    Price = 6.00f,
                    Quantity = 23,
                },
                 PaymentMethod = "card",
                SaleDate = new System.DateTime(2022,1,6)
            },

             new Sales
            {
                 product = new Product()
                {
                    ColumnID = 4,
                    Name = "Battery x2",
                    Price = 9.98f,
                    Quantity = 43,
                },
                PaymentMethod = "card",
                SaleDate = new System.DateTime(2022,3,6)
            },
               new Sales
            {

                product = new Product()
                {
                    ColumnID = 5,
                    Name = "Chopsticks",
                    Price = 2.50f,
                    Quantity = 1,
                },
                PaymentMethod = "cash",
                SaleDate = new System.DateTime(2022,2,12)
            },
        };

        public IEnumerable<Sales> GetAllSales()
        {
            List<Sales> listAllSales = new List<Sales>();
            foreach (var sale in sales)
                listAllSales.Add(sale);

            return listAllSales;
        }
    }
}