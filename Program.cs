using Microsoft.EntityFrameworkCore;
using ProjetoDBZ.Data;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();


var connectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{  
    // Configuraçao Swagger .NET 9
    app.UseSwaggerUI(options =>  options.SwaggerEndpoint("/openapi/v1.json", "Projeto DBZ"));

    // Configuração Scalar AspNetCore
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
