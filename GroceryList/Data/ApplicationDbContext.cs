using System;
using System.Collections.Generic;
using System.Text;
using GroceryList.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GroceryList.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        internal object products;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductTypes> ProductTypes { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
