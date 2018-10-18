using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ConsoleApp.NewDb {
    public class UserContext : DbContext {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Users;Trusted_Connection=True;");
        }
    }

   

}