using Api.Configuration;
using Settings;
using Settings.Interface;
using Serilog;
using Api;
// Configure application
var builder = WebApplication.CreateBuilder(args);

// Logger
builder.Host.UseSerilog((hostBuilderContext, loggerConfiguration) =>
{
    loggerConfiguration
    //.Enrich.WithCorrelationId()
    .ReadFrom.Configuration(hostBuilderContext.Configuration);
});

var settings = new ApiSettings(new SettingsSource());

// Configure services
var services = builder.Services;

services.AddHttpContextAccessor();

services.AddAppDbContext(settings);

services.AddAppHealthCheck();

services.AddAppVersions();

services.AddAppSwagger(settings);

services.AddAppCors();

services.AddAppServices();

//services.AddAppAuth(settings);

services.AddControllers().AddValidator();

services.AddRazorPages();

services.AddAutoMappers();


var app = builder.Build();

Log.Information("Starting up");

app.UseAppMiddlewares();

app.UseStaticFiles();

app.UseRouting();

app.UseAppCors();

app.UseAppHealthCheck();

app.UseSerilogRequestLogging();

app.UseAppSwagger();

//app.UseAppAuth();

app.MapRazorPages();

app.MapControllers();

app.UseAppDbContext();

app.Run();
