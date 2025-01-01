using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        #region Product Repository
        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region Product Get
        [HttpGet]
        public IActionResult ProductGet()
        {
            var products = _productRepository.ProductSelectAll();
            return Ok(products);
        }
        #endregion

        #region Product Get By ID
        [HttpGet("{id}")]
        public IActionResult ProductGetByID(int id)
        {
            var products = _productRepository.SelectByID(id);
            return Ok(products);
        }
        #endregion

        #region Product Delete
        [HttpDelete("{id}")]
        public IActionResult ProductDelete(int id)
        {
            var products = _productRepository.ProductDelete(id);
            return Ok(products);
        }
        #endregion

        #region Product Insert
        [HttpPost]
        public IActionResult ProductInsert([FromBody] ProductModel product)
        {
            var products = _productRepository.ProductInsert(product);
            return Ok(products);
        }
        #endregion

        #region Product Update
        [HttpPut("{id}")]
        public IActionResult ProductUpdate(int id,[FromBody] ProductModel product)
        {
            var products = _productRepository.ProductUpdate(id,product);
            return Ok(products);
        }
        #endregion
    }
}
