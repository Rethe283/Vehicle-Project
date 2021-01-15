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
    public class DetailsModel : PageModel
    {
        private readonly VehicleCmsCommon.Data.CommonContext _context;

        public DetailsModel(VehicleCmsCommon.Data.CommonContext context)
        {
            _context = context;
        }

        public Vehicle Vehicle { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vehicle = await _context.Vehicles
                .Include(s => s.VehicleDetails)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Vehicle == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
