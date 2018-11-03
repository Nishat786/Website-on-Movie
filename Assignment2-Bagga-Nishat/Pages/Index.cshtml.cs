using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Assignment2_Bagga_Nishat.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }
        public IList<Member> Members { get; private set; }
        [TempData]

        public string Message { get; set; }

        public async Task OnGetAsync()
        {
            Members = await _db.Members.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var Member = await _db.Members.FindAsync(id);
            if(Member != null)
            {
                _db.Members.Remove(Member);
                Message = $"Member added!";
                await _db.SaveChangesAsync();
            }
            return RedirectToPage();
        }

    }
}
