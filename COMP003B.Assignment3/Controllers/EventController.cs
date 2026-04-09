using COMP003B.Assignment3.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Assignment3.Controllers
{
	public class EventController : Controller
	{
		[HttpGet("event/register/{eventCode}")]
		public IActionResult Register(string eventCode)
		{
			var registration = new EventRegistration
			{
				EventCode = eventCode
			};

			return View(registration);
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View(new EventRegistration());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Register([FromForm] EventRegistration registration)
		{
			if (!ModelState.IsValid)
			{
				return View(registration);
			}

			return RedirectToAction("Success", new
			{
				registration.FullName,
				registration.Email,
				registration.EventCode,
				registration.Tickets,
				registration.ReferralCode
			});
		}

		[HttpGet]
		public IActionResult Success(EventRegistration registration)
		{
			return View(registration);
		}
	}
}
