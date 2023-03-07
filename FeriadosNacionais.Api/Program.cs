using FeriadosNacionais.Domain.Mapper;
using FeriadosNacionais.Domain.Services;
using FeriadosNacionais.Infra.Data;
using FeriadosNacionais.Infra.ExternalServices;
using FeriadosNacionais.Infra.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(FeriadosMapper));
builder.Services.AddCors();

var connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<FeriadosDbContext>(o => o.UseSqlServer(connectionString));

builder.Services.AddScoped<IFeriadosService, FeriadosService>();
builder.Services.AddScoped<IFeriadosExternalService, FeriadosExternalService>();
builder.Services.AddScoped<IFeriadosDatasRepository, FeriadosDatasRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(routes => {
    routes.WithOrigins("http://localhost:3000");
    routes.AllowAnyHeader();
    routes.AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
