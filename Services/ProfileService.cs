using Microsoft.IdentityModel.Tokens;
using OnePayAPI.IServices;
using OnePayAPI.Models;
using OnePayAPI.Models.DTOs;
using System.Runtime.ConstrainedExecution;

namespace OnePayAPI.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ShivaDbContext _context;
        public ProfileService(ShivaDbContext context) {
            _context = context;
        }
        public MerchantDTO GetProfileDetails(int id)
        {
            var merch = _context.Merchants.Find(id);
            if (merch == null) return null;

            var merchDTO = new MerchantDTO() { };
            merchDTO.FullName= merch.FullName;
            merchDTO.BusinessName= merch.BusinessName;
            merchDTO.PhoneNumber= merch.PhoneNumber;
            merchDTO.Email= merch.Email;

            return merchDTO;
        }
    }
}
