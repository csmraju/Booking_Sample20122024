﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookingSampleApp_V1.DataAccess;
using BookingSampleApp_V1.Models;
using BookingSampleApp_V1.Interfaces;

namespace BookingSampleApp_V1.Pages.Booking
{
    public class DeleteModel : PageModel
    {
        private readonly IBook iBookRepo;
        public DeleteModel(IBook bookRepos)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await iBookRepo.Delete(id);

            return RedirectToPage("./Index");
        }
    }
}
