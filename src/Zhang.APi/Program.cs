using Zhang.APi.Modules;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var config = builder.Configuration;
var host = builder.Host;

services.ReplaceConfiguration(config);

services.AddApplication<ApiModule>();

host.UseAutofac();

var app = builder.Build();
app.InitializeApplication();