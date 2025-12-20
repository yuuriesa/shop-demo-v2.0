using Microsoft.AspNetCore.Mvc;
using shop_demo_v2.Repository;
using ShopDemo.Data;
using ShopDemo.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers()
    .AddJsonOptions(c => c.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull);
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddScoped<IRepositoryBase<Customer>, RepositoryBase<Customer>>();

builder.Services.Configure<ApiBehaviorOptions>(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState
            .Where(e => e.Value.Errors.Count > 0)
            .SelectMany(e => e.Value.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();

            return new BadRequestObjectResult(error: errors);
        };
    }
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
app.Run();

public partial class Program()
{
    
}