using System;

namespace _20._10._26
{
    class OrderItem : IEquatable<OrderItem>
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = "";
        public string ProductName { get; set; } = "";
        public string Category { get; set; } = "";
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public decimal Total
        {
            get { return Price * Quantity; }
        }
        public bool Equals(OrderItem other)
        {
            if (other == null) return false;
            return string.Equals(ProductName, other.ProductName, StringComparison.OrdinalIgnoreCase);
        }
        public override bool Equals(object obj)
        {
            return obj is OrderItem other && Equals(other);
        }
        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(ProductName ?? "");
        }
    }
}
