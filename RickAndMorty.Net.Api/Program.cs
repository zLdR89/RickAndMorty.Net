

using Microsoft.Extensions.Caching.Memory;
using RickAndMorty.Net.ServiceDI.Factory;
using RickAndMorty.Net.ServiceDI.Service;

var _allowedCorsOrigins = "_allowedCorsOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: _allowedCorsOrigins,
                      builder =>
                      {
                          builder.WithOrigins("*");
                      });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddMemoryCache();

builder.Services.AddSingleton<IRickAndMortyService>(service => RickAndMortyFactory.Create());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(_allowedCorsOrigins);
app.MapControllers();

app.Run();



