using FluentValidation;
using GitRepositoriesClone.API.Behaviours;
using GitRepositoriesClone.API.Data;
using GitRepositoriesClone.API.Data.Dtos;
using GitRepositoriesClone.API.Features.Repositories.Commands;
using GitRepositoriesClone.API.Features.Repositories.Queries;
using GitRepositoriesClone.API.Middleware;
using GitRepositoriesClone.API.Repositories;
using GitRepositoriesClone.API.Services;
using GitRepositoriesClone.API.Validators;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source = githubclone.db"));
builder.Services.AddScoped<IRepositoryRepository,RepositoryRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>) , typeof(GenericRepository<>));
builder.Services.AddScoped<IRepositoryService, RepositoryService>();

builder.Services.AddValidatorsFromAssemblyContaining<CreateRepositoryRequestValidator>();

builder.Services.AddScoped<GetAllRepositoriesHandler>();
builder.Services.AddScoped<CreateRepositoryHandler>();




//builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateRepositoryRequestValidator>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));


builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
            )
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddScoped<AuthService>();



builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();


app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();

}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.Run();
