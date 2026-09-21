using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz1.Data;
using Quiz1.Dto.ClassRoomDto;
using Quiz1.Dto;
using Quiz1.Models;

namespace Quiz1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomsController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ClassroomsController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var classrooms = context.Classrooms.ToList();

            var result = mapper.Map<List<ClassroomDto>>(classrooms);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var classroom = context.Classrooms
                .Include(c => c.Students)
                .FirstOrDefault(c => c.ClassroomId == id);

            if (classroom == null)
                return NotFound();

            var result = mapper.Map<ClassRoomIDDto>(classroom);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(ClassroomDto dto)
        {
            var classroom = mapper.Map<Classroom>(dto);

            context.Classrooms.Add(classroom);
            context.SaveChanges();

            return Ok(classroom);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ClassroomDto dto)
        {
            var classroom = context.Classrooms
                .FirstOrDefault(c => c.ClassroomId == id);

            if (classroom == null)
                return NotFound();

            classroom.Name = dto.Name;
            classroom.Grade = dto.Grade;
            classroom.Capacity = dto.Capacity;

            context.SaveChanges();

            return Ok(classroom);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var classroom = context.Classrooms
                .FirstOrDefault(c => c.ClassroomId == id);

            if (classroom == null)
                return NotFound();

            context.Classrooms.Remove(classroom);
            context.SaveChanges();

            return Ok("Classroom deleted successfully");
        }
    }
}