using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PubAPI.Repository;
using PubAPI.Service;
using PublisherData;
using System.Text.Json.Serialization;
using WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

        c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
        {
            Description = "ApiKey must appear in header",
            Type = SecuritySchemeType.ApiKey,
            Name = "XApiKey",
            In = ParameterLocation.Header,
            Scheme = "ApiKeyScheme"
        });
        var key = new OpenApiSecurityScheme()
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "ApiKey"
            },
            In = ParameterLocation.Header
        };
        var requirement = new OpenApiSecurityRequirement
        {
                 { key, new List<string>() }
        };
        c.AddSecurityRequirement(requirement);
    });
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<PubContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("PubConnection"))
    .EnableSensitiveDataLogging()
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.Configure<ApiBehaviorOptions>(options =>
{ 
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddScoped<AuthorRepository>();
builder.Services.AddScoped<AuthorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseMiddleware<ApiKeyMiddleware>();
app.MapControllers();

app.Run();
