using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EFCRUDTest.Models;

namespace EFCRUDTest.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly EFCRUDTest.Models.StuffContext _context;

        public DeleteModel(EFCRUDTest.Models.StuffContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.User
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (User == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                            .AsNoTracking()
                            .FirstOrDefaultAsync(m => m.ID == id);

            if (user == null)
            {
                return NotFound();
            }

            try
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}
