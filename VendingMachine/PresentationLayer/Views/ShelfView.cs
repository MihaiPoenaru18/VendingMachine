using System;
using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer.Views
{
     internal class ShelfView : DisplayBase, IShelfView
    {
        public void DisplayProducts(IEnumerable<Product> products)
        {
            if (HasProdusct(products))
            {
                Console.WriteLine("In vending machine we have the following products:\n");
                foreach (var product in products)
                    Console.WriteLine(" ColumnId - {0} \n Name - {1} \n Price - {2}$ \n Quantity - {3} oz(ounce) \n",
                        product.ColumnID, product.Name, product.Price, product.Quantity);
            }
        }
        private bool HasProdusct(IEnumerable<Product> products)
        {
            if (products == null)
                return false;
            return true;
        }

    }
}
