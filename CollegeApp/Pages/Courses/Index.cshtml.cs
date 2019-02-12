using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CollegeApp.Models;

namespace CollegeApp.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly CollegeApp.Models.SchoolContext _context;

        public IndexModel(CollegeApp.Models.SchoolContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; }

        public async Task OnGetAsync()
        {
            Course = await _context.Course
                .Include(c => c.Department).ToListAsync();
        }
    }
}
