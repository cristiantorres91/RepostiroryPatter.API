using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepostiroryPatter.API.Infraestructure;
using RepostiroryPatter.API.Infraestructure.Repositories;
using RepostiroryPatter.API.Models;
using System.Net.NetworkInformation;

namespace RepostiroryPatter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _repository;

        public ProductsController(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _repository.GetAll(); 
            return Ok(products.ToList());
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _repository.Get(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }


        // POST: api/Products

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            await _repository.Create(product);

            return Ok();
        }


        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _repository.Edit(product);

            return Ok();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _repository.Get(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            await _repository.Delete(product);

            return Ok();
        }

    }
}
