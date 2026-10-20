using System;

namespace СортировкаИКлонирование
{
    class Software : ICloneable, IComparable
    {
        public string Title { get; set; }
        public string Version { get; set; }
        public decimal Price { get; set; }
        License SoftwareLicense = new License();
        public Software(string title, string version, decimal price, License license)
        {
            Title = title;
            Version = version;
            Price = price;
            SoftwareLicense = license;
        }
    }
}
