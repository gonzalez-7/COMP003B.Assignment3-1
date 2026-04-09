using COMP003B.Assignment3.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Assignment3.Controllers
{
	public class EventController : Controller
	{
		[HttpGet("event/register/{eventCode}")]
		public IActionResult Register(string eventCode)
		{
			var model = new EventRegistration
			{
				EventCode = eventCode
			};

			return View(model);
		}
		[HttpGet]
		public IActionResult Register()
		{
			return View(new EventRegistration());
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Register(EventRegistration registration)
		{
			if (!ModelState.IsValid)
			{
				return View(registration);
			}
			TempData["FullName"] = registration.FullName;
			TempData["Email"] = registration.Email;
			TempData["EventCode"] = registration.EventCode;
			TempData["Tickets"] = registration.Tickets?.ToString();
			TempData["ReferralCode"] = registration.ReferralCode ?? string.Empty;

			return RedirectToAction("Success");
		}
		[HttpGet]
		public IActionResult Success()
		{
			int? tickets = null;
			if (int.TryParse(TempData.Peek("Tickets")?.ToString(), out int parsedTickets))
			{
				tickets = parsedTickets;
			}

			var model = new EventRegistration
			{
				FullName = TempData.Peek("FullName")?.ToString() ?? string.Empty,
				Email = TempData.Peek("Email")?.ToString() ?? string.Empty,
				EventCode = TempData.Peek("EventCode")?.ToString() ?? string.Empty,
				Tickets = tickets,
				ReferralCode = TempData.Peek("ReferralCode")?.ToString()
			};

			return View(model);
		}
	}
}
