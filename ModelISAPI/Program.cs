using Microsoft.EntityFrameworkCore;
using ModelISAPI.Data;
using ModelISAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ModelISAPIContext>(options =>
    options.UseInMemoryDatabase("ModelISAPI"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

ModelISAPIContextSeed.SeedDatabase(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapNoteEndpoints();

app.Run();
