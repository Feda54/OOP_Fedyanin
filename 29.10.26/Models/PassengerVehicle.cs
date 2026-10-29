namespace _29._10._26
{
    public class PassengerVehicle : Vehicle
    {
        public int PassengerCapacity { get; set; }

        public override string GetVehicleType()
        {
            return "Пассажирский";
        }

        public override string GetInfo()
        {
            return base.GetInfo() +
                   $", количество пассажиров: {PassengerCapacity}";
        }
    }
}
