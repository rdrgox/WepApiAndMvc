// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCRUD.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ApiCRUD.Data;
    using ApiCRUD.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        //Get All Students
        [HttpGet]
        public List<Student> GetStudents()
        {
            return _context.students.ToList();
        }

        //Get one Student
        [HttpGet("{id}")]
        public Student GetStudent(int Id)
        {
            var student = _context.students.Where(a => a.Id == Id).SingleOrDefault();
            return student;
        }

        [HttpPost]
        public IActionResult PostStudent([FromBody]Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest("model no es valido");

            _context.students.Add(student);
            _context.SaveChanges();

            return Ok();
        }

        //Post delete
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            _context.students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();

        }


    }//Fin
}
