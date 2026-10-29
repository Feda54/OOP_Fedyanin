using System;
using CorpFleet.Models;

namespace _29._10._26
{
    public class VehicleEventsArgs : EventArgs
    {
        public Vehicle Vehicle { get; }
        public string Message { get; }

        public VehicleEventsArgs(Vehicle vehicle, string message)
        {
            Vehicle = vehicle;
            Message = message;
        }
    }
}
