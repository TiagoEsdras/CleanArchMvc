using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<ProductDto> GetById(int? id)
        {
            var productEntity = await productRepository.GetByIdAsync(id);
            return mapper.Map<ProductDto>(productEntity);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var productsEntity = await productRepository.GetProductsAsync();
            return mapper.Map<IEnumerable<ProductDto>>(productsEntity);
        }

        public async Task<ProductDto> GetProductCategory(int? id)
        {
            var productEntity = await productRepository.GetProductCategoryAsync(id);
            return mapper.Map<ProductDto>(productEntity);
        }

        public async Task Add(ProductDto productDto)
        {
            var productEntity = mapper.Map<Product>(productDto);
            await productRepository.CreateAsync(productEntity);
        }

        public async Task Update(ProductDto productDto)
        {
            var productEntity = mapper.Map<Product>(productDto);
            await productRepository.UpdateAsync(productEntity);
        }

        public async Task Remove(int? id)
        {
            var productEntity = await productRepository.GetByIdAsync(id);
            await productRepository.DeleteAsync(productEntity);
        }
    }
}