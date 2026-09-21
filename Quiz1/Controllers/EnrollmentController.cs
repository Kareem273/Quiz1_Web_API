using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz1.Data;
using Quiz1.Dto.EnrollmentDto;
using Quiz1.Dto;
using Quiz1.Models;

namespace Quiz1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public EnrollmentsController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var enrollments = context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Subject)
                .ToList();

            var result = mapper.Map<List<EnrollmentDto>>(enrollments);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var enrollment = context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Subject)
                .FirstOrDefault(e => e.EnrollmentId == id);

            if (enrollment == null)
                return NotFound();

            var result = mapper.Map<EnrollmentDto>(enrollment);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(CreateEnrollmentDto dto)
        {
            var student = context.Students
                .FirstOrDefault(s => s.StudentId == dto.StudentId);

            if (student == null)
                return BadRequest("Student does not exist");

            var subject = context.Subjects
                .FirstOrDefault(s => s.SubjectId == dto.SubjecttId);

            if (subject == null)
                return BadRequest("Subject does not exist");

            var enrollment = mapper.Map<Enrollment>(dto);

            context.Enrollments.Add(enrollment);
            context.SaveChanges();

            return Ok(enrollment);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CreateEnrollmentDto dto)
        {
            var enrollment = context.Enrollments
                .FirstOrDefault(e => e.EnrollmentId == id);

            if (enrollment == null)
                return NotFound();

            enrollment.StudentId = dto.StudentId;
            enrollment.SubjecttId = dto.SubjecttId;
            enrollment.EnrollmentDate = dto.EnrollmentDate;
            enrollment.Grade = dto.Grade;

            context.SaveChanges();

            return Ok(enrollment);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var enrollment = context.Enrollments
                .FirstOrDefault(e => e.EnrollmentId == id);

            if (enrollment == null)
                return NotFound();

            context.Enrollments.Remove(enrollment);
            context.SaveChanges();

            return Ok("Enrollment deleted successfully");
        }
    }
}