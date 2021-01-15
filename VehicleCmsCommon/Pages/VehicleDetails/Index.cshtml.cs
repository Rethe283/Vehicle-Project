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
    public class IndexModel : PageModel
    {
        private readonly VehicleCmsCommon.Data.CommonContext _context;

        public IndexModel(VehicleCmsCommon.Data.CommonContext context)
        {
            _context = context;
        }

        public IList<VehicleDetail> VehicleDetails { get;set; }

        public async Task OnGetAsync()
        {
            VehicleDetails = await _context.VehicleDetails
                .Include(c => c.Vehicle)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
