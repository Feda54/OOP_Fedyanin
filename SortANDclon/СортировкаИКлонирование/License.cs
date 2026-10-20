using System;

namespace СортировкаИКлонирование
{
    class License : ICloneable
    {
        public string Key { get; set; }
        public int DurationDays { get; set; }

        public License(string key, int DURATTION)
        {
            Key = key;
            DurationDays = DURATTION;
        }

        public void SetKey(string newKey) => Key = newKey;

        public override string ToString() => $"Ключ: {Key} ({DurationDays} дн.)";
    }
}
