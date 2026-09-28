using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quiz1.Dto.ClassRoomDto;
using Quiz1.Models;
using Quiz1.Repo.Abstract;

namespace Quiz1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomsController : ControllerBase
    {
        private readonly IGenericRepo<Classroom> repo;
        private readonly IMapper mapper;

        public ClassroomsController(IGenericRepo<Classroom> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var classrooms = repo.GetAll();

            var result = mapper.Map<List<ClassroomDto>>(classrooms);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var classroom = repo.GetById(id);

            if (classroom == null)
                return NotFound();

            var result = mapper.Map<ClassRoomIDDto>(classroom);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(ClassroomDto dto)
        {
            var classroom = mapper.Map<Classroom>(dto);

            repo.Create(classroom);
            repo.SaveChanges();

            return Ok(classroom);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ClassroomDto dto)
        {
            var classroom = repo.GetById(id);

            if (classroom == null)
                return NotFound();

            mapper.Map(dto, classroom);

            repo.Update(classroom);
            repo.SaveChanges();

            var result = mapper.Map<ClassroomDto>(classroom);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var classroom = repo.GetById(id);

            if (classroom == null)
                return NotFound();

            repo.Delete(classroom);
            repo.SaveChanges();

            return Ok("Classroom deleted successfully");
        }
    }
}