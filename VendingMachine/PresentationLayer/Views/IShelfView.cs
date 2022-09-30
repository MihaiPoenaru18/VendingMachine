using System.Collections.Generic;

namespace iQuest.VendingMachine.PresentationLayer.Views
{
    public interface IShelfView
    {
        public void DisplayProducts(IEnumerable<Product> products);

    }
}
