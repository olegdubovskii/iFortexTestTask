using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TestTask;
using TestTask.Data;
using TestTask.Extensions;
using TestTask.Services.Implementations;
using TestTask.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.InjectSwagger();
builder.Services.InjectBusinessLogicServices();
builder.Services.InjectDataAccessServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
