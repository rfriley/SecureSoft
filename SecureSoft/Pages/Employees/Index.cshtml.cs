using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment4.Models;
using SecureSoft.Data;

namespace SecureSoft.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly SecureSoft.Data.ApplicationDbContext _context;

        public IndexModel(SecureSoft.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Employee = await _context.Employee
                .Include(e => e.ReportsToNavigation).ToListAsync();
        }
    }
}
