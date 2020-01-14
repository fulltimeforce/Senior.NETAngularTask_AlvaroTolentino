using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fulltime.Application.Employee.Commands.ComputeSalary;
using Fulltime.Application.Employee.Commands.CreateRate;
namespace Fulltime.API.Controllers
{
    public class EmployeeController : BaseController
    {

        [HttpPost(name = "compute-salary")]
        public async Task<EmployeeSalaryVm> ComputeSalary([FromBody]ComputeSalaryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost(name = "create-rate")]
        public async Task<IActionResult> CreateRate([FromBody]CreateRateCommand command)
        {
            var rateId = await Mediator.Send(command);
            return Ok(rateId);
        }


    }
}
