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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<ProductTypes> ProductTypes { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Lists> Lists { get; set; }

        
       

        internal static string ToList()
        {
            throw new NotImplementedException();
        }

        internal static object Where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
