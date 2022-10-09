using MediatR;

namespace CleanArchMvc.Application.Products.Commands
{
    public class ProductRemoveCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public ProductRemoveCommand(int id)
        {
            Id = id;
        }
    }
}