using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace VehicleCmsCommon.Models
{
    public class Vehicle
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [StringLength(70,MinimumLength = 2, ErrorMessage = "Manufacter cannot be less than 2 or longer than 70 characters.")]
        [Display(Name = "Manufacturer")]
        public string Manufacturer { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [StringLength(70, ErrorMessage = "Model cannot be less than 2 longer than 70 characters.")]
        [Display(Name = "Model")]
        public string Model { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [StringLength(40, ErrorMessage = "Color cannot be less than 2 longer than 40 characters.")]
        [Display(Name = "Color")]
        public string Color { get; set; }
        [RegularExpression(@"[A-Z0-9]*$", ErrorMessage = "Input a valid VIN")]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "A correct VIN is 17 characters long")]
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "VIN")]
        public string Vin { get; set; }
        [RegularExpression(@"^[ABEZHIKMNOPTYX]{3}[\s-][0-9]{4}$", ErrorMessage = "Input a valid license plate")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "A correct license plate has 3 capital letters a dash and then 4 numbers")]
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "License Plate")]
        public string LicensePlate { get; set; }

        public string FullInfo
        {
            get
            {
                return Manufacturer + ", " + Model;
            }
        }
        public ICollection<VehicleDetail> VehicleDetails { get; set; }
    }
}
