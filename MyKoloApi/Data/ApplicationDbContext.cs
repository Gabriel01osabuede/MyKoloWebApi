using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyKoloApi.Models;

namespace MyKoloApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        //DbSet represents our tables
        //Type of generics collection
        //DbSet<T>
        public DbSet<User> Users { get; set; }
        public DbSet<Savings> Savings { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
