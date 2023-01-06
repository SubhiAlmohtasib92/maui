using CommunityToolkit.Maui.Alerts;
using Microsoft.Identity.Client;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Ethel.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IPublicClientApplication authenticationClient;

        public AuthService(IPublicClientApplication authenticationClient)
        {
            this.authenticationClient = authenticationClient;
        }
        public async Task<AuthenticationResult?> SignInByUsernameAndPassword(CancellationToken cancellationToken, string username, string password)
        {
            try
            {
                var item = await authenticationClient
                    .AcquireTokenInteractive(Constants.Scopes)
                    .WithUseEmbeddedWebView(true)
                   .ExecuteAsync(cancellationToken);
                return item;
                
            }catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<AuthenticationResult?> AcquireTokenSilent(CancellationToken cancellationToken)
        {
            try
            {
                var accounts = await authenticationClient.GetAccountsAsync(Constants.SignInPolicy);
                var firstAccount = accounts.FirstOrDefault();
                if (firstAccount is null)
                {
                    return null;
                }

                return await authenticationClient.AcquireTokenSilent(Constants.Scopes, firstAccount)
                                                 .ExecuteAsync(cancellationToken);
            }
            catch (MsalUiRequiredException)
            {
                return null;
            }
        }

        public async Task LogoutAsync(CancellationToken cancellationToken)
        {
            var accounts = await authenticationClient.GetAccountsAsync();
            foreach (var account in accounts)
            {
                await authenticationClient.RemoveAsync(account);
            }
        }

        public async Task GetUserInfo(AuthenticationResult result)
        {
            var token = result?.IdToken;
            if (token != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var data = handler.ReadJwtToken(token);
                if (data != null)
                {
                    var stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine($"Name: {data.Claims.FirstOrDefault(x => x.Type.Equals("name"))?.Value}");
                    await Toast.Make(stringBuilder.ToString()).Show();
                }
            }
        }
    }
}
