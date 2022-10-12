using CleanArchMvc.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDto> GetById(int? id);

        Task<IEnumerable<CategoryDto>> GetCategories();

        Task<CategoryDto> Add(CreateCategoryDto categoryDto);

        Task Update(CategoryDto categoryDto);

        Task Remove(int? id);
    }
}