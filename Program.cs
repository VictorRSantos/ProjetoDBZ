using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{  
    app.MapOpenApi();
    // Configuraçao Swagger .NET 9
    app.UseSwaggerUI(options =>  options.SwaggerEndpoint("/openapi/v1.json", "Projeto DBZ"));

    // Configuração Scalar AspNetCore
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
