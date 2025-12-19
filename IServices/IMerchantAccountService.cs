using OnePayAPI.Models;
using OnePayAPI.Models.DTOs;

namespace OnePayAPI.IServices
{
    public interface IMerchantAccountService
    {
        public MerchantBankAccount AddAccountDetails(int MerchantId, string AccountHolderName, string AccountNumber, string Ifsccode, string BankName);
        public List<BankAccountDTO> GetBankAcountDTOs(int id);
    }
}
