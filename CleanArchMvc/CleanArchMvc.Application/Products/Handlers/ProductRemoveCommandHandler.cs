using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand>
    {
        private readonly IProductRepository productRepository;

        public ProductRemoveCommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Unit> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);

            if (product is null) throw new ApplicationException("Entity could not be found");

            await productRepository.DeleteAsync(product);

            return Unit.Value;
        }
    }
}