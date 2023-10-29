using CL2_MiguelHuaman.Exceptions;
using CL2_MiguelHuaman.Models;
using CL2_MiguelHuaman.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("CL2");
builder.Services.AddDbContext<CL2Context>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IAccountRepository, AccountRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
//
app.UseMiddleware(typeof(GlobalExceptionsHandler));
//
app.MapControllers();

app.Run();
