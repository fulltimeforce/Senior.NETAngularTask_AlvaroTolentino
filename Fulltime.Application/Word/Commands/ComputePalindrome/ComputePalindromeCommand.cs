using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fulltime.Application.Word.Commands.ComputePalindrome
{
    public class ComputePalindromeCommand: IRequest<PalindromeVm>
    {
        public string Word { get; set; }
    }
}
