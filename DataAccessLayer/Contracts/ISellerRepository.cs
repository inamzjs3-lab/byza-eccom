using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contracts
{
    public interface ISellerRepository:IDataRepository<Seller>
    {
        Task<int> RegisterSellerAsync(Seller entity);
    }
}
