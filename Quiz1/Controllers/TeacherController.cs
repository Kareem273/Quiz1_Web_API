using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quiz1.Dto.TeacherDTO;
using Quiz1.Models;
using Quiz1.Repo.Abstract;

namespace Quiz1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepo repo;
        private readonly IMapper mapper;

        public TeachersController(ITeacherRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllTeachers()
        {
            var teachers = repo.GetAll();

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
            var teacher = repo.GetById(id);

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
            var teachers = repo.GetTeachersByDepartment(departmentId);

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

            repo.Create(teacher);
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

            var teacher = repo.GetById(id);

            if (teacher == null)
            {
                return NotFound("Teacher Not Found");
            }

            mapper.Map(teacherDto, teacher);

            repo.Update(teacher);
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

            var teacher = repo.GetById(id);

            if (teacher == null)
            {
                return NotFound("Teacher Not Found");
            }

            mapper.Map(teacherDto, teacher);

            repo.Update(teacher);
            repo.SaveChanges();

            return Ok("Teacher Updated Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            var teacher = repo.GetById(id);

            if (teacher == null)
            {
                return NotFound("Teacher Not Found");
            }

            repo.Delete(teacher);
            repo.SaveChanges();

            return Ok("Teacher Deleted Successfully");
        }
    }
}