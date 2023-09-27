using Microsoft.OpenApi.Models;
using Products.Dapper.WebAPI.Business;
using Products.Dapper.WebAPI.Business.Implementations;
using Products.Dapper.WebAPI.Data;
using Products.Dapper.WebAPI.Data.Implementations;
using Products.Dapper.WebAPI.Repositories;
using Products.Dapper.WebAPI.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IConnectionDataBase, SQLServerDataBase>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductBusiness, ProductBusiness>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAny", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Products Dapper WebAPI",
        Version = "v1",
        Description = "Project to manipulate a simple CRUD using Dapper.",
        Contact = new OpenApiContact
        {
            Name = "Paulo Alves",
            Email = "pj38alves@gmail.com",
            Url = new Uri("https://github.com/pauloamjdeveloper"),
        },
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAny");

app.MapControllers();

app.Run();
