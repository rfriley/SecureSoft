using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment4.Models;
using SecureSoft.Data;
using Microsoft.AspNetCore.Authorization;

namespace SecureSoft.Pages.Employees
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        public SelectList ReportsToList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            var employee = await _context.Employee
                .FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (employee == null)
                return NotFound();

            Employee = employee;

            await LoadReportsToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadReportsToListAsync();
                return Page();
            }

            // Do not let the user select themselves as their own manager
            if (Employee.ReportsTo == Employee.EmployeeId)
            {
                ModelState.AddModelError("Employee.ReportsTo", "An employee cannot report to themselves.");
                await LoadReportsToListAsync();
                return Page();
            }

            _context.Attach(Employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(Employee.EmployeeId))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToPage("./Index");
        }

        private async Task LoadReportsToListAsync()
        {
            var employees = await _context.Employee
                .Where(e => e.EmployeeId != Employee.EmployeeId) // prevent self-selection
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    e.EmployeeId,
                    FullName = e.FirstName + " " + e.LastName
                })
                .ToListAsync();

            ReportsToList = new SelectList(employees, "EmployeeId", "FullName", Employee.ReportsTo);
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeId == id);
        }
    }
}
