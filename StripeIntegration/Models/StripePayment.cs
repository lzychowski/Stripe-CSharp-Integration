using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StripeIntegration.Models
{
	public class StripePayment
	{
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string addressLine1 { get; set; }
		public string addressLine2 { get; set; }
		public string city { get; set; }
		public string state { get; set; }
		public string zip { get; set; }

		public string amount { get; set; }
		public string ccnumber { get; set; }
		public string cvc { get; set; }
		public string expirationMonth { get; set; }
		public string expirationYear { get; set; }
	}
}