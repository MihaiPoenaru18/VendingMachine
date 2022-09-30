using iQuest.VendingMachine.PresentationLayer;
using System.Collections.Generic;

namespace iQuest.VendingMachine.DataAccess
{
    internal class ProductRepository 
    {

        private readonly IEnumerable<Product> products = new List<Product>
        {
            new Product
            {
                ColumnID = 11,
                Name = "KitKat",
                Price = 4.00f,
                Quantity = 50

            },
            new Product
            {
                ColumnID = 12,
                Name = "CocaCola",
                Price = 3.00f,
                Quantity = 30
            },

            new Product
            {
                ColumnID = 13,
                Name = "Chio Chips",
                Price = 6.00f,
                Quantity = 50
            },

             new Product
            {
                ColumnID = 14,
                Name = "Battery x2",
                Price = 9.98f,
                Quantity = 100
            },
               new Product
            {
                ColumnID = 15,
                Name = "Chopsticks",
                Price = 2.50f,
                Quantity = 3
            },

        };

        
        public IEnumerable<Product> GetAllProduct()
        {
            List<Product> listAllproducts = new List<Product>();
            foreach (var product in products)
                listAllproducts.Add(product);

            return listAllproducts;
        }

        public void DecrementStock(int id)
        {
            foreach (var product in products)
            {
                product.Quantity -= 1;
            }
        }

        public Product GetProductByColumnId(int id)
        {
            foreach (var product in products)
                if (product.ColumnID == id)
                {
                    return product;
                }

            return null;
        }
    }
}
