using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ShopBridge.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly SqlDbContext db = new SqlDbContext();
        public async Task Add(Product product)
        {
           // product.ProductId = new Random().Next(1001, 2000); 
            db.Products.Add(product);
            try
            {
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Product> GetProducts(int id)
        {
            try
            {
                Product product = await db.Products.FindAsync(id);
                if (product == null)
                {
                    return null;
                }
                return product;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Product>> GetProduct()
        {
            try
            {
                var products = await db.Products.ToListAsync();
                return products.AsQueryable();
            }
            catch
            {
                throw;
            }
        }
        public async Task Update(Product product)
        {
            try
            {
                db.Entry(product).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                Product product = await db.Products.FindAsync(id);
                db.Products.Remove(product);
                await db.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductId == id) > 0;
        }

    }
}