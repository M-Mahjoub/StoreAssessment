using MediatR;

namespace Ordering.Application.Features.Order.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
