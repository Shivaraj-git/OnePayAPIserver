using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnePayAPI.Models;

public partial class MerchantBankAccount
{
    [Key]
    public int BankId { get; set; }

    public int MerchantId { get; set; }

    public string? AccountHolderName { get; set; }

    public string? AccountNumber { get; set; }

    public string? Ifsccode { get; set; }

    public string? BankName { get; set; }

    public bool? IsVerified { get; set; }

    public virtual Merchant Merchant { get; set; } = null!;
}
