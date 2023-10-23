using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using TestingApplication.Authentication;
using TestingApplication.Data;
using TestingApplication.Libraries.Repository;
using TestingApplication.Libraries;
using TestingApplication.Library.Repository;
using TestingApplication.Services;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Key Auth", Version = "v1" });
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "ApiKey must appear in header",
        Type = SecuritySchemeType.ApiKey,
        Name = "x-api-key",
        In = ParameterLocation.Header,
        Scheme = "ApiKeyScheme"
    });
    OpenApiSecurityScheme? key = new()
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "ApiKey"
        },
        In = ParameterLocation.Header
    };
    OpenApiSecurityRequirement? requirement = new()
    {
        { key, new List<string>() }
    };
    c.AddSecurityRequirement(requirement);
});

//Services
builder.Services.Configure<ApplicationDbSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddSingleton<MyMongoRepository>();
builder.Services.AddSingleton<IFileManager, FileManager>();
//Services based on Models.
builder.Services.AddSingleton<CompanyService>();

//Authorization & Authentication add here.
builder.Services.AddScoped<ApiKeyAuthFilter>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddAutoMapper(typeof(Program));

WebApplication? app = builder.Build();
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
