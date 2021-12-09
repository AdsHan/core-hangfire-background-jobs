using BackgroundJobs.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration();
builder.Services.AddDependencyConfiguration(builder.Configuration);
builder.Services.AddSwaggerConfiguration();
builder.Services.AddHangfireConfiguration(builder.Environment, builder.Configuration);

var app = builder.Build();

app.UseApiConfiguration();
app.UseSwaggerConfiguration();
app.UseHangfireConfiguration();

app.Run();
