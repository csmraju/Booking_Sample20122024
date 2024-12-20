using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookingSampleApp_V1.DataAccess;
using BookingSampleApp_V1.Models;

namespace BookingSampleApp_V1.Pages.Booking
{
    public class IndexModel : PageModel
    {
        private readonly BookingSampleApp_V1.DataAccess.BookingDbContext _context;

        public IndexModel(BookingSampleApp_V1.DataAccess.BookingDbContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _context.Book.ToListAsync();
        }
    }
}
