using Microsoft.EntityFrameworkCore;
using ReversiRestApi.Controllers;
using ReversiRestApi.Data;
using ReversiRestApi.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ISpelRepository, SpelRepositoryDB>();
//builder.Services.AddControllers().AddNewtonsoftJson()
builder.Services.AddDbContext<ReversiContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ReversiDatabase")));

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
