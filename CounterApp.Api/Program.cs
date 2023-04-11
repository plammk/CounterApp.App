
using CounterApp.Api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.WebAssembly.Services;
using CounterApp.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IGameService, GameService>();

builder.Services.AddSingleton<IPlayerService, PlayerService>();

builder.Services.AddSingleton<IGamesList, GamesList>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseCors("Open");

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();
