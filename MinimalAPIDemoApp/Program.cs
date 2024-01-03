using Microsoft.EntityFrameworkCore;
using MinimalAPIDemoApp.Contexts;
using MinimalAPIDemoApp.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductContext>(
    options =>
        options
            .UseMySQL(
                builder.Configuration.GetConnectionString("DefaultConnection")
                    ?? throw new ArgumentNullException(nameof(options))
            )
            .LogTo(Console.WriteLine, LogLevel.Information)
);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/products", async (ProductContext context) =>
        await context.Products.ToListAsync());

app.MapGet("/products/{id}", async (int id, ProductContext context) =>
    {
        Product? product = await context.Products.FindAsync(id);
        return product is not null ? Results.Ok(product) : Results.NotFound();
    }).WithName("GetById");

app.MapPost("/products", async (Product product,ProductContext context)=>
    {
   await context.Products.AddAsync(product);
     await context.SaveChangesAsync();
     return Results.CreatedAtRoute("GetById",new { id = product.ProductId },product);
    });

app.MapPut("/products/{id}",async (int id,Product product, ProductContext context) =>
    {
        Product? oldProduct = await context.Products.FindAsync(id);
        if( oldProduct is null) 
        {
          return  Results.NotFound();
        }
        // oldProduct.ProductId=product.ProductId;
        oldProduct.Title=product.Title;
        oldProduct.Description=product.Description;
        oldProduct.Price=product.Price;

        await context.SaveChangesAsync();
        return Results.Ok(oldProduct);

    });

app.MapDelete("/products/{id}",async (int id, ProductContext context) =>
    {
        Product? product = await context.Products.FindAsync(id);
        if( product is null) 
        {
          return  Results.NotFound();
        }
       context.Products.Remove(product);
       await context.SaveChangesAsync();
       return Results.NoContent();
    }
);

app.Run();
