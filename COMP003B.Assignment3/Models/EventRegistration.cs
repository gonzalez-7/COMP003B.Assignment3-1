using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment3.Models
{
	public class EventRegistration
	{
		[Required(ErrorMessage = "Full Name is required.")]
		[MinLength(3, ErrorMessage = "Full Name must be at least 3 characters.")]
		public string FullName { get; set; } = string.Empty;

		[Required(ErrorMessage = "Email is required.")]
		[EmailAddress(ErrorMessage = "Please enter a valid email address.")]
		public string Email { get; set; } = string.Empty;

		[Required(ErrorMessage = "Event Code is required.")]
		[StringLength(20, ErrorMessage = "Event Code cannot exceed 20 characters.")]
		public string EventCode { get; set; } = string.Empty;

		[Required(ErrorMessage = "Tickets is required.")]
		[Range(1, 10, ErrorMessage = "Tickets must be between 1 and 10.")]
		public int? Tickets { get; set; }

		public string? ReferralCode { get; set; }
	}
}
