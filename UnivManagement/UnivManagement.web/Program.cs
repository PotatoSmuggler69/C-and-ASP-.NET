using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using UnivManagement.web.Infrastructure;
using UnivManagement.web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Services for injection of controller
builder.Services.AddScoped<IStudentServices, StudentServices>();
//Adding database connection for dependency injection #1

builder.Services.AddDbContext<DBObject>(Options =>
    {
        Options.UseSqlServer(builder.Configuration["ConnectionStrings:DbCon"]);
    }
);

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
