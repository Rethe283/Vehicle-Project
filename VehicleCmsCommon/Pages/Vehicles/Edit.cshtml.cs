using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleCmsCommon.Data;
using VehicleCmsCommon.Models;

namespace VehicleCmsCommon.Pages.Vehicles
{
    public class EditModel : PageModel
    {
        private readonly VehicleCmsCommon.Data.CommonContext _context;

        public EditModel(VehicleCmsCommon.Data.CommonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vehicle Vehicle { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vehicle = await _context.Vehicles.FindAsync(id);

            if (Vehicle == null)
            {
                return NotFound();
            }
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int id)
        {
            var vehicleToUpdate = await _context.Vehicles.FindAsync(id);

            if (vehicleToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Vehicle>(
                vehicleToUpdate,
                "vehicle",
                s => s.Manufacturer, s => s.Model, s => s.Color, s => s.Vin, s => s.LicensePlate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.ID == id);
        }
    }
}
