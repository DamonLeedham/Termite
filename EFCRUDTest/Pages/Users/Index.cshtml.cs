using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EFCRUDTest.Models;

namespace EFCRUDTest
{
    public class IndexModel : PageModel
    {
        private readonly EFCRUDTest.Models.StuffContext _context;

        public IndexModel(EFCRUDTest.Models.StuffContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; }

        public async Task OnGetAsync()
        {
            User = await _context.User.ToListAsync();
        }
    }
}
