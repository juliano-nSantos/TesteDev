using System.Text.Json.Serialization;
using API.Infra.Infra.CrossCutting.IOC.InversionOfControl;
using API.Infra.Infra.Data.Data.Context;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SqlContext>();

builder.Services
    .AddControllers()
    .AddJsonOptions(opt => {
        opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    })
    .ConfigureApiBehaviorOptions(opt => {
        opt.SuppressModelStateInvalidFilter = true;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerVersioning();
builder.Services.AddSwaggerVersionedApiExplorer();
builder.Services.AddSwaggerServiceDependency();
builder.Services.AddSwaggerDependency();

builder.Services.LoadDI();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwaggerDependency(app.Services.GetRequiredService<IApiVersionDescriptionProvider>());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
