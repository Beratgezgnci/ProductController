using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ProductController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly List<Product> _products = [
            new Product(1, "Kalem", 10,"Kırtasiye"),
            new Product(2, "Bilgisayar", 1000, "Elektronik"),
            new Product(3, "Klavye", 550, "Elektronik"),
            new Product(4, "Anahtar", 10, "Hırdavat"),
        ];
        [HttpGet("/product")]
        public IActionResult Get()
        {
            return Ok(_products);
        }
        [HttpGet("/product/{id}")]
        public IActionResult Get(int id)
        {
            var item = _products.FirstOrDefault(x => x.Id == id);
            if (item != null) { return Ok(item); }
            return NotFound(); 
        }
        [HttpPost("/product")]
        public IActionResult Add(Product product)
        {
            _products.Add(product);
            return Ok(product);
        }
        [HttpPut("/product/{id}")]
        public IActionResult Update(int id, Product product)
        {

            if (id != product.Id)
                return BadRequest();

            int index = _products.FindIndex(t => t.Id == id);

            if (index == -1)
                return NotFound();

            _products[index] = product;
            return Ok(_products[index]);

        }
        [HttpDelete("/product/{id}")]
        public IActionResult Delete(int id)
        {
            var index = _products.FindIndex(x => x.Id == id);
            if (index == -1) { return BadRequest(); }
            _products.RemoveAt(index);
            return Ok(_products[index]);

        }


    }
}
