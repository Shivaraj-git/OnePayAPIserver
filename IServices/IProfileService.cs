using OnePayAPI.Models;
using OnePayAPI.Models.DTOs;

namespace OnePayAPI.IServices
{
    public interface IProfileService
    {
        public MerchantDTO GetProfileDetails(int id);
    }
}
