using OnePayAPI.IServices;
using OnePayAPI.Models;

namespace OnePayAPI.Services
{
    public class SignLogServices : ISignLogServices
    {
        private readonly ShivaDbContext _context;

        public SignLogServices(ShivaDbContext context)
        {
            _context = context;
        }


        public Merchant SignUp(string fullName, string bussinessName, string email, string phoneNumber, string password)
        {
            if (
                _context.Merchants.Any(m => m.PhoneNumber == phoneNumber || m.Email == email && email != null))
                return null;

            var newMerchant = new Merchant
            {
                FullName = fullName,
                BusinessName = bussinessName,
                Email = email,
                PhoneNumber = phoneNumber,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            };

            _context.Merchants.Add(newMerchant);
            _context.SaveChanges();
            return newMerchant;
        }
            public Merchant Login(string loginInput, string password)
        {
            var merchant = _context.Merchants
                .FirstOrDefault(m => m.PhoneNumber == loginInput || (m.Email == loginInput));
            if(merchant == null)
            {
                return null;
            }
            bool verified = BCrypt.Net.BCrypt.Verify(password, merchant.PasswordHash);
            if (!verified)
            {
                return null;
            }
            return merchant;
        }
    }
}
