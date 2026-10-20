using System;

namespace OOP_Arkhitectura_LAB
{
    public abstract class Vehicle
    {
        public string Model { get; private set; }
        public int Power { get; private set; }

        protected Vehicle(string model, int power)
        {
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentException("Модель не может быть пустой");
            }
            if (power < 0)
            {
                throw new ArgumentException("Мощность должна быть положительной");
            }

            Model = model;
            Power = power;
        }
        public virtual string GetInfo()
        {
            return $"Модель: {Model}, Мощность: {Power} л.с.";
        }
        public abstract double CalculateTax();
    }
}
