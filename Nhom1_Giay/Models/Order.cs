﻿using System;
using System.Collections.Generic;

namespace Nhom1_Giay.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public DateTime OrderDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual User User { get; set; } = null!;
}
