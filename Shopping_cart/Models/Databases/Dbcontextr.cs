using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_cart.Models.Databases
{
    public class Dbcontextr : IdentityDbContext <ApplicationUser>
    {
        public Dbcontextr():base() { 
        }

        public Dbcontextr(DbContextOptions option):base(option)
        
        {  
        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-HD9LIS85;Initial Catalog=Test;TrustServerCertificate=true;Integrated Security=True;Pooling=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().HasMany(w=>w.FoodID).WithOne(w=>w.customerId);
        


            modelBuilder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.HasKey(i => new { i.LoginProvider, i.ProviderKey });
               
            });

        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Food> Foods { get; set; }
    }
}
