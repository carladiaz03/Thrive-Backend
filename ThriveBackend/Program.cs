using Microsoft.OpenApi.Models;  // ✅ Required for Swagger
using ThriveBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ThriveBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Configure PostgreSQL database connection securely
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Database connection string is missing.");
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add CORS policy to allow requests from frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") // Allow frontend origin
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials(); // Allow credentials like cookies and auth headers
        });
});

// Add controllers, Swagger, and JSON configuration
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Preserve JSON property names
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Thrive International API",
        Version = "v1",
        Description = "API documentation for Thrive International"
    });
});

// Build the application
var app = builder.Build();

// Enable Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Thrive International API v1");
    });
}

// Ensure the database is created and migrated at startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    try
    {
        dbContext.Database.Migrate();  // Automatically apply migrations
        app.Logger.LogInformation("Database migration applied successfully.");
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An error occurred while applying database migrations.");
    }
}

// Use CORS before other middleware
app.UseCors("AllowFrontend");

// Middleware pipeline
// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Add a default route for testing
app.MapGet("/", () => "Welcome to the Thrive International API!");

// Start the application and log success
app.Logger.LogInformation("Starting ThriveBackend API...");

try
{
    app.Run();
}
catch (Exception ex)
{
    app.Logger.LogCritical(ex, "Application failed to start.");
}
