using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UserApi.Services;
using UserApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");



builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<UserService>();
builder.Services.AddControllers();


var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();
app.Run();
