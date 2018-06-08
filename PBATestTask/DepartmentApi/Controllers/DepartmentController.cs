using Common.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Department")]
    public class DepartmentController : Controller
    {
        private readonly IGenericRepository<Department> _repository;

        public DepartmentController(IGenericRepository<Department> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDepartment([FromRoute] int id)
        {
            var department = _repository.FindById(id);
            return department == null ? (IActionResult) NotFound() : Ok(department);
        }

        [HttpPost]
        public IActionResult CreateDepartment([FromBody] Department department)
        {
            if (string.IsNullOrEmpty(department.Title))
            {
                return BadRequest();
            }
            _repository.Create(department);
            return Ok("created");
        }

        [HttpPut]
        public IActionResult UpdateDepartment([FromBody] Department department)
        {
            if (string.IsNullOrEmpty(department.Title))
            {
                return BadRequest();
            }
            _repository.Update(department);
            return Ok("updated");
        }

        [HttpDelete]
        public IActionResult DeleteDepartment([FromBody] Department department)
        {
            _repository.Remove(department);
            return Ok();
        }

        [HttpGet]
        [Route("find")]
        public IActionResult FindDepartment([FromQuery] string title)
        {
            return Ok(_repository.FindByPredicate(department => department.Title.Contains(title)));
        }
    }
}