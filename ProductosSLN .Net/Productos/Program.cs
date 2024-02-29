using Microsoft.EntityFrameworkCore;
using Productos.Config;
using Productos.Models;
using System.Configuration;
using Productos.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.SetDatabaseConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configure CORS policy to accept requests from port 4200
app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:4200") // Allow requests from port 4200
           .AllowAnyMethod() // Allow any HTTP method (GET, POST, PUT, DELETE, etc.)
           .AllowAnyHeader(); // Allow any HTTP headers
});
// Enable CORS with named policy
app.UseCors("AllowAngularApp");

app.MapControllers();



app.Run();
