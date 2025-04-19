using Microsoft.EntityFrameworkCore;
using ProjetoDBZ.src.Infrastructure.Persistence;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ProjetoDBZ.src.Core.Interfaces;
using ProjetoDBZ.src.Infrastructure.Repositories;
using ProjetoDBZ.src.Infrastructure.Identity;
using ProjetoDBZ.src.Application.Services;
using ProjetoDBZ.src.Shared.Configuration;
using ProjetoDBZ.src.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Configuração do Banco MySQL
var connectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Injeção de Dependências
builder.Services.AddScoped<IPersonagemRepository, PersonagemRepository>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<PersonagemService>();

// // JWT Authentication
builder.Services.AddJwtAuthentication(builder.Configuration);

// builder.Services.AddAuthentication(opt =>
// {
//     opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// })
// .AddJwtBearer(opt =>
// {
//     opt.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuer = true,
//         ValidateAudience = true,
//         ValidateLifetime = true,
//         ValidateIssuerSigningKey = true,
//         ValidIssuer = "DBZ",
//         ValidAudience = "DBZ",
//         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("kTHdMNbEKC1YeCMDei1dFdWMAXakiI3mXQKFuivJOJVtDrQ8YxCEJeUQEFEIea5FeBuhfBAHnz24wbK4HsJmtwDIRsSCoZARbmTV3y3HhCARPXnzCerz7hSHm1EnkqhVdFAVRfIazsZrrjaIPrSKlqOLXKEWRB8VJMX0jzNvWJufOwpkCsVrEyE362vSx9byiAmAqqgDvJiGkujEQRwxBgzsjZd7CiTnA4XBbvQHo4XAv9QESdy3t4B2NjM8v3MR"))
//     };
// });

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Estudos API",
        Version = "v1"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Insira o token JWT",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { } }
    });
});

// Binding JWT settings from appsettings.json
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Estudos API");
        options.RoutePrefix = "swagger"; // Mantém em /swagger
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
