using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Assignment2_Bagga_Nishat.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _db;
        private ILogger<CreateModel> Log;

        public CreateModel(AppDbContext db,ILogger<CreateModel> log)
        {
            _db = db;
            Log = log;
        }

        public string Message { get; set; }

        [BindProperty]
        public Member Members { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _db.Members.Add(Members);
            await _db.SaveChangesAsync();
            var Msg = $"Member added!";
            Message = Msg;
            Log.LogInformation(Msg);
            return RedirectToPage("/Index");
        }
    }
}