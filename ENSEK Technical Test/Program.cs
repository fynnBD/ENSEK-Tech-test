using ENSEK_Technical_Test.Controllers;
using ENSEK_Technical_Test.Data;
using ENSEK_Technical_Test.Models;
using ENSEK_Technical_Test.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<EnergyAccountContext>(options => options.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=ensekDB;Integrated Security=True;TrustServerCertificate=True"));

builder.Services.AddScoped<AccountRepository>();
builder.Services.AddScoped<CSVUploadService>();
builder.Services.AddScoped<ReadingRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
