namespace API.Models
{
    public class BillModel
    {
        public int? BillID { get; set; }
        public string BillNumber { get; set; }
        public DateTime BillDate { get; set; }
        public int OrderID { get; set; }
        public double TotalAmount { get; set; }
        public double Discount { get; set; }
        public double NetAmount { get; set; }
        public int UserID { get; set; }
    }
    public class User_DropDown
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
    }
    public class Order_DropDown
    {
        public int OrderID { get; set; }
    }
}
