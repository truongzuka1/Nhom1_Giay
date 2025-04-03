using System;
using System.Collections.Generic;

namespace Nhom1_Giay.Models;

public partial class Voucher
{
    public int VoucherId { get; set; }

    public string Code { get; set; } = null!;

    public decimal DiscountAmount { get; set; }

    public DateTime ExpiryDate { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
