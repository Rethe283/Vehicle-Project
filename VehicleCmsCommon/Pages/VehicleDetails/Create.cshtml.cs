using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VehicleCmsCommon.Data;
using VehicleCmsCommon.Models;

namespace VehicleCmsCommon.Pages.VehicleDetails
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
        ViewData["VehicleID"] = new SelectList(_context.Vehicles, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public VehicleDetail VehicleDetail { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.VehicleDetails.Add(VehicleDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
