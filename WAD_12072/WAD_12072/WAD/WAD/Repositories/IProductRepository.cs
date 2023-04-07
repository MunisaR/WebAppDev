using System.Collections.Generic;
using WAD_12072.Models;

namespace WAD_12072.Repositories
{
    public interface IProductRepository
    {
        void InsertProdcut(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
        Product GetProductById(int Id);
        IEnumerable<Product> GetProduct();
    }
}


