using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookingSampleApp_V1.DataAccess;
using BookingSampleApp_V1.Models;
using BookingSampleApp_V1.Interfaces;

namespace BookingSampleApp_V1.Pages.Booking
{
    public class EditModel : PageModel
    {
        private readonly IBook iBookRepo;
        public EditModel(IBook bookRepos)
        {
            iBookRepo = bookRepos;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Book = await iBookRepo.GetById(id);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await iBookRepo.Update(Book);

            return RedirectToPage("./Index");
        }
    }
}
