using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stripe;
using Stripe.Checkout;

namespace ContosoUniversity.Pages
{
    public class PaymentModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public string PublishableKey { get; private set; }
        public string ClientSecret { get; private set; }

        public PaymentModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            PublishableKey = _configuration["Stripe:PublishableKey"];

            // Create a PaymentIntent
            var options = new PaymentIntentCreateOptions
            {
                Amount = 5000, // Amount in cents (e.g., $50.00)
                Currency = "usd",
                PaymentMethodTypes = new List<string> { "card" }
            };
            var service = new PaymentIntentService();
            var paymentIntent = service.Create(options);

            ClientSecret = paymentIntent.ClientSecret;
        }
    }
}
