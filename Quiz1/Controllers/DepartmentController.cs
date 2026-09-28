using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quiz1.Dto.DepartmentDto;
using Quiz1.Models;
using Quiz1.Repo.Abstract;

namespace Quiz1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IGenericRepo<Department> repo;
        private readonly IMapper mapper;

        public DepartmentsController(
            IGenericRepo<Department> repo,
            IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            var departments = repo.GetAll();

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
            var department = repo.GetById(Id);

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

            repo.Create(department);
            repo.SaveChanges();

            return Created();
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateDepartment(
            int Id,
            CreateDepartmentDto departmentdto)
        {
            var department = repo.GetById(Id);

            if (department == null)
            {
                return NotFound("Id does not exist.");
            }

            mapper.Map(departmentdto, department);

            repo.Update(department);
            repo.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteDepartment(int Id)
        {
            var department = repo.GetById(Id);

            if (department == null)
            {
                return NotFound("Id does not exist.");
            }

            repo.Delete(department);
            repo.SaveChanges();

            return Ok("Department deleted successfully");
        }
    }
}