using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public EmployeesController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _db.Employees.ToListAsync();
            return Ok(list);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var BookFromDb = await _db.Employees.FirstOrDefaultAsync(u => u.Id == id);
            if (BookFromDb is null)
            {
                NotFound();
            }
            _db.Employees.Remove(BookFromDb);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
