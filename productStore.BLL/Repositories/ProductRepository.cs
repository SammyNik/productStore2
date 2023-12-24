using productStore.BLL.Models;
using productStore.DAL;
using productStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;


namespace productStore.BLL.Repositories
{
    internal class ProductRepositoryDb { };
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _dbContext;

        public ProductRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public void CreateProduct(CreateProduct product)
        {
            var productEntity = new Product();
            productEntity.Name = product.Name;
            _dbContext.SaveChanges();

            _dbContext.Products.Add(productEntity);
            _dbContext.SaveChanges();
        }
        public void DeleteProduct(int id)
        {
            var productToDelete = _dbContext.Products.FirstOrDefault(s => s.Id == id);

            if (productToDelete != null)
            {
                _dbContext.Products.Remove(productToDelete);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Store not found");
            }
        }
    }
}
