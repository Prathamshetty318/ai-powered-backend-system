using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UserApi.Services;
using UserApi.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserApi.Models;
using Microsoft.AspNetCore.Diagnostics;
using UserApi.Middleware;
using UserApi.Repositories;
using UserApi.Interfaces;
using UserApi.Validators;
using UserApi.DTOs;
using FluentValidation;
using FluentValidation.AspNetCore;
using UserApi.Mappings;
using UserApi.DapperRepositories;


var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddUserSecrets<Program>();
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddScoped<TokenService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

        };
    });

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IUserDapperRepository, UserDapperRepository>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserDtoValidator>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped(typeof (IGenericRepository<>),  typeof (GenericRepository<>));  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
