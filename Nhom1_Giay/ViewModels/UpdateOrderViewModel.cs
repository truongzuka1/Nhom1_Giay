namespace Nhom1_Giay.ViewModels
{
    public class UpdateOrderViewModel
    {
        public int OrderId { get; set; }
        public string Status { get; set; }  // "Pending", "Shipped", "Delivered", "Cancelled"
    }
}
