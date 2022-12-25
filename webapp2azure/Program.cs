using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

// comment