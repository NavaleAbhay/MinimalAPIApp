// using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MinimalAPIDemoApp.Contexts;
using MinimalAPIDemoApp.Entities;
using Org.BouncyCastle.Crypto.Engines;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductContext>(
    options => options.
                    UseMySQL(
                        builder.Configuration.GetConnectionString("DefaultConnection")
                   ?? throw new ArgumentNullException(nameof(options))
                   )
                   .LogTo(Console.WriteLine,LogLevel.Information)
                   );

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/products",async (ProductContext product)=>
await product.Products.ToListAsync());

app.MapGet("/products/{id}",async (int id,ProductContext product)=>
await product.Products.FindAsync(id) is Product product1 ? Results.Ok(product1) :  Results.NotFound());
app.Run();
