using System;
using System.Collections.Generic;

namespace Nhom1_Giay.Models;

public partial class CartItem
{
    public int CartItemId { get; set; }

    public int CartId { get; set; }

    public int ShoeId { get; set; }

    public int Quantity { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual Shoe Shoe { get; set; } = null!;
}
