using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VehicleCmsCommon.Data;
using VehicleCmsCommon.Models;

namespace VehicleCmsCommon.Pages.Vehicles
{
    public class CreateModel : PageModel
    {
        private readonly VehicleCmsCommon.Data.CommonContext _context;

        public CreateModel(VehicleCmsCommon.Data.CommonContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Vehicle Vehicle { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyVehicle = new Vehicle();

            if (await TryUpdateModelAsync<Vehicle>(
                emptyVehicle,
                "vehicle",   // Prefix for form value.
                s => s.Manufacturer, s => s.Model, s => s.Color, s => s.Vin, s => s.LicensePlate))
            {
                _context.Vehicles.Add(emptyVehicle);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
