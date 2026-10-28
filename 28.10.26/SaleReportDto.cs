namespace _28._10._26
{
    public sealed class SaleReportDto
    {
        public int SaleId { get; set; }
        public string CustomerName { get; set; } = "";
        public string ProductName { get; set; } = "";
        public string CategoryName { get; set; } = "";
        public double DiscountedUnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Channel { get; set; } = "";
        public string SaleDate { get; set; } = "";
        public double TotalAmount { get; set; }
    }
}
