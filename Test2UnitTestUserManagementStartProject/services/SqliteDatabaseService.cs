using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2UnitTestUserManagementStartProject.services
{
    public class SqliteDatabaseService : DbContext, IDatabaseService
    {
        private DbSet<User> Users { get; set; }
        private string connString;
        public SqliteDatabaseService(string connectionString)
        {
            this.connString = connectionString;
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().HasData(
                new User() { Name = "Pjerrot", Id = 1 },
                new User() { Name = "dee", Id = 2 });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = connString;
            var keepAliveConnection = new SqliteConnection(connectionString);
            keepAliveConnection.Open();
            options.UseSqlite(connectionString);
            
        }
        public void SaveUser(User user)
        {
            Users.Add(user);
            SaveChanges();
        }
        public User GetUserById(int id)
        {
            return Users.Find(id);
        }

        public List<User> GetAllUsers()
        {
            return Users.ToList();
        }
    }


}
