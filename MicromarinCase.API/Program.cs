using FluentValidation;
using FluentValidation.AspNetCore;
using MicromarinCase.Repositories;
using MicromarinCase.Repositories.Extensions;
using MicromarinCase.Repositories.Products;
using MicromarinCase.Services;
using MicromarinCase.Services.ExceptionHandler;
using MicromarinCase.Services.Extensions;
using MicromarinCase.Services.Products;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//default hata mesajlari
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<FluentValidationFilter>();
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true; //requried alanlarýn hata gösterimini kapatýr
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositories(builder.Configuration).AddServices(builder.Configuration);


var app = builder.Build();
app.UseExceptionHandler(x => { });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
