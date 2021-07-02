using APIWhitSwagger.Domain.Entities;
using APIWhitSwagger.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APIWithSwagger.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProduct()
        {
            var products = _productRepository.GetAll();
            return Ok(products);
        }

        /// <summary>
        /// Este método nos devuelve la lista de todos los productos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Product GetProductById(string id)
        {
            var products = _productRepository.GetByID(id);
            return products;
        }

        [HttpPost]
        public void CreateProduct(Product product)
        {
            _productRepository.Insert(product);
            _productRepository.SaveAsync();
        }

        /// <summary>
        /// Este método nos permite actualizar los productos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <response code = "201"> Este código nos muestra que se actualizado correctamente </response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult UpdateProduct(string id, Product product)
        {
            _productRepository.Update(product);
            _productRepository.Save();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(string id)
        {
            var productFound = _productRepository.GetByID(id);
            _productRepository.Delete(productFound);
            _productRepository.Save();
            return Ok();
        }
    }
}
