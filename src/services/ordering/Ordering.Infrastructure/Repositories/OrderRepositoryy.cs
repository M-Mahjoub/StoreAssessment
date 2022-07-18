using Ordering.Application.Contracts.Persistance;
using Ordering.Domain.Entities;
using Ordering.Infrastructure.Persistence;
using Ordering.Infrastructure.Repositories;

namespace Store.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await GetAsync(c => c.UserName == userName);
            //var orderList = await _dbContext.Orders
            //    .Where(c => c.UserName == userName)
            //    .ToListAsync();

            return orderList;
        }
    }
}
