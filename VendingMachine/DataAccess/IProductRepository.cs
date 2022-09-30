using iQuest.VendingMachine.PresentationLayer;
using System.Collections.Generic;

namespace iQuest.VendingMachine.DataAccess
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProduct();
        public Product GetProductByColumnId(int columnId);
        public void DeleteProductByColumnID(int columnID);
        public void AddNewProduct(Product product);
        void UpdateProduct(Product product);
    }
}
