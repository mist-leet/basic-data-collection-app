using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TraineeDataCollection.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base("DefaultConnection")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TraineeForm> TraineeForms { get; set; }
    }

    public class UserDbInitializer : DropCreateDatabaseAlways<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            context.Roles.Add(new Role { Id = 1, Name = "admin" });
            context.Roles.Add(new Role { Id = 2, Name = "user" });

            context.TraineeForms.Add(new TraineeForm());

            context.Users.Add(new User
            {
                Id = 1,
                Email = "admin",
                Password = "admin",
                RoleId = 1  
            });

            context.Users.Add(new User
            {
                Id = 1,
                Email = "user",
                Password = "user",
                RoleId = 2
            });

            base.Seed(context);
        }
    }

}