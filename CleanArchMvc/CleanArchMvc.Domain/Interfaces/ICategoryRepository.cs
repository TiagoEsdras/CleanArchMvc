using CleanArchMvc.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task<Category> GetByIdAsync(int? id);

        Task<Category> CreateAsync(Category category);

        Task<Category> UpdateAsync(Category category);

        Task DeleteAsync(Category category);
    }
}