using TruckStore.Application.Interfaces;

namespace AppHost.Http
{
    public class CartContextRequest
    {
        private readonly RequestDelegate _next;
        private const string CookieName = "CartId";

        public CartContextRequest(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ICartContext cartContext)
        {
            Guid cartId;

            if (!httpContext.Request.Cookies.TryGetValue(CookieName, out var s) || !Guid.TryParse(s, out cartId))
            {
                cartId = Guid.NewGuid();
                httpContext.Response.Cookies.Append(CookieName, cartId.ToString(), new CookieOptions
                {
                    IsEssential = true,
                    HttpOnly = true,
                    SameSite = SameSiteMode.Lax,
                    Secure = true,
                    Expires = DateTimeOffset.UtcNow
                });
            }
            cartContext.CartId = cartId;

            await _next(httpContext);
        }
    }
}
