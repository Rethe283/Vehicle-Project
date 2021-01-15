using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleCmsCommon.Data;
using VehicleCmsCommon.Models;

namespace VehicleCmsCommon.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CommonContext context)
        {
           // context.Database.EnsureCreated();

            // Look for any Vehicles.
            if (context.Vehicles.Any())
            {
                return;   // DB has been seeded
            }

            var vehicles = new Vehicle[]
            {
                new Vehicle{Manufacturer="Peugeot", Model="208", Color="Blue", Vin="AAAAAAAAAAAAAAAAA", LicensePlate="ABE-2020"},
                new Vehicle{Manufacturer="Peugeot", Model="SUV 2008", Color="Black", Vin="AAAAAAAAAAAAAAAAA", LicensePlate="ABE-2020"},
                new Vehicle{Manufacturer="Peugeot", Model="TRAVELLER", Color="Red", Vin="AAAAAAAAAAAAAAAAA", LicensePlate="ABE-2020"},
                new Vehicle{Manufacturer="Honda", Model="Civic Type-R", Color="Blue-White Stripes", Vin="AAAAAAAAAAAAAAAAA", LicensePlate="ABE-2020"},
                new Vehicle{Manufacturer="Honda", Model="Civic 5D", Color="Orange", Vin="AAAAAAAAAAAAAAAAA", LicensePlate="ABE-2020"},
                new Vehicle{Manufacturer="Honda", Model="JAZZ CROSSTAR", Color="Yellow", Vin="AAAAAAAAAAAAAAAAA", LicensePlate="ABE-2020"},
                new Vehicle{Manufacturer="Honda", Model="JAZZ HYBRID", Color="White", Vin="AAAAAAAAAAAAAAAAA", LicensePlate="ABE-2020"},
                new Vehicle{Manufacturer="Honda", Model="HR-V", Color="Silver", Vin="AAAAAAAAAAAAAAAAA", LicensePlate="ABE-2020"}
            };

            context.Vehicles.AddRange(vehicles);
            context.SaveChanges();

            var vehicledetails = new VehicleDetail[]
            {
                new VehicleDetail {VehicleID=1, MaxSpeed = "180", Doors = "3", Wheels = "4" },
                new VehicleDetail {VehicleID=2, MaxSpeed = "165", Doors = "3", Wheels = "4" },
                new VehicleDetail {VehicleID=3, MaxSpeed = "150", Doors = "5", Wheels = "4" },
                new VehicleDetail {VehicleID=4, MaxSpeed = "230", Doors = "5", Wheels = "4" },
                new VehicleDetail {VehicleID=5, MaxSpeed = "190", Doors = "5", Wheels = "4" },
                new VehicleDetail {VehicleID=6, MaxSpeed = "175", Doors = "7", Wheels = "6" },
                new VehicleDetail {VehicleID=7, MaxSpeed = "180", Doors = "5", Wheels = "4" },
                new VehicleDetail {VehicleID=8, MaxSpeed = "200", Doors = "5", Wheels = "4" }
            };

            context.VehicleDetails.AddRange(vehicledetails);
            context.SaveChanges();
        }
    }
}