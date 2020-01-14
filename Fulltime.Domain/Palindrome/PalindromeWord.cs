using Fulltime.Domain.Common;

namespace Fulltime.Domain.Palindrome
{
    public class PalindromeWord: AuditableEntity
    {
        public int WordId { get; set; }
        public string Content { get; set; }
        public bool IsPalindrome { get; set; }

    }
}
