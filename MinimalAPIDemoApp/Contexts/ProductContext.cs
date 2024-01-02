using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinimalAPIDemoApp.Entities;

namespace MinimalAPIDemoApp.Contexts
{
    public class ProductContext: DbContext
    {
        public DbSet<Product> Products{get;set;}
        public ProductContext(DbContextOptions dbContextOptions) :base(dbContextOptions){
            Products=Set<Product>();
        }
    }
}