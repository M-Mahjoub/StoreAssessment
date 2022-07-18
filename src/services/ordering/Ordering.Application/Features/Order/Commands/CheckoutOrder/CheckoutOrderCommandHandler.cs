using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistance;
using Ordering.Application.Models;
using Store.Application.Contracts.Infrastructure;

namespace Ordering.Application.Features.Order.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CheckoutOrderCommandHandler> _logger;

        public CheckoutOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IEmailService emailService, ILogger<CheckoutOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Guid> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Ordering.Domain.Entities.Order>(request);

            var newOrder = await _orderRepository.AddAsync(orderEntity);

            _logger.LogInformation($"Order {newOrder.Id} is successfully created.");

            await SendEmail(newOrder);

            return newOrder.Id;
        }

        private async Task SendEmail(Domain.Entities.Order newOrder)
        {
            var email = new Email { To = "m.mahjoub@gmail.com", Body = "Order was created", Subject = "CreateOrder" };
            try
            {
                await _emailService.SendEmail(email);

            }
            catch (Exception ex)
            {

                _logger.LogError($"Order {newOrder.Id} failed: {ex.Message}");

            }
        }
    }
}
