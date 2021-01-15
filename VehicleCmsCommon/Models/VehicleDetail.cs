using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleCmsCommon.Models
{
    public class VehicleDetail
    {
        public int ID { get; set; }
        public int VehicleID { get; set; }
        public string MaxSpeed { get; set; }
        public string Doors { get; set; }
        public string Wheels { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
