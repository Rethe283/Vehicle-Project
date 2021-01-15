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
    public class IndexModel : PageModel
    {
        private readonly CommonContext _context;

        public IndexModel(CommonContext context)
        {
            _context = context;
        }
        //sort by different ways:
        public string ManufacturerSort { get; set; }
        public string ModelSort { get; set; }
        public string ColorSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Vehicle> Vehicles { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            ManufacturerSort = String.IsNullOrEmpty(sortOrder) ? "Manufacturer_desc" : "";
            ModelSort = sortOrder == "Model" ? "model_desc" : "Model";
            ColorSort = sortOrder == "Color" ? "color_desc" : "Color";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Vehicle> vehiclesIQ = from s in _context.Vehicles
                                             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                vehiclesIQ = vehiclesIQ.Where(s => s.Manufacturer.Contains(searchString)
                                             || s.Model.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Manufacturer_desc":
                    vehiclesIQ = vehiclesIQ.OrderByDescending(s => s.Manufacturer);
                    break;
                case "Model":
                    vehiclesIQ = vehiclesIQ.OrderBy(s => s.Model);
                    break;
                case "model_desc":
                    vehiclesIQ = vehiclesIQ.OrderByDescending(s => s.Model);
                    break;
                case "Color":
                    vehiclesIQ = vehiclesIQ.OrderBy(s => s.Color);
                    break;
                case "color_desc":
                    vehiclesIQ = vehiclesIQ.OrderByDescending(s => s.Color);
                    break;
                default:
                    vehiclesIQ = vehiclesIQ.OrderBy(s => s.Manufacturer);
                    break;
            }
            int pageSize = 5;
            Vehicles = await PaginatedList<Vehicle>.CreateAsync(
                vehiclesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
