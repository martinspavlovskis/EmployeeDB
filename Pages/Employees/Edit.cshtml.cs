using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Data;
using Project.Models;

namespace Project.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Employee Employee { get; set; }
        public async Task OnGet(int id)
        {
            Employee = await _db.Employees.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var empFromDb = await _db.Employees.FindAsync(Employee.Id);
                empFromDb.FullName = Employee.FullName;
                empFromDb.Position = Employee.Position;
                empFromDb.Location = Employee.Location;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
