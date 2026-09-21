
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz1.Data;
using Quiz1.Dto.SubjectDto;
using Quiz1.Dto;
using Quiz1.Models;

namespace Quiz1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SubjectsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subjects = await _context.Subjects
                .Include(s => s.Teacher)
                .ToListAsync();

            var result = _mapper.Map<List<SubjectDto>>(subjects);

            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var subject = await _context.Subjects
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(s => s.SubjectId == id);

            if (subject == null)
                return NotFound();

            var result = _mapper.Map<SubjectDto>(subject);

            return Ok(result);
        }

       
        [HttpPost]
        public async Task<IActionResult> Create(CreateSubjectDto dto)
        {
            var teacherExists = await _context.Teachers
                .AnyAsync(t => t.TeacherId == dto.TeacherId);

            if (!teacherExists)
                return BadRequest("Teacher does not exist.");

            var subject = _mapper.Map<Subject>(dto);

            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = subject.SubjectId },
                _mapper.Map<SubjectDto>(subject)
            );
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id, CreateSubjectDto dto)
        {
            var subject = await _context.Subjects
                .FindAsync(id);

            if (subject == null)
                return NotFound();

            var teacherExists = await _context.Teachers
                .AnyAsync(t => t.TeacherId == dto.TeacherId);

            if (!teacherExists)
                return BadRequest("Teacher does not exist.");

            _mapper.Map(dto, subject);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var subject = await _context.Subjects
                .FindAsync(id);

            if (subject == null)
                return NotFound();

            _context.Subjects.Remove(subject);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}