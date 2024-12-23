﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookingSampleApp_V1.DataAccess;
using BookingSampleApp_V1.Models;
using BookingSampleApp_V1.Interfaces;

namespace BookingSampleApp_V1.Pages.Booking
{
    public class CreateModel : PageModel
    {
        private readonly IBook iBookRepo;
        public CreateModel(IBook bookRepos)
        {
            iBookRepo = bookRepos;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await iBookRepo.Add(Book);
            return RedirectToPage("./Index");
        }
    }
}
