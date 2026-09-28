using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quiz1.Dto.SubjectDto;
using Quiz1.Models;
using Quiz1.Repo.Abstract;

namespace Quiz1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectRepo repo;
        private readonly IMapper mapper;

        public SubjectsController(ISubjectRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var subjects = repo.GetAll();

            var result = mapper.Map<List<SubjectDto>>(subjects);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var subject = repo.GetById(id);

            if (subject == null)
                return NotFound();

            var result = mapper.Map<SubjectDto>(subject);

            return Ok(result);
        }

        [HttpGet("teacher/{teacherId}")]
        public IActionResult GetSubjectsByTeacher(int teacherId)
        {
            var subjects = repo.GetSubjectsByTeacher(teacherId);

            if (subjects == null || subjects.Count == 0)
                return NotFound();

            var result = mapper.Map<List<SubjectDto>>(subjects);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(CreateSubjectDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var subject = mapper.Map<Subject>(dto);

            repo.Create(subject);
            repo.SaveChanges();

            var result = mapper.Map<SubjectDto>(subject);

            return CreatedAtAction(
                nameof(GetById),
                new { id = subject.SubjectId },
                result
            );
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CreateSubjectDto dto)
        {
            var subject = repo.GetById(id);

            if (subject == null)
                return NotFound();

            mapper.Map(dto, subject);

            repo.Update(subject);
            repo.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var subject = repo.GetById(id);

            if (subject == null)
                return NotFound();

            repo.Delete(subject);
            repo.SaveChanges();

            return NoContent();
        }
    }
}