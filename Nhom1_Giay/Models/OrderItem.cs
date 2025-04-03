using System;
using System.Collections.Generic;

namespace Nhom1_Giay.Models;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int ShoeId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Shoe Shoe { get; set; } = null!;
}
