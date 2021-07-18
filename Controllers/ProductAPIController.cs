using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShopBridge.Controllers
{
    public class ProductAPIController : ApiController
    {
        private readonly IProductRepository _iproductRepository = new ProductRepository();

        [HttpGet]
        [Route("api/Product/Get")]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _iproductRepository.GetProduct();
        }

        [HttpPost]
        [Route("api/Product/Create")]
        public async Task CreateAsync([FromBody]Product product)
        {
            if (ModelState.IsValid)
            {
                await _iproductRepository.Add(product);
            }
        }

        [HttpGet]
        [Route("api/products/details/{id}")]
        public async Task<Product> Details(int id)
        {
            var result = await _iproductRepository.GetProducts(id);
            return result;
        }

        [HttpPut]
        [Route("api/product/edit")]
        public async Task EditAsync([FromBody]Product product)
        {
            if (ModelState.IsValid)
            {
                await _iproductRepository.Update(product);
            }
        }

        [HttpDelete]
        [Route("api/Product/Delete/{id}")]
        public async Task DeleteConfirmedAsync(int id)
        {
            await _iproductRepository.Delete(id);
        }
    }
}
