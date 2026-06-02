using System;

namespace projjjjj
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string Plate { get; set; }
        public string VehicleType { get; set; }
        public string Brand { get; set; }
        public decimal DailyRate { get; set; }
        public bool IsAvailable { get; set; }

        public Vehicle() { }

        public Vehicle(int vehicleId, string plate, string vehicleType,
                       string brand, decimal dailyRate, bool isAvailable)
        {
            VehicleID = vehicleId;
            Plate = plate;
            VehicleType = vehicleType;
            Brand = brand;
            DailyRate = dailyRate;
            IsAvailable = isAvailable;
        }

        // Human-readable availability label used in the grid / display
        public string AvailabilityStatus => IsAvailable ? "Available" : "Rented Out";

        public override string ToString()
        {
            return $"[{VehicleID}] {Brand} {VehicleType} | Plate: {Plate} | " +
                   $"${DailyRate:F2}/day | {AvailabilityStatus}";
        }
    }
}
