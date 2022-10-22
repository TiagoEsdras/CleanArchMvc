using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            var products = await productService.GetProducts();

            if (products is null) return NotFound("Products not found");

            return Ok(products);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var product = await productService.GetById(id);

            if (product is null) return NotFound("Product not found");

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Post([FromBody] CreateProductDto productDto)
        {
            if (productDto is null) return BadRequest("Invalid data");

            var productCreated = await productService.Add(productDto);

            return new CreatedAtRouteResult("GetProduct", new { id = productCreated.Id }, productCreated);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> Put(int id, [FromBody] ProductDto productDto)
        {
            if (productDto is null || id != productDto.Id) return BadRequest();

            await productService.Update(productDto);

            return Ok(productDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await productService.GetById(id);

            if (product is null) return NotFound("Product not found");

            await productService.Remove(id);

            return NoContent();
        }
    }
}