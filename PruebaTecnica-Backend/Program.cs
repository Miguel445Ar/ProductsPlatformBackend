using PruebaTecnica_Backend.Products.Domain.Repositories;
using PruebaTecnica_Backend.Products.Domain.Services;
using PruebaTecnica_Backend.Products.Persistence.Repositories;
using PruebaTecnica_Backend.Products.Services;
using PruebaTecnica_Backend.Shared.Domain.Repositories;
using PruebaTecnica_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PruebaTecnica_Backend.Shared.Persistence.Contexts;
using PruebaTecnica_Backend.Orders.Domain.Repositories;
using PruebaTecnica_Backend.Orders.Persistance.Repositories;
using PruebaTecnica_Backend.Orders.Domain.Services;
using PruebaTecnica_Backend.Orders.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddCors();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors();

});


builder.Services.AddRouting(options =>
    options.LowercaseUrls = true);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddAutoMapper(
    typeof(PruebaTecnica_Backend.Shared.Mapping.ModelToResourceProfile),
    typeof(PruebaTecnica_Backend.Shared.Mapping.ResourceToModelProfile)
    );

var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetRequiredService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
