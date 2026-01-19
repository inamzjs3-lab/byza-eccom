using DataAccessLayer.byzaDbContext;
using DataAccessLayer.Contracts;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class SellerRepository : DataRepository<Seller>, ISellerRepository
    {

        public SellerRepository(ByzadbContext context) : base(context)
        {
        }
        public async Task<int> RegisterSellerAsync(Seller entity)
        {
            var sellerId=await AddAsync(entity);
            return sellerId;
        }
    }
}

