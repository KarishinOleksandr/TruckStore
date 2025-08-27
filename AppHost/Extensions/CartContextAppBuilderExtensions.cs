using AppHost.Http;

namespace AppHost.Extensions
{
    public static class CartContextAppBuilderExtensions
    {
        public static IApplicationBuilder UserCartContext(this IApplicationBuilder app) => app.UseMiddleware<CartContextRequest>();
    }
}
