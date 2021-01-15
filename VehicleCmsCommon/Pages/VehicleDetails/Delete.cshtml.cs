using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VehicleCmsCommon.Data;
using VehicleCmsCommon.Models;

namespace VehicleCmsCommon.Pages.VehicleDetails
{
    public class DeleteModel : PageModel
    {
        private readonly VehicleCmsCommon.Data.CommonContext _context;

        public DeleteModel(VehicleCmsCommon.Data.CommonContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VehicleDetail = await _context.VehicleDetails.FindAsync(id);

            if (VehicleDetail != null)
            {
                _context.VehicleDetails.Remove(VehicleDetail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
