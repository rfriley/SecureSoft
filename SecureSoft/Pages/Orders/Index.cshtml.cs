using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Assignment4.Models;
using SecureSoft.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

namespace SecureSoft.Pages.Orders
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly SecureSoft.Data.ApplicationDbContext _context;
        public SelectList Options { get; set; }

        public IndexModel(SecureSoft.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync(int? employeeID)
        {
            if (_context.Order != null)
            {
                var employees = from n in _context.Employee
                                orderby n.FirstName
                                select new { Name = n.FirstName + " " + n.LastName, n.EmployeeId };

                Options = new SelectList(employees, nameof(Employee.EmployeeId), "Name");

                if (employeeID is null)
                {
                    Order = await _context.Order
                        .Include(o => o.ShipViaNavigation)
                    .Include(o => o.Employee).ToListAsync();
                }
                else
                {
                    Order = await _context.Order
                    .Where(o => o.EmployeeId == employeeID)
                    .Include(o => o.Employee).ToListAsync();
                }
            }
        }

    }
}
