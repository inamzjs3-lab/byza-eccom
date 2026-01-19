using ServiceLayer.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public interface ISellerService
    {
        Task<bool> SignupSeller(SignupRequestServiceModel model);
    }
}
