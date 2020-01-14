using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Fulltime.API.Controllers
{
    public class WordController : BaseController
    {
        [HttpPost(name = "is-palindrome")]
        public async Task<ActionResult<PalindromeVm>> ComputePalindrome([FromBody]ComputePalindromeCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
