using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        public async Task<ProductDto> GetById(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);
            if (productByIdQuery is null) throw new Exception("Entity could not be load");

            var result = await mediator.Send(productByIdQuery);
            return mapper.Map<ProductDto>(result);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();
            if (productsQuery is null) throw new Exception("Entity could not be load");

            var result = await mediator.Send(productsQuery);
            return mapper.Map<IEnumerable<ProductDto>>(result);
        }

        public async Task Add(ProductDto productDto)
        {
            var productCreateCommand = mapper.Map<ProductCreateCommand>(productDto);
            await mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDto productDto)
        {
            var productUpdateCommand = mapper.Map<ProductUpdateCommand>(productDto);
            await mediator.Send(productUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);
            if (productRemoveCommand is null) throw new Exception("Entity could not be load");

            await mediator.Send(productRemoveCommand);
        }
    }
}