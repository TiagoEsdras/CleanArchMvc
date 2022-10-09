using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            context.Add(product);
            await context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(Product product)
        {
            context.Remove(product);
            await context.SaveChangesAsync();
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await context.Products.Include(it => it.Category).SingleOrDefaultAsync(it => it.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            context.Update(product);
            await context.SaveChangesAsync();
            return product;
        }
    }
}