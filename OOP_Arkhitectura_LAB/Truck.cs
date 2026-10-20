using System;
using System.IO;

namespace OOP_Arkhitectura_LAB
{
    class Truck : Vehicle, IStorable
    {
        public double LoadCapacity { get; private set; }
        public string FilePath { get; private set; } = " ";
        public Truck(string model, int power, double loadCapacity) : base(model, power)
        {
            if (loadCapacity <= 0)
            {
                throw new ArgumentException("Грузоподъемность должна быть положительной");
            }
            LoadCapacity = loadCapacity;
        }
        public override string GetInfo()
        {
            return $"{base.GetInfo()}, Грузовой, Грузоподъемность: {LoadCapacity} кг";
        }
        public override double CalculateTax()
        {
            return Power * 25.0;
        }
        public void Save(string filePath)
        {
            FilePath = filePath;
            // Логика сохранения данных о грузовике в файл

            string text = $"Модель: {Model}, Мощность: {Power} л.с., Грузоподъемность: {LoadCapacity} кг, Налог: {CalculateTax()}";
            File.WriteAllText(filePath, text);
            FilePath = Path.GetFullPath(filePath);
        }
    }
}
