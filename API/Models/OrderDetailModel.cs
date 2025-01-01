namespace API.Models
{
    public class OrderDetailModel
    {
        public int? OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public double TotalAmount { get; set; }
        public int UserID { get; set; }
    }
    public class Product_DropDown
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }
}
