using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StripeIntegration.Models;
using RestSharp;
using System.Text.RegularExpressions;

namespace StripeIntegration.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		[Route("", Name = "Payment")]
		public ActionResult Index(bool? error)
		{
			if (error != null)
			{
				if ((bool)error)
				{
					ViewBag.Message = "An unknown error has occured";
				}
			}
			else
			{
				ViewBag.Message = "";
			}

			Payment payment = new Payment();
			return View(payment);
		}

		[HttpPost]
		[Route("payments", Name = "PaymentPost")]
		public ActionResult PaymentPost(Payment payment)
		{
			// strip non numeric chars
			Regex digitsOnly = new Regex(@"[^\d]");
			payment.amount = digitsOnly.Replace(payment.amount, "");

			try
			{
				var tokenId = Processor.GetTokenId(payment);
				var chargeId = Processor.ChargeCustomer(tokenId, payment);
			}
			catch (Exception e)
			{
				return RedirectToAction("Index", new { error = true });
			}

			return RedirectToAction("Confirmation", payment);
		}

		[HttpGet]
		[Route("confirmation", Name = "Confirmation")]
		public ActionResult Confirmation(Payment payment)
		{
			ViewBag.Message = "Your payment of " + payment.amount + " cents was successful.";

			return View();
		}

	}
}