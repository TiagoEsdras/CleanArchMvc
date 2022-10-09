using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchMvc.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetCategories();
            return View(categories);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                await categoryService.Add(categoryDto);
                return RedirectToAction(nameof(Index));
            }

            return View(categoryDto);
        }
    }
}