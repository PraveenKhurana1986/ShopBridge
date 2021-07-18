using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge.Models
{
    public interface IProductRepository
    {
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(int id);
        Task<Product> GetProducts(int id);
        Task<IEnumerable<Product>> GetProduct();
    }
}
c
