using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz1.Dto.TeacherDTO;
using Quiz1.Models;
using Quiz1.Profiles;

namespace Quiz1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly AppDbCotnext _context;
        private readonly IMapper mapper;

        public TeachersController()
        {
            _context = new AppDbCotnext();
            var p = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new TeacherProfile());
            });
            mapper =p.CreateMapper();
        }
        [HttpGet]
        public ActionResult<List<TeacherDto>> GetAllTeachers()
        {
            var Teachers = _context.Teachers.Include(t => t.Department).ToList();
            if (Teachers == null || Teachers.Count == 0)
            {
                return NotFound("No Teachers Found");
            }
            var m =mapper.Map<List<TeacherDto>>(Teachers);

            return Ok(m);
        }

        [HttpGet("{id}")]
        public ActionResult<TeacherIDDto> GetTeacherById(int id)
        {
            var teacher = _context.Teachers
                .Include(t => t.Department)
                .FirstOrDefault(t => t.TeacherId == id);

            if (teacher == null)
            {
                return NotFound("Teacher Not Found");
            }

            var result = mapper.Map<TeacherIDDto>(teacher);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateTeacher([FromBody] CreateTeacherDto Teacherdto)
        {
            if (Teacherdto == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var teacher = mapper.Map<Teacher>(Teacherdto);

            _context.Teachers.Add(teacher);
            _context.SaveChanges();

            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTeacher(int id, [FromBody] CreateTeacherDto teacherDto)
        {
            if (teacherDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teacher = _context.Teachers
                .FirstOrDefault(t => t.TeacherId == id);

            if (teacher == null)
            {
                return NotFound("Teacher Not Found");
            }

            mapper.Map(teacherDto, teacher);

            _context.SaveChanges();

            return Ok("Teacher Updated Successfully");
        }

        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateTeacher(int id, [FromBody] PartialEditTeacherDto teacherDto)
        {
            if (teacherDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teacher = _context.Teachers
                .FirstOrDefault(t => t.TeacherId == id);

            if (teacher == null)
            {
                return NotFound("Teacher Not Found");
            }

            mapper.Map(teacherDto, teacher);

            _context.SaveChanges();

            return Ok("Teacher Updated Successfully");
        }

    }
}
