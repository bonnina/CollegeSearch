using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CollegeApp.Models;

namespace CollegeApp.Pages.Departments
{
    public class DetailsModel : PageModel
    {
        private readonly CollegeApp.Models.SchoolContext _context;

        public DetailsModel(CollegeApp.Models.SchoolContext context)
        {
            _context = context;
        }

        public Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string query = "SELECT * FROM Department WHERE DepartmentID = {0}";
            Department = await _context.Departments
                .FromSql(query, id)
                .Include(d => d.Administrator)
                //  .FirstOrDefaultAsync(m => m.DepartmentID == id);
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (Department == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
