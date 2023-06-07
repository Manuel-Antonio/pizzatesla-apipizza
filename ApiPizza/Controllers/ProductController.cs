using System;
using ApiPizza.Models;
using ApiPizza.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiPizza.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController: ControllerBase
    {

        IProductRepository productsRepository;
        public ProductController(IProductRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        [HttpGet]
        [Route("/GetProducts")]
        public async  Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return StatusCode(StatusCodes.Status200OK, await productsRepository.GetProducts()) ;
        }

        [HttpGet]
        [Route("/GetProducts/page/{page}/size/{size}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(int page, int size)
        {
            return StatusCode(StatusCodes.Status200OK, await productsRepository.GetProducts(page, size));
        }

        [HttpGet]
        [Route("/GetProductById")]
        public async Task<ActionResult<Product>> GetProductById(int PizzaID)
        {
            return StatusCode(StatusCodes.Status200OK, await productsRepository.GetProductById(PizzaID));
        }
        [HttpPost]
        [Route("/CreateProduct")]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            return StatusCode(StatusCodes.Status201Created, await productsRepository.CreateProduct(product));
        }
        [HttpPut]
        [Route("/UpdateProduct")]
        public async Task<ActionResult<Product>> UpdateProduct(Product product)
        {
            return StatusCode(StatusCodes.Status200OK, await productsRepository.UpdateProduct(product));
        }
        [HttpDelete]
        [Route("/DeleteProduct")]
        public async Task<ActionResult<bool>> DeleteProduct(int PizzaID)
        {
            return StatusCode(StatusCodes.Status200OK, await productsRepository.DeleteProduct(PizzaID));
        }
    }
}
