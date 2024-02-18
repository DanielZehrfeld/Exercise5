using Exercise5.Installer;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Exercise5.Test")]

var builder = WebApplication.CreateBuilder(args);

Installer.ConfigureServices(builder.Services);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
