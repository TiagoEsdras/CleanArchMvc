using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            context.Add(category);
            await context.SaveChangesAsync();
            return category;
        }

        public async Task DeleteAsync(Category category)
        {
            context.Remove(category);
            await context.SaveChangesAsync();
        }

        public async Task<Category> GetByIdAsync(int? id)
        {
            return await context.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            context.Update(category);
            await context.SaveChangesAsync();
            return category;
        }
    }
}