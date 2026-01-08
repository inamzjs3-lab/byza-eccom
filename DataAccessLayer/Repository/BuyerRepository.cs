using DataAccessLayer.byzaDbContext;
using DataAccessLayer.Contracts;
using EntityLayer;

namespace DataAccessLayer.Repository
{
    public class BuyerRepository : DataRepository<Buyer>, IBuyerRepository
    {
        public BuyerRepository(ByzadbContext context) : base(context)
        {
        }

        public async Task<int> RegisterBuyerAsync(Buyer entity)
        {

            var buyerId = await AddAsync(entity);
            return buyerId;
        }
    }
}
