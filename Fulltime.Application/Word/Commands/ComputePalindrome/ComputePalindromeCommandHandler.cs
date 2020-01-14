using Fulltime.Application.Common.Interfaces;
using Fulltime.Domain.Palindrome;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Fulltime.Application.Word.Commands.ComputePalindrome
{
    public class ComputePalindromeCommandHandler : IRequestHandler<ComputePalindromeCommand, PalindromeVm>
    {
        private IFulltimeDbContext _context;
        public ComputePalindromeCommandHandler(IFulltimeDbContext context)
        {
            _context = context;
        }

        public async Task<PalindromeVm> Handle(ComputePalindromeCommand request, CancellationToken cancellationToken)
        {
            var word = _context.PalindromeWords.Where(x => x.Content == request.Word).First();
            if (word != null)
            {
                return new PalindromeVm { Result = word.IsPalindrome ? "Es palindroma" : "No es palindroma" };
            }

            bool palindrome = ComputePalindrome(request.Word.ToCharArray());
            _context.PalindromeWords.Add(new PalindromeWord {
                Content = request.Word,
                IsPalindrome = palindrome
            });

            await _context.SaveChangesAsync(cancellationToken);

            if (palindrome)
            {
                return new PalindromeVm
                {
                    Result = "Es palindroma"
                };
            }
            else
            {
                return new PalindromeVm
                {
                    Result = "No es palindroma"
                };
            }
        }

        private static bool ComputePalindrome(char[] characters)
        {
            var palindrome = true;
            for (int i = 0; i < characters.Length; i++)
            {
                if (characters[i] != characters[characters.Length - (i + 1)])
                {
                    palindrome = false;
                    break;
                }
            }

            return palindrome;
        }
    }
}
