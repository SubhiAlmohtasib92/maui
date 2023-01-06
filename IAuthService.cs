using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethel.Auth
{
    public interface IAuthService
    {
        Task<AuthenticationResult?> SignInByUsernameAndPassword(CancellationToken cancellationToken,string username, string password);
        Task<AuthenticationResult?> AcquireTokenSilent(CancellationToken cancellationToken);
        Task LogoutAsync(CancellationToken cancellationToken);
        Task GetUserInfo(AuthenticationResult? result);
    }
}
