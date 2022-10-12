using CleanArchMvc.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> GetById(int? id);

        Task<IEnumerable<ProductDto>> GetProducts();

        Task<ProductDto> Add(CreateProductDto productDto);

        Task Update(ProductDto productDto);

        Task Remove(int? id);
    }
}