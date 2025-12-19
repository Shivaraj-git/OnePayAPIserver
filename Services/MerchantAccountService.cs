using Microsoft.EntityFrameworkCore;
using OnePayAPI.IServices;
using OnePayAPI.Models;
using OnePayAPI.Models.DTOs;

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

        public List<BankAccountDTO> GetBankAcountDTOs(int id)
        {
            List<BankAccountDTO> accounts= new List<BankAccountDTO>();
            foreach (var item in _context.MerchantBankAccounts)
            {
                if (item.MerchantId == id)
                {
                    accounts.Add(new BankAccountDTO
                    {
                        AccountHolderName = item.AccountHolderName,
                        BankName = item.BankName,
                        IsVerified = item.IsVerified
                    });
                }
            }
            return accounts;
        }
    }
}
