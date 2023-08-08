var builder = WebApplication.CreateBuilder(args);

#region configure services

builder.Services.AddIdentityServer();

#endregion


var app = builder.Build();


#region configure services

app.UseRouting();
app.UseIdentityServer();


app.MapGet("/", () => "Hello World!");

#endregion

app.Run();
