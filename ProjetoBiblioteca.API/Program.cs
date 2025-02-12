using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Application.Services;
using ProjetoBiblioteca.ExceptionHandler;
using ProjetoBiblioteca.Infrastructure.Persistence;
using ProjetoBiblioteca.Infrastructure.Serialization;
using ProjetoBiblioteca.Infrastructure.Serialization.ProjetoBiblioteca.Infrastructure.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<ApiExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services
    .AddApplication();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.Converters.Add(new DateFormatJsonConverter());

});

//builder.Services.AddDbContext<LibaryDbContext>(o => o.UseInMemoryDatabase("LibaryDb"));
var connectionString = builder.Configuration.GetConnectionString("BibliotecaDevCs");
builder.Services.AddDbContext<LibraryDbContext>(o => o.UseSqlServer(connectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();