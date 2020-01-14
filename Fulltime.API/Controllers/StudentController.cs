using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fulltime.Application.Student.Commands.CreateStudentRecords;

namespace Fulltime.API.Controllers
{
    public class StudentController: BaseController
    {
        [HttpPost(name = "get-summary")]
        public async Task<ActionResult<StudentRecordsVm>> ComputeSummary([FromBody]CreateRecordsCommand command){
            var summary = await Mediator.Send(command);
            return Ok(summary);
        }
    }
}
