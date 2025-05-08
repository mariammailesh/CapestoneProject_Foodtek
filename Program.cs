using CapestoneProject.Models;
//using CapestoneProject.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CapestoneProject.Interfaces;
using Microsoft.OpenApi.Models;
using System.Diagnostics;
using Serilog;
using CapestoneProject.Helpers;
using Microsoft.AspNetCore.Authentication;
using System.Reflection;
using CapestoneProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo    //static information 
    {
        Version = "v1",
        Title = "Capstone API",
        Description = "The E-Single Restaurant Management System is a web-based application designed to streamline operations for a single restaurant. It efficiently handles customer orders, order processing, item availability, and customer feedback.",
    });
    
    // using System.Reflection;     Not change
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


// Setup Log file for Debug/Trace output (low-level runtime logs)
var debugLogFilePath = "Logs/debug-output.txt";
Directory.CreateDirectory("Logs");
var debugLogFileStream = new FileStream(debugLogFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
var debugLogWriter = new StreamWriter(debugLogFileStream) { AutoFlush = true };
Trace.Listeners.Clear();
Trace.Listeners.Add(new TextWriterTraceListener(debugLogWriter));

// Configure Serilog (normal app logs)
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Log immediately after setting Logger
Log.Information("***** Application is starting (before Build) *****");

builder.Host.UseSerilog();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ESingleRestaurantManagementSystemContext>();

// Add Authentication and Authorization with JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();

//builder.Services.AddSingleton<TokenProvider>();

// After adding services, log them
foreach (var service in builder.Services)
{
    Log.Information($"Service Registered: {service.ServiceType.FullName} -> {service.ImplementationType?.FullName}");
}

builder.Services.AddScoped<IEmailServices, DummyEmailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.


    app.UseSwagger();
app.UseSwaggerUI();
//comment the following code when you want to test it on IIS local device, and keep it when you want to publish it 

//app.UseSwaggerUI(c =>
//    {
//        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CapstonePRojectFoodtek");
//        c.RoutePrefix = string.Empty;
//    }
//);



app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
