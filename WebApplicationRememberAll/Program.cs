using WebApplicationRememberAll.DbConnector;
using WebApplicationRememberAll.Exceptions;
using WebApplicationRememberAll.Repositories;
using WebApplicationRememberAll.Services;
using WebApplicationRememberAll.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<CsharpGroupSlaveDbContext>();
builder.Services.AddSingleton<SlavesRepository>();
builder.Services.AddSingleton<SlavesService>();

builder.Services.AddSingleton<SlavesAddNewRequestDtoValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();