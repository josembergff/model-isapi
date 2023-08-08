using IdentityServer4.Test;
using ModelISAuth.Config;

var builder = WebApplication.CreateBuilder(args);

#region configure services

builder.Services.AddIdentityServer()
    .AddInMemoryClients(ConfigIdentity.Clients)
    .AddInMemoryIdentityResources(ConfigIdentity.IdentityResources)
    .AddInMemoryApiResources(ConfigIdentity.ApiResources)
    .AddInMemoryApiScopes(ConfigIdentity.ApiScopes)
    .AddTestUsers(new List<TestUser>())
    .AddDeveloperSigningCredential()
    ;

#endregion


var app = builder.Build();


#region configure services

app.UseRouting();
app.UseIdentityServer();


app.MapGet("/", () => "Hello World!");

#endregion

app.Run();
