﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EFCRUDTest.Models;

namespace EFCRUDTest.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly EFCRUDTest.Models.StuffContext _context;

        public CreateModel(EFCRUDTest.Models.StuffContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyUser = new User();

            if (await TryUpdateModelAsync<User>(
                emptyUser,
                "user",   // Prefix for form value.
                u => u.FirstName, u => u.LastName, u => u.Email))
            {
                _context.User.Add(emptyUser);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return null;
        }
    }
}