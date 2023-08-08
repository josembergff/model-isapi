using IdentityServer4.Models;
using IdentityServer4;
using Common;
using IdentityModel;
using IdentityServer4.Test;
using System.Security.Claims;
using System.Text.Json;

namespace ModelISAuth.Config
{
    public class ConfigIdentity
    {
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = ConstantIdentity.Notes_Client_Id_Value,
                    ClientName = ConstantIdentity.Notes_Client_Name,
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    RequirePkce = false,
                    AllowRememberConsent = false,
                    RedirectUris = new List<string>() { UrlIdentity.Sign_In },
                    PostLogoutRedirectUris = new List<string>() { UrlIdentity.Sign_Out },
                    ClientSecrets = new List<Secret>
                    {
                        new Secret(ConstantIdentity.Notes_Client_Secret.Sha256())
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Email,
                        ConstantIdentity.Scope_Role_Value,
                        ConstantIdentity.Scope_Note_Api_Value
                    }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope(ConstantIdentity.Scope_Note_Api_Value, ConstantIdentity.Scope_Note_Api_Text)
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

        public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource>
            {
                new ApiResource("ModelISAPI", "Model IS API")
                {
                    ApiSecrets = { new Secret("secret".Sha256()) },

                    Scopes = { "ModelISAPI", "profile", "openid", "email" }
                }
            };

        public static List<TestUser> TestUsers
        {
            get
            {
                var address = new
                {
                    street_address = "One Hacker Way",
                    locality = "Heidelberg",
                    postal_code = 69118,
                    country = "Germany"
                };

                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "1",
                        Username = "alice",
                        Password = "alice",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Alice Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Alice"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "11",
                        Username = "bob",
                        Password = "bob",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Bob Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Bob"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    }
                };
            }
        }

    }
}
