using Application.Services.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeService EmployeService;

        public EmployeeController(IEmployeService EmployeService)
        {
            this.EmployeService = EmployeService;
        }

        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddEmploy([FromBody] Employee request)
        {
            EmployeService.Add(request);
            return Ok();
        }

        [HttpGet("Get")]
        [ProducesResponseType(typeof(IEnumerable<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetEmploy()
        {
            var responce = EmployeService.GetEmploye();
            if (responce == null)
            {
                return NotFound();
            }
            return Ok(responce);
        }

        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteEmploy([FromBody] Employee request)
        {
            var deleted = EmployeService.Delete(request.Id);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok("Ok");
        }

        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] Employee request)
        {
            if (!EmployeService.Update(request))
            { 
                return NotFound();
            }
            return Ok("Ok");
        }
    }
}