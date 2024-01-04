using AgendaBlueApi.Data;
using AgendaBlueApi.Mappers;
using AgendaBlueApi.Repository;
using AgendaBlueApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var stringConexao = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AgendaContext>(options =>
            options.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao)));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AgendaBlue.API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "André Albuquerque",
            Email = "andreguigo@gmail.com"
        }
    });
});

builder.Services.AddControllers();
builder.Services.AddScoped<IAgendaRepository, AgendaRepository>();
builder.Services.AddScoped<IAgendaService, AgendaService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AgendaBlue.API v1"));
}

app.MapControllers();

app.Run();
