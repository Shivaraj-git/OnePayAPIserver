namespace OnePayAPI.Models.DTOs
{
    public class BankAccountDTO
    {
        public string? AccountHolderName { get; set; }

        public string? BankName { get; set; }

        public bool? IsVerified { get; set; }
    }
}
