
using ENSEK_Technical_Test.Helpers;
using ENSEK_Technical_Test.Models;
using ENSEK_Technical_Test.Services;
using ENSEK_Technical_Test.Services.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<EnergyContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));

builder.Services.AddScoped<AccountRepository>();
builder.Services.AddScoped<CsvUploadService>();
builder.Services.AddScoped<ReadingRepository>();
builder.Services.AddScoped<EnergyReadingValidator>();
builder.Services.AddScoped<ReadingValidatorService>();
builder.Services.AddScoped<ReadingSaverService>();
builder.Services.AddScoped<CsvParseAndSaveService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EnergyContext>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
