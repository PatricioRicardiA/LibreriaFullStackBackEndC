using LibreriaFullStackBackEndinC.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => { options.AddPolicy("AllowSpecificOrigin", 
    builder => { builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod(); }); });

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("Con");
builder.Services.AddDbContext<BookDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

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
