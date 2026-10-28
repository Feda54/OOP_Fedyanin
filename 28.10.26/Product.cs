using System;

namespace _28._10._26
{
    public sealed class Product : IEquatable<Product>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int CategoryId { get; private set; }
        public double Price { get; private set; }
        public int Stock { get; private set; }

        public Product(int id, string name, int categoryId,
            double price, int stock)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
            Price = price;
            Stock = stock;
        }

        public bool Equals(Product other)
        {
            return other != null && Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            Product other = obj as Product;
            return Equals(other);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
