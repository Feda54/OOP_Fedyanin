namespace _28._10._26
{
    public sealed class Sale
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public string CustomerName { get; private set; }
        public int Quantity { get; private set; }
        public string SaleDate { get; private set; }
        public string Channel { get; private set; }

        public Sale(int id, int productId, string customerName,
            int quantity, string saleDate, string channel)
        {
            Id = id;
            ProductId = productId;
            CustomerName = customerName;
            Quantity = quantity;
            SaleDate = saleDate;
            Channel = channel;
        }
    }
}
