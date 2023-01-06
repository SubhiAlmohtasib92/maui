using Microsoft.Identity.Client;
using Ethel.Auth;

namespace Ethel.Auth
{
    public static class DependencyExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            string authority = $"https://login.microsoftonline.com/{Constants.TenantName}";
            var clientApplicationBuilder = PublicClientApplicationBuilder.Create(Constants.ClientId)
#if IOS
.WithIosKeychainSecurityGroup("com.microsoft.adalcache")
#endif
#if WINDOWS
.WithRedirectUri("http://localhost")
#else
.WithRedirectUri($"msal{Constants.ClientId}://auth")
#endif
                .WithAuthority(authority);
            services.AddSingleton(new AuthService(clientApplicationBuilder.Build()));
        }
    }
}
