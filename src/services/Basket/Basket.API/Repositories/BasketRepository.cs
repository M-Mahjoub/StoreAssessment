using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _distributedCache;

        public BasketRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache ?? throw new ArgumentNullException(nameof(distributedCache));
        }

        public async Task DeleteBasket(string key)
        {
            await _distributedCache.RemoveAsync(key);
        }

        public async Task<ShoppingCart> GetBasket(string key)
        {
            var basket = await _distributedCache.GetStringAsync(key);
            if (string.IsNullOrEmpty(basket))
                return null;

            var result = JsonConvert.DeserializeObject<ShoppingCart>(basket);
            return result;
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            await _distributedCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));

            return await GetBasket(basket.UserName);
        }
    }
}
