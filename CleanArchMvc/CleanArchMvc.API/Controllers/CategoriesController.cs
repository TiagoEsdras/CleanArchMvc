using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> Get()
        {
            var categories = await categoryService.GetCategories();

            if (categories is null) return NotFound("Categories not found");

            return Ok(categories);
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            var category = await categoryService.GetById(id);

            if (category is null) return NotFound("Category not found");

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Post([FromBody] CreateCategoryDto categoryDto)
        {
            if (categoryDto is null) return BadRequest("Invalid data");

            var categoryCreated = await categoryService.Add(categoryDto);

            return new CreatedAtRouteResult("GetCategory", new { id = categoryCreated.Id }, categoryCreated);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDto>> Put(int id, [FromBody] CategoryDto categoryDto)
        {
            if (categoryDto is null || id != categoryDto.Id) return BadRequest();

            await categoryService.Update(categoryDto);

            return Ok(categoryDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await categoryService.GetById(id);

            if (category is null) return NotFound("Category not found");

            await categoryService.Remove(id);

            return NoContent();
        }
    }
}