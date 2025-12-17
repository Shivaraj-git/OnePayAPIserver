using System.ComponentModel.DataAnnotations;

namespace OnePayAPI.Models.DTOs
{
    public class MerchantBankAccountDTO
    {
        [Required]
        public int MerchantId { get; set; }
        [Required]
        public string AccountHolderName { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public string Ifsccode { get; set; }
        [Required]
        public string BankName { get; set; }
        
    }
}
