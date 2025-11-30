using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment4.Models;
using SecureSoft.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace SecureSoft.Pages.Employees
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        public SelectList ReportsToList { get; set; } = default!;

        // GET
        public async Task<IActionResult> OnGetAsync()
        {
            await LoadReportsToListAsync();
            return Page();
        }

        // POST
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadReportsToListAsync(); // must rebuild dropdown on validation failure
                return Page();
            }

            _context.Employee.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private async Task LoadReportsToListAsync()
        {
            var employees = await _context.Employee
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    e.EmployeeId,
                    FullName = e.FirstName + " " + e.LastName
                })
                .ToListAsync();

            ReportsToList = new SelectList(employees, "EmployeeId", "FullName");
        }
    }
}
