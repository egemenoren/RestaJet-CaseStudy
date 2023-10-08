using CaseStudy.Application.CQRS;
using CaseStudy.Application.Validation;
using CaseStudy.Core.Interfaces;
using CaseStudy.Core.Services.Abstract;
using CaseStudy.Core.Services.Concrete;
using CaseStudy.ExternalServices;
using CaseStudy.ExternalServices.Product;
using CaseStudy.Infrastructure.DbContexts;
using CaseStudy.Infrastructure.Repository.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<AddCartItemValidator>();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

//Dependencies
services.AddScoped<ICartItemRepository, CartItemRepository>();
services.AddScoped<ICartRepository, CartRepository>();
services.AddScoped<ICartService, CartService>();
services.AddScoped<ICartItemService, CartItemService>();
services.AddScoped<IProductService, ProductService>();
services.AddScoped<IOrderService, OrderService>();
services.AddScoped<RestSharpService>();

builder.Services.AddDbContext<CaseStudyDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"), configure =>
    {
        configure.MigrationsAssembly("CaseStudy.Infrastructure");
    });
});

//AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//MediatR
services.AddMediatR(x =>
{
    x.Lifetime = ServiceLifetime.Scoped;
    x.RegisterServicesFromAssemblies(typeof(CreateCartCommand).GetTypeInfo().Assembly);
});








var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
