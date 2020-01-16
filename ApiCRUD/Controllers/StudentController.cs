// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCRUD.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
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
    }
}
