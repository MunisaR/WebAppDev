using System.Collections.Generic;
using WAD_12072.DAL;
using WAD_12072.Models;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace WAD_12072.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CategoryContext _dbContext;
        public ProductRepository(CategoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        private Product FindCategoryById(int productId)
        {
            return _dbContext.Products.Find(productId);
        }

        public void DeleteProduct(int productId)
        {
            var product = FindCategoryById(productId);
            _dbContext.Products.Remove(product);
            Save();
        }

        public IEnumerable<Product> GetProduct()
        {
            return _dbContext.Products.Include(s => s.Category).ToList();

        }

        public Product GetProductById(int Id)
        {
            var product = FindCategoryById(Id);
            _dbContext.Entry(product).Reference(s => s.Category).Load();

            return product;
        }

        public void InsertProdcut(Product product)
        {
            if (product.Category != null)
            {
                product.Category = _dbContext.Categories.FirstOrDefault(h => h.ID == product.Category.ID);
            }
            _dbContext.Add(product);
            Save();
        }

        private void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = _dbContext.Products.Find(product.ID);


            // Update the existingProgress object with the updated Category object
            existingProduct.Category.ID = product.Category.ID;
            existingProduct.Price = product.Price;
            existingProduct.isActive = product.isActive;
            existingProduct.Description = product.Description;
            existingProduct.CreatedAt = product.CreatedAt;

            Save();
        }

    }
}
