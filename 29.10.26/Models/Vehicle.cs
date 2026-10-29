using System;
using CorpFleet.Interfaces;

namespace _29._10._26
{
    public abstract class Vehicle : IStorable, IExportable, ICloneable
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Mileage { get; set; }

        protected Vehicle()
        {
            Brand = "";
            Model = "";
        }

        public abstract string GetVehicleType();

        public virtual string GetInfo()
        {
            return $"{Brand} {Model}, {Year}, пробег: {Mileage}";
        }

        public string ToStorageString()
        {
            return $"{Id}|{Brand}|{Model}|{Year}|{Mileage}";
        }

        public string Export()
        {
            return GetInfo();
        }

        public virtual object Clone()
        {
            return MemberwiseClone();
        }
    }
}
