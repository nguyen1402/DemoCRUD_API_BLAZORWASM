using System.Threading.Tasks;
using BlazorProduct.Api.Models;
using BlazorProduct.Api.Responsitori;
using Entities.Models;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlazorProducts.Server.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
          var prs =  await _repo.GetAll();

            return Ok(prs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pr = await _repo.GetProduct(id);

            return Ok(pr);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();

            await _repo.CreatProduct(product);

            return Created("", product);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductUpdate product)
        {
            var prdb = await _repo.GetProduct(id);
            if (prdb == null)
            {
                return BadRequest();
            }
            await _repo.UpdateProduct(product,prdb);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var prdb = await _repo.GetProduct(id);
            if (prdb == null)
            {
                return BadRequest();
            }
            await _repo.DeleteProduct(prdb);

            return NoContent();
        }
    }
}

