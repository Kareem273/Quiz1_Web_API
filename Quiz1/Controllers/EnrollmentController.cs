using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quiz1.Dto.EnrollmentDto;
using Quiz1.Models;
using Quiz1.Repo.Abstract;

namespace Quiz1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IGenericRepo<Enrollment> repo;
        private readonly IMapper mapper;

        public EnrollmentsController(
            IGenericRepo<Enrollment> repo,
            IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var enrollments = repo.GetAll();

            var result = mapper.Map<List<EnrollmentDto>>(enrollments);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var enrollment = repo.GetById(id);

            if (enrollment == null)
                return NotFound();

            var result = mapper.Map<EnrollmentDto>(enrollment);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(CreateEnrollmentDto dto)
        {
            var enrollment = mapper.Map<Enrollment>(dto);

            repo.Create(enrollment);
            repo.SaveChanges();

            return Ok(enrollment);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CreateEnrollmentDto dto)
        {
            var enrollment = repo.GetById(id);

            if (enrollment == null)
                return NotFound();

            mapper.Map(dto, enrollment);

            repo.Update(enrollment);
            repo.SaveChanges();

            return Ok(enrollment);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var enrollment = repo.GetById(id);

            if (enrollment == null)
                return NotFound();

            repo.Delete(enrollment);
            repo.SaveChanges();

            return Ok("Enrollment deleted successfully");
        }
    }
}