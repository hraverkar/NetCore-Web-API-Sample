using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyMDB.Data;
using MyMDB.Data.EFCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyMDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyMDBContext") ?? throw new InvalidOperationException("Connection string 'MyMDBContext' not found.")));
builder.Services.AddScoped<EfCoreMovieRepository>();
builder.Services.AddScoped<EfCoreStarRepository>();
// Add services to the container.

builder.Services.AddControllers();
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
