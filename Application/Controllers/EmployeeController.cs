using Application.Services.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult AddEmploy([FromBody]Employee request)
        {
            EmployeService.Add(request);
            return new OkResult();
        }
        [HttpGet("Get")]
        public IActionResult GetEmploy()
        {
            var responce = EmployeService.GetEmploye();
            return  new ObjectResult(responce);
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteEmploy([FromBody]Employee request)
        {
            EmployeService.Delete(request.Id);
            return new ObjectResult("Ok");
        }
        [HttpPut("Update")]
        public IActionResult Put([FromBody] Employee request)
        {
            EmployeService.Update(request);
            return new ObjectResult("Ok");
           
        }


    }
}
