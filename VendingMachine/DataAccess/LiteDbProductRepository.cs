using iQuest.VendingMachine.PresentationLayer;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iQuest.VendingMachine.DataAccess
{
    internal class LiteDbProductRepository : IProductRepository, IDisposable
    {
        private readonly LiteDatabase context;
        private readonly ILiteCollection<Product> productsCollection;
        private bool disposedValue;

        public LiteDbProductRepository(string connectionString)
        {
            context = new LiteDatabase(connectionString);
            productsCollection = this.context.GetCollection<Product>();
        }

        public void AddNewProduct(Product product)
        {
            productsCollection.Insert(product);
        }

        public Product GetProductByColumnId(int columnId)
        {
            return productsCollection.Find(x => x.ColumnID == columnId).FirstOrDefault();
        }

        public void DeleteProductByColumnID(int columnID)
        {
            productsCollection.Delete(columnID);
        }

        public void UpdateProduct(Product product)
        {
            productsCollection.Update(product);
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return productsCollection.FindAll().ToList();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
                return;
            if (disposing)
            {
                context?.Dispose();
            }
            disposedValue = true;
        }

        void IDisposable.Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
