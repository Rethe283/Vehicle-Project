using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VehicleCmsCommon.Data;
using VehicleCmsCommon.Models;

namespace VehicleCmsCommon.Pages.Vehicles
{
    public class DeleteModel : PageModel
    {
        private readonly VehicleCmsCommon.Data.CommonContext _context;

        public DeleteModel(VehicleCmsCommon.Data.CommonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vehicle Vehicle { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vehicle = await _context.Vehicles
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Vehicle == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }
            
            try
            {
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}
