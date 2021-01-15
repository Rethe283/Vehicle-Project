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

namespace VehicleCmsCommon.Pages.VehicleDetails
{
    public class EditModel : PageModel
    {
        private readonly VehicleCmsCommon.Data.CommonContext _context;

        public EditModel(VehicleCmsCommon.Data.CommonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VehicleDetail VehicleDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VehicleDetail = await _context.VehicleDetails
                .Include(v => v.Vehicle).FirstOrDefaultAsync(m => m.ID == id);

            if (VehicleDetail == null)
            {
                return NotFound();
            }
           ViewData["VehicleID"] = new SelectList(_context.Vehicles, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(VehicleDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleDetailExists(VehicleDetail.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VehicleDetailExists(int id)
        {
            return _context.VehicleDetails.Any(e => e.ID == id);
        }
    }
}
