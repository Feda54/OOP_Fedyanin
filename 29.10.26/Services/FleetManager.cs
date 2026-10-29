using System;
using System.Collections.Generic;
using System.Linq;
using CorpFleet.Models;

namespace _29._10._26
{
    public class FleetManager
    {
        private readonly List<Vehicle> vehicles =
            new List<Vehicle>();

        public event EventHandler<VehicleEventsArgs> StatusChanged;

        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
            StatusChanged?.Invoke(
                this,
                new VehicleEventsArgs(vehicle,
                    "Добавлен транспорт: " + vehicle.GetInfo()));
        }

        public bool RemoveVehicle(int id)
        {
            Vehicle vehicle = vehicles.FirstOrDefault(v => v.Id == id);

            if (vehicle == null)
                return false;

            vehicles.Remove(vehicle);

            StatusChanged?.Invoke(
                this,
                new VehicleEventsArgs(vehicle,
                    "Удалён транспорт: " + vehicle.GetInfo()));

            return true;
        }

        public List<Vehicle> GetAll()
        {
            return vehicles.ToList();
        }

        public List<Vehicle> FindByBrand(string brand)
        {
            return vehicles
                .Where(v => v.Brand.IndexOf(
                    brand, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        public decimal GetAverageMileage()
        {
            return vehicles.Count == 0
                ? 0
                : vehicles.Average(v => v.Mileage);
        }
    }
}
