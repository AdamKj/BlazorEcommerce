using Stripe;
using Stripe.Checkout;

namespace BlazorEcommerce.Server.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly ICartService _cartServie;
        private readonly IAuthService _authService;
        private readonly IOrderService _orderService;
        private const string secret = "whsec_26daea6cac74840de94d7b648ea794de2b520288dbd5a1de67b267667c1d8ed9";

        public PaymentService(ICartService cartServie, IAuthService authService, IOrderService orderService)
        {
            StripeConfiguration.ApiKey =
                "sk_test_51KjMY4CEQxNYipqatfZrtM7QTY1b66VHsdn11JlR02JHacS7O1AuWdkoVT0PIcss5baZZhBsX0WIXYP1NxBqLApo00z28sydE9";
            _cartServie = cartServie;
            _authService = authService;
            _orderService = orderService;
        }
        
        public async Task<Session> CreateCheckoutSession()
        {
            var products = (await _cartServie.GetDbCartProducts()).Data;
            var lineItems = new List<SessionLineItemOptions>();
            products.ForEach(product => lineItems.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = (decimal?) (product.Price * 100),
                    Currency = "sek",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = product.Title,
                        Images = new List<string> {product.ImageUrl}
                    }
                },
                Quantity = product.Quantity
            }));

            var options = new SessionCreateOptions
            {
                CustomerEmail = _authService.GetUserEmail(),
                ShippingAddressCollection = new SessionShippingAddressCollectionOptions
                {
                    AllowedCountries = new List<string> {"US"}
                },
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "https://localhost:7121/order-success",
                CancelUrl = "https://localhost:7121/cart"
            };

            var service = new SessionService();
            Session session = service.Create(options);
            return session;
        }

        public async Task<ServiceResponse<bool>> FulfillOrder(HttpRequest request)
        {
            var json = await new StreamReader(request.Body).ReadToEndAsync();
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                    json,
                    request.Headers["Stripe-Signature"],
                    secret
                    );

                if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    var session = stripeEvent.Data.Object as Session;
                    var user = await _authService.GetUserByEmail(session.CustomerEmail);
                    await _orderService.PlaceOrder(user.Id);
                }

                return new ServiceResponse<bool> {Data = true};
            }
            catch (StripeException e)
            {
                return new ServiceResponse<bool> {Data = false, Success = false, Message = e.Message};
            }
        }
    }
}
