using Microsoft.OpenApi.Models;
using TesteTecnico.Application.Autenticacao.Comandos.Login;
using TesteTecnico.Application.Autenticacao.Common.Interfaces;
using TesteTecnico.Application.Autenticacao.Common.Mappings;
using TesteTecnico.Persistence.ServiceCollectionExtensions;
using TesteTecnico.Persistence.Services;
using TesteTecnico.WebApi.Extensoes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AdicionarAutenticacaoJwt(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TesteTecnico.WebApi", Version = "v1" });
    
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT desta forma: Bearer {seu token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                In = ParameterLocation.Header,
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<LoginCommand>();
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IAutenticacaoService, AutenticacaoService>();

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
