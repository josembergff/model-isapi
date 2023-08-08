using IdentityServer4.Models;
using IdentityServer4;
using System.Reflection.Metadata;
using System;
using Common;

namespace ModelISAuth.Config
{
    public class ConfigIdentity
    {
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = ConstantIdentity.Movies_Client_Id_Value,
                    ClientName = ConstantIdentity.Movies_Client_Name,
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RequirePkce = false,
                    AllowRememberConsent = false,
                    RedirectUris = new List<string>() { UrlIdentity.Sign_In },
                    PostLogoutRedirectUris = new List<string>() { UrlIdentity.Sign_Out },
                    ClientSecrets = new List<Secret>
                    {
                        new Secret(ConstantIdentity.Movies_Client_Secret.Sha256())
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Email,
                        ConstantIdentity.Scope_Role_Value,
                        ConstantIdentity.Scope_Movie_Api_Value
                    }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope(ConstantIdentity.Scope_Movie_Api_Value, ConstantIdentity.Scope_Movie_Api_Text)
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResources.Email(),
                new IdentityResource(ConstantIdentity.Scope_Role_Value, ConstantIdentity.Scope_Role_Text, new List<string>() { ConstantIdentity.Scope_Role_Value })
            };
    }
}
