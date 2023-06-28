using ExpenseComputer.Api.Configurations;
using ExpenseComputer.Data;
using ExpenseComputer.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));

//dependencies
builder.Services.AddTransient<ExpenseManager>();

//automapper
builder.Services.AddAutoMapper(typeof(AutomapperProfile));


var app = builder.Build();
var classList = Assembly.GetExecutingAssembly().GetTypes().Select(i => i.Name).ToList();
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
