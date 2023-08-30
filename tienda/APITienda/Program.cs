using APITienda.Extensions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureCors();
builder.Services.AddAppServices();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

builder.Services.AddControllers();

builder.Services.AddDbContext<TiendaContext>(optionsBuilder =>
{
    string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
