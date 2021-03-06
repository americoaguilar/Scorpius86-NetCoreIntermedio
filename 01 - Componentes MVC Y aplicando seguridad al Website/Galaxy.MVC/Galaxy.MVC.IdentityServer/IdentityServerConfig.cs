using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Galaxy.MVC.IdentityServer
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client> {
                new Client {
                    ClientId = "AuthWeb",
                    ClientName = "AuthWeb Demo Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = { "https://localhost:44359/signin-oidc" },
                    PostLogoutRedirectUris = new List<string> { "https://localhost:44359/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser> {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "Erick",
                    Password = "password",
                    Claims = new []
                    {
                         new Claim("name", "Erick"),
                         new Claim("nickname", "Admin")
                    }
                }
            };
        }
    }
}
