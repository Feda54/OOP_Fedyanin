namespace _28._10._26
{
    public sealed class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double DiscountRate { get; private set; }

        public Category(int id, string name, double discountRate)
        {
            Id = id;
            Name = name;
            DiscountRate = discountRate;
        }
    }
}
