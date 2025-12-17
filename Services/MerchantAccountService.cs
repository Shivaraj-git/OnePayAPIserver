using OnePayAPI.IServices;
using OnePayAPI.Models;

namespace OnePayAPI.Services
{
    public class MerchantAccountService: IMerchantAccountService
    {
        private readonly ShivaDbContext _context;

        public MerchantAccountService(ShivaDbContext context)
        {
            _context = context;
        }

        public MerchantBankAccount AddAccountDetails(int MerchantId, string AccountHolderName, string AccountNumber, string Ifsccode, string BankName)
        {
            var merchBankAccount= new MerchantBankAccount();
            merchBankAccount.MerchantId = MerchantId;
            merchBankAccount.AccountHolderName = AccountHolderName;
            merchBankAccount.AccountNumber = AccountNumber;
            merchBankAccount.Ifsccode = Ifsccode;
            merchBankAccount.BankName = BankName;

            var merchant = _context.Merchants.Find(MerchantId);
            if (merchant == null) return null;
            merchBankAccount.Merchant = merchant;

            _context.MerchantBankAccounts.Add(merchBankAccount);
            _context.SaveChanges();
            return merchBankAccount;
        }
    }
}
