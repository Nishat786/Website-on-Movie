using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Assignment2_Bagga_Nishat.Pages
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _db;

        public EditModel(AppDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Member Members { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Members = await _db.Members.FindAsync(id);
            if (Members == null)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _db.Attach(Members).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new Exception($"Member {Members.Id} not found", e);
            }
            return RedirectToPage("./Index");
        }
    }
}