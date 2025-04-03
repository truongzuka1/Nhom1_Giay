using System;
using System.Collections.Generic;

namespace Nhom1_Giay.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Shoe> Shoes { get; set; } = new List<Shoe>();
}
