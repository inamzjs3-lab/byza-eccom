using ServiceLayer.ServiceModels;

namespace ServiceLayer.Contracts
{
    public interface IBuyerService
    {
        Task<bool> SignupBuyer(SignupRequestServiceModel model);
    }
}
