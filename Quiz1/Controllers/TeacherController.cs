using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quiz1.Dto.TeacherDTO;
using Quiz1.Models;
using Quiz1.Repo.Abstract;
using Quiz1.UnitWork.Abstraction;

namespace Quiz1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IUnitofWork repo;
        private readonly IMapper mapper;

        public TeachersController(IUnitofWork repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllTeachers()
        {
            var teachers = repo.Teachers.GetAll();

            if (teachers == null || teachers.Count == 0)
            {
                return NotFound("No Teachers Found");
            }

            var result = mapper.Map<List<TeacherDto>>(teachers);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetTeacherById(int id)
        {
            var teacher = repo.Teachers.GetById(id);

            if (teacher == null)
            {
                return NotFound("Teacher Not Found");
            }

            var result = mapper.Map<TeacherIDDto>(teacher);

            return Ok(result);
        }

        [HttpGet("department/{departmentId}")]
        public IActionResult GetTeachersByDepartment(int departmentId)
        {
            var teachers = repo.Teachers.GetTeachersByDepartment(departmentId);

            if (teachers == null || teachers.Count == 0)
            {
                return NotFound("No Teachers Found");
            }

            var result = mapper.Map<List<TeacherDto>>(teachers);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateTeacher([FromBody] CreateTeacherDto teacherDto)
        {
            if (teacherDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teacher = mapper.Map<Teacher>(teacherDto);

            repo.Teachers.Create(teacher);
            repo.SaveChanges();

            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTeacher(
            int id,
            [FromBody] CreateTeacherDto teacherDto)
        {
            if (teacherDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teacher = repo.Teachers.GetById(id);

            if (teacher == null)
            {
                return NotFound("Teacher Not Found");
            }

            mapper.Map(teacherDto, teacher);

            repo.Teachers.Update(teacher);
            repo.SaveChanges();

            return Ok("Teacher Updated Successfully");
        }

        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateTeacher(
            int id,
            [FromBody] PartialEditTeacherDto teacherDto)
        {
            if (teacherDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teacher = repo.Teachers.GetById(id);

            if (teacher == null)
            {
                return NotFound("Teacher Not Found");
            }

            mapper.Map(teacherDto, teacher);

            repo.Teachers.Update(teacher);
            repo.SaveChanges();

            return Ok("Teacher Updated Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            var teacher = repo.Teachers.GetById(id);

            if (teacher == null)
            {
                return NotFound("Teacher Not Found");
            }

            repo.Teachers.Delete(teacher);
            repo.SaveChanges();

            return Ok("Teacher Deleted Successfully");
        }

        [HttpGet("filter")]
        public IActionResult GetTeachersByDepartmentAndMinSalary([FromQuery] int departmentId, [FromQuery] decimal minSalary)
        {
            var teachers = repo.Teachers.GetTeachersByDepartmentAndMinSalary(departmentId, minSalary);

            return Ok(teachers);
        }

        [HttpGet("by-email")]
        public IActionResult GetTeacherByEmail([FromQuery] string email)
        {
            var teacher = repo.Teachers.GetWithEmail(email);

            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        [HttpGet("names")]
        public IActionResult GetTeacherNamesByDepartment([FromQuery] int departmentId)
        {
            var teachers = repo.Teachers.GetTeacherNamesByDepartment(departmentId);

            return Ok(teachers);
        }
    }
}