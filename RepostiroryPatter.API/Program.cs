using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepostiroryPatter.API.Infraestructure;
using RepostiroryPatter.API.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

IConfiguration configuration = builder.Configuration;

builder.Services.AddControllers();

builder.Services.AddDbContext<ProductContext>(options =>
               options.UseSqlite(configuration.GetConnectionString("AppConnection")));


builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
