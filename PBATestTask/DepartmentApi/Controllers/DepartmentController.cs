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
    }
}