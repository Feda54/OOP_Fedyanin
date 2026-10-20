namespace OOP_Arkhitectura_LAB
{
    class Car : Vehicle
    {
        public bool IsElectric { get; private set; }
        public Car(string model, int power, bool isElectric) : base(model, power)
        {
            IsElectric = isElectric;
        }
        public override string GetInfo()
        {
            return $"{base.GetInfo()}, Легковой, " + $"Электромобиль: {(IsElectric ? "Да" : "Нет")}";
        }
        public override double CalculateTax()
        {
            if (IsElectric)
            {
                return Power * 0.5;
            }
            else
            {
                return Power * 12.0;
            }
        }
    }
}
