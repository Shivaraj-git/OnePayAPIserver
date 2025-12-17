using OnePayAPI.Models;

namespace OnePayAPI.IServices
{
    public interface IMerchantAccountService
    {
        public MerchantBankAccount AddAccountDetails(int MerchantId, string AccountHolderName, string AccountNumber, string Ifsccode, string BankName);
    }
}
