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

namespace SecureSoft.Pages.Orders
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
        ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId");
        ViewData["ShipVia"] = new SelectList(_context.Set<Shipper>(), "ShipperId", "ShipperId");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
