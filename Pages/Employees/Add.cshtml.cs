using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Data;
using Project.Models;

namespace Project.Pages.Employees
{
    public class AddModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public AddModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Employee Employee { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Employees.AddAsync(Employee);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            } 
            else
            {
                return Page();
            }
        }
    }
}
