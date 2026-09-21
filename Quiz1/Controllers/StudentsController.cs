using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz1.Data;
using Quiz1.Models;

namespace Quiz1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly AppDbContext db;
        public StudentsController()
        {
            db = new AppDbContext();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = db.Students.Include(s=>s.Classroom).ToList();

            return Ok(students);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var student = db.Students.Include(s=>s.Classroom).FirstOrDefault(s=>s.StudentId==id);


            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpGet("{name:alpha}")]
        public IActionResult GetByFullName(string name, string lastname)
        {
            var fullname = $"{name} {lastname}";
            var student = db.Students.FirstOrDefault(s => s.FullName == fullname);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);


        }

        [Route("/Api/std/fname")]
        [HttpGet]
        public IActionResult GetByFName(string name)
        {

            var student = db.Students.FirstOrDefault(s => s.Firstname == name);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);


        }

        [Route("/Api/std/lname")]
        [HttpGet]
        public IActionResult GetByLName(string name)
        {

            var student = db.Students.FirstOrDefault(s => s.Lastname == name);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);


        }


        [HttpPost]
        public IActionResult CreateStudent([FromBody]Student s)
        {

            if (s == null || !ModelState.IsValid)
                return BadRequest();

            var existingclassroom = db.Classrooms.Any(c => c.ClassroomId == s.ClassroomId);
            if (existingclassroom == false)
            {
                return BadRequest(new { message = "Not Exist Classroom ( " });
            }
            db.Students.Add(s);
            db.SaveChanges();
            return Created();
        }

        [HttpPut]
        public IActionResult UpdateStudent(int id,[FromBody] Student s)
        {
            if (s.ClassroomId != id)
                return BadRequest();
            var eistingstudent= db.Students.FirstOrDefault(s=>s.StudentId == id);

            if (eistingstudent == null)
                return NotFound();

            eistingstudent.Firstname = s.Firstname;
            eistingstudent.Lastname = s.Lastname;
            eistingstudent.Email = s.Email;
            eistingstudent.DOF = s.DOF;
            eistingstudent.Phone = s.Phone;
            eistingstudent.ClassroomId = s.ClassroomId;

            db.SaveChanges();
            return NoContent();



        }


        [HttpPatch]

        public IActionResult PartialEdit(int id,[FromBody]string firstname )
        {
            var existingstudent = db.Students.Find(id);

            if (existingstudent == null)
                return NotFound();

            existingstudent.Firstname = firstname;

            return NoContent();
        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            var student = db.Students.Find(id);

            if (student == null)
            { return NotFound();}

            db.Students.Remove(student);
            db.SaveChanges();
            return NoContent();
        }
    }
}
