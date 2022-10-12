using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<CategoryDto> GetById(int? id)
        {
            var categoryEntity = await categoryRepository.GetByIdAsync(id);
            return mapper.Map<CategoryDto>(categoryEntity);
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categoriesEntity = await categoryRepository.GetCategoriesAsync();
            return mapper.Map<IEnumerable<CategoryDto>>(categoriesEntity);
        }

        public async Task<CategoryDto> Add(CreateCategoryDto categoryDto)
        {
            var categoryEntity = mapper.Map<Category>(categoryDto);
            var categoryCreated = await categoryRepository.CreateAsync(categoryEntity);
            return mapper.Map<CategoryDto>(categoryCreated);
        }

        public async Task Update(CategoryDto categoryDto)
        {
            var categoryEntiry = mapper.Map<Category>(categoryDto);
            await categoryRepository.UpdateAsync(categoryEntiry);
        }

        public async Task Remove(int? id)
        {
            var categoryEntity = await categoryRepository.GetByIdAsync(id);
            await categoryRepository.DeleteAsync(categoryEntity);
        }
    }
}