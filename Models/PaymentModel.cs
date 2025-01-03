//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Stripe;
//using Stripe.Checkout;
//using System.Collections.Generic;

//namespace ContosoUniversity.Pages
//{
//    public class PaymentModel : PageModel
//    {
//        private readonly IConfiguration _configuration;

//        // Bindable property for the amount
//        [BindProperty]
//        public decimal Amount { get; set; }

//        public string PublishableKey { get; private set; }
//        public string ClientSecret { get; private set; }

//        public PaymentModel(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        public void OnGet()
//        {
//            PublishableKey = _configuration["Stripe:PublishableKey"];
//        }

//        public IActionResult OnPost()
//        {
//            // Validate the amount (must be greater than 0)
//            if (Amount <= 0)
//            {
//                ModelState.AddModelError(string.Empty, "Amount must be greater than zero.");
//                return Page(); // Return the page with an error message
//            }

//            // Convert amount to cents (Stripe requires amounts in the smallest currency unit)
//            long amountInCents = (long)(Amount * 100);

//            // Create a PaymentIntent
//            var options = new PaymentIntentCreateOptions
//            {
//                Amount = amountInCents, // Amount in cents
//                Currency = "usd",
//                PaymentMethodTypes = new List<string> { "card" }
//            };
//            var service = new PaymentIntentService();
//            var paymentIntent = service.Create(options);

//            ClientSecret = paymentIntent.ClientSecret;

//            return Page(); // Return to the page with the ClientSecret
//        }
//    }
//}
