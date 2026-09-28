using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quiz1.Dto;
using Quiz1.Dto.StudentDto;
using Quiz1.Models;
using Quiz1.Repo.Abstract;

namespace Quiz1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepo repo;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = repo.GetAll();

            var studentDtos = mapper.Map<List<StudentDto>>(students);

            return Ok(studentDtos);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var student = repo.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            var studentDto = mapper.Map<StudentDto>(student);

            return Ok(studentDto);
        }

        [HttpGet("classroom/{classroomId}")]
        public IActionResult GetStudentsByClassroom(int classroomId)
        {
            var students = repo.GetStudentsByClassroom(classroomId);

            if (students == null || students.Count == 0)
            {
                return NotFound();
            }

            var studentDtos = mapper.Map<List<StudentDto>>(students);

            return Ok(studentDtos);
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] StudentDto dto)
        {
            if (dto == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var student = mapper.Map<Student>(dto);

            repo.Create(student);
            repo.SaveChanges();

            return Created("", student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] StudentDto dto)
        {
            var student = repo.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            mapper.Map(dto, student);

            repo.Update(student);
            repo.SaveChanges();

            return NoContent();
        }

        [HttpPatch]
        public IActionResult PartialEdit(int id, [FromBody] string firstname)
        {
            var student = repo.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            student.Firstname = firstname;

            repo.Update(student);
            repo.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = repo.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            repo.Delete(student);
            repo.SaveChanges();

            return NoContent();
        }
    }
}