using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RxProgramming.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeesController()
        {
            Thread.Sleep(5000);
            _employeeRepository = new EmployeeRepository();
        }
        // GET: api/<EntitiesController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeeRepository.ListEmployees();
        }

        // GET api/<EntitiesController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _employeeRepository.GetEmployee(id);
        }

        // POST api/<EntitiesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EntitiesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EntitiesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
