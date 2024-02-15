using CodeBrew.LetsTravelIt.Shared.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddLetsTravelItApi();

WebApplication app = builder.Build();
app.UseLetsTravelItApi();
