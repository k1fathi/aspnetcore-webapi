using AspnetcoreWebapi.Refactored.Startup;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.RegisterApplicationServices();

app.ConfigureMiddleware();
app.RegisterEndpoints();


//app.MapGet("/", () => "Hello World!");

app.Run();
