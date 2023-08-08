using IdentityServer4.Models;
using IdentityServer4.Test;

var builder = WebApplication.CreateBuilder(args);

#region configure services

builder.Services.AddIdentityServer()
    .AddInMemoryClients(new List<Client>())
    .AddInMemoryIdentityResources(new List<IdentityResource>())
    .AddInMemoryApiResources(new List<ApiResource>())
    .AddInMemoryApiScopes(new List<ApiScope>())
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
