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

namespace SecureSoft.Pages.Orders
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly SecureSoft.Data.ApplicationDbContext _context;

        public IndexModel(SecureSoft.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Order = await _context.Order
                .Include(o => o.Employee)
                .Include(o => o.ShipViaNavigation).ToListAsync();
        }
    }
}
