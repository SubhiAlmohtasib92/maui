using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethel
{
    public static class Constants
    {
        public static readonly string ClientId = "ee89e805-b6de-44ad-85b2-65fa591ced4e"; // "YOUR_CLIENT_ID_HERE"
        public static readonly string[] Scopes = { "user.read" };
        // The next code to add B2C
        public static readonly string TenantName = "ac7c944a-5e83-43cc-944a-a34e04dc721a";
        public static readonly string TenantId = $"{TenantName}.onmicrosoft.com";
        public static readonly string SignInPolicy = "B2C_1_Client";
        public static readonly string AuthorityBase = $"https://{TenantName}.b2clogin.com/tfp/{TenantId}/";
        public static readonly string AuthoritySignIn = $"{AuthorityBase}{SignInPolicy}";
        public static readonly string IosKeychainSecurityGroups = "com.microsoft.adalcache";
    }
}
