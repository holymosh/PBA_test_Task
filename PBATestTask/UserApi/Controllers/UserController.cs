using System;
using Common;
using Common.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace UserApi.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IGenericRepository<User> _repository;

        public UserController(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser([FromRoute] int id)
        {
            var user = _repository.FindById(id);
            return user == null ? (IActionResult) NotFound() : Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (user.Username == String.Empty 
                || user.DepartmentId.Equals(0) 
                || user.Username == null)
            {
                return BadRequest("some field is empty");
            }
            _repository.Create(user);
            return Ok(user.Id);
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] User user)
        {
            if (user.Username == String.Empty
                || user.DepartmentId.Equals(0)
                || user.Username == null)
            {
                return BadRequest("some field is empty");
            }
            _repository.Update(user);
            return Ok("updated");
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            var entityToDelete = _repository.FindById(id);
            if (entityToDelete == null)
            {
                return NotFound($"entity with id={id} wasn't found");
            }
            _repository.Remove(entityToDelete);
            return Ok("deleted");
        }

        [HttpGet]
        [Route("find")]
        public IActionResult FindByName([FromQuery] string name)
        {
            return Ok(_repository.FindByPredicate(user => user.Username.Contains(name)));
        }
    }
}