using FluentValidation;

namespace Fulltime.Application.Word.Commands.ComputePalindrome
{
    public class ComputePalindromeCommandValidation: AbstractValidator<ComputePalindromeCommand>
    {
        public ComputePalindromeCommandValidation()
        {
            RuleFor(x => x.Word).MinimumLength(3).NotEmpty();
        }
    }
}
