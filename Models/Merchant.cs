using System;
using System.Collections.Generic;

namespace OnePayAPI.Models;

public partial class Merchant
{
    public int MerchantId { get; set; }

    public string FullName { get; set; } = null!;

    public string? BusinessName { get; set; }

    public string? Email { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string? PasswordHash { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<MerchantBankAccount> MerchantBankAccounts { get; set; } = new List<MerchantBankAccount>();
}
