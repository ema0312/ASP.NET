using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectionTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConnectionTest.Pages.ConnectionsPages
{
    public class CreateModel : PageModel
    {
        private ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [TempData]
        public string afterAddMessage { get; set; }
        [BindProperty]
        public Connections Connection { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
         }
            else
       {
                _db.ConnectionsItems.Add(Connection);
                await _db.SaveChangesAsync();
                afterAddMessage = "New Connection made!";
                return RedirectToPage("Index");
            }
        }
    }
}