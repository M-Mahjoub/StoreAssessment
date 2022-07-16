using Dapper;
using Discount.Grpc.Entities;
using Npgsql;

namespace Discount.Grpc.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var created = await connection.ExecuteAsync
                         ("Insert into coupon (productName,amount,description) values(@ProductName,@Amount,@Description)",
                         new { coupon.ProductName, coupon.Amount, coupon.Description });

            if (created == 0)
                return false;

            return true;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var deleted = await connection.ExecuteAsync
                         ("Delete from coupon where productName=@ProductName",
                         new { ProductName = productName });

            if (deleted == 0)
                return false;

            return true;
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
                         ("Select * From Coupon Where ProductName=@ProductName", new { ProductName = productName });

            if (coupon == null)
            {
                return new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Desc" };
            }

            return coupon;
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var updated = await connection.ExecuteAsync
                         ("Update Coupon set ProductName=@ProductName,Amount=@Amount,Description=@Description where id=@Id",
                         new { coupon.Id, coupon.ProductName, coupon.Amount, coupon.Description });

            if (updated == 0)
                return false;

            return true;
        }
    }
}
