using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using WAD_12072.Models;
using System.Data.Common;
using WAD_12072.Repositories;
using System;

namespace WAD_12072.DAL
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> o) :base(o)
        {
            Database.EnsureCreated();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
