using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Nhom1_Giay.Models
{
    public class User : IdentityUser
    {
        public string Role { get; set; } = null!;

        public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public virtual ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();
    }
}
