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

namespace SecureSoft.Pages.Employees
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly SecureSoft.Data.ApplicationDbContext _context;

        public CreateModel(SecureSoft.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ReportsTo"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId");
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employee.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
