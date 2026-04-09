using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment3.Models
{
	public class EventRegistration
	{
		[Required]
		[MinLength(3)]
		public string FullName { get; set; } = string.Empty;

		[Required]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;

		[Required]
		[StringLength(20)]
		public string EventCode { get; set; } = string.Empty;

		[Required]
		[Range(1, 10)]
		public int? Tickets { get; set; }

		public string? ReferralCode { get; set; }
	}
}
