using Microsoft.EntityFrameworkCore;
using ModelISAPI.Data;
using Common;
using System.Reflection.Metadata;
using Microsoft.IdentityModel.Tokens;
using System.Security.Policy;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ModelISAPIContext>(options =>
    options.UseInMemoryDatabase("ModelISAPI"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((SwaggerGenOptions swaggerGenOptions) =>
{
    swaggerGenOptions.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "Model IS Api",
                Version = "v1.0",
            });

    swaggerGenOptions.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example in value input: \"Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    swaggerGenOptions.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                        new string[] { }
                    }
                });
});

builder.Services.AddAuthentication(ConstantIdentity.Authentication_Scheme_Bearer)
                .AddJwtBearer(ConstantIdentity.Authentication_Scheme_Bearer, options =>
                {
                    options.Authority = UrlIdentity.Identity_Server;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(ConstantIdentity.Client_Id_Policy, policy => policy.RequireClaim(ConstantIdentity.Notes_Client_Id_Key, ConstantIdentity.Notes_Client_Id_Value));
});

var app = builder.Build();

ModelISAPIContextSeed.SeedDatabase(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
