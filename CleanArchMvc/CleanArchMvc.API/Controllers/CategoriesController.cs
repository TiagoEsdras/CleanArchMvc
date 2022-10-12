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

        [HttpGet("id")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            var category = await categoryService.GetById(id);

            if (category is null) return NotFound("Category not found");

            return Ok(category);
        }
    }
}