using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz1.Data;
using Quiz1.Dto.DepartmentDto;
using Quiz1.Models;
using Quiz1.Profiles;


namespace Quiz1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly AppDbContext db;
        private readonly IMapper mapper;
        public DepartmentsController()
        {
            db = new AppDbContext();
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DepartmentProfile());
            }).CreateMapper();
        }

        

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            var departments = db.Departments.ToList();
            if (departments == null || departments.Count == 0)
            {
                return NotFound("No departments found!");
            }
            var deptdtos = mapper.Map<List<DepartmentDto>>(departments);

            return Ok(deptdtos);
        }
        [HttpGet("{Id}")]
        public IActionResult GetDepartmentId(int Id)
        {
            var department = db.Departments.FirstOrDefault(d => d.DepartmentId == Id);
            if (department == null)
            {
                return NotFound("Id does not exist");
            }
            var departmentDto = mapper.Map<DepartmentDto>(department);
            return Ok(departmentDto);
        }
        [HttpPost]
        public IActionResult CreateDepartment(CreateDepartmentDto departmentDto)
        {
            if (departmentDto == null || !ModelState.IsValid)
            {
                return BadRequest("Please Enter The Department Correctly");
            }
           var department = mapper.Map<Department>(departmentDto);
            db.Departments.Add(department);
            db.SaveChanges();
            return Created();
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateDepartment(int Id, CreateDepartmentDto departmentdto)
        {
            var department = db.Departments.FirstOrDefault(d => d.DepartmentId == Id);
            if (department == null)
            {
                return NotFound("Id does not exist.");
            }
            var updatedDepartment = mapper.Map<CreateDepartmentDto, Department>(departmentdto, department);
            db.SaveChanges();
            return NoContent();
        }
    }

   
}
