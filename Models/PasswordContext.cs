using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordGeneratorApp.Models
{
    public class PasswordContext : DbContext
    {
        public PasswordContext(DbContextOptions<PasswordContext> options) : base(options) { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Password> Passwords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person { PersonId = 1, FirstName = "Tyler", LastName = "Hochstetler" }
            );
            modelBuilder.Entity<Password>().HasData(
                new Password { PasswordId = 1, SiteURL = "www.gmail.com", SitePassword = "t3stPassword!", CreateDate = DateTime.Parse("08/01/2021"), PersonId = 1}
            );
        }
    
    }
}
