using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stripe;
using StripeIntegration.Models;

namespace StripeIntegration.Controllers
{
	public class Processor
	{
		public static string GetTokenId(Payment payment)
		{
			StripeTokenCreateOptions myToken = new StripeTokenCreateOptions();

			StripeCreditCardOptions card = new StripeCreditCardOptions()
			{
				AddressCountry = "USA",
				AddressLine1 = payment.addressLine1,
				AddressLine2 = payment.addressLine2,
				AddressCity = payment.city,
				AddressZip = payment.zip,
				Cvc = payment.cvc,
				Number = payment.ccnumber,
				ExpirationMonth = payment.expirationMonth,
				ExpirationYear = payment.expirationYear,
				Name = payment.firstName + " " + payment.lastName
			};

			myToken.Card = card;

			var tokenService = new StripeTokenService();
			var stripeToken = tokenService.Create(myToken);

			return stripeToken.Id;
		}

		public static string ChargeCustomer(string tokenId, Payment payment)
		{
			var myCharge = new StripeChargeCreateOptions
			{
				Amount = Int32.Parse(payment.amount),
				Currency = "usd",
				Description = "My first payment",
				SourceTokenOrExistingSourceId = tokenId
			};

			var chargeService = new StripeChargeService();
			var stripeCharge = chargeService.Create(myCharge);

			return stripeCharge.Id;
		}
	}

	
}