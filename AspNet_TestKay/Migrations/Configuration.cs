namespace AspNet_TestKay.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AspNet_TestKay.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AspNet_TestKay.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var role = context.Roles.SingleOrDefault(m => m.Name == "Admin");

            if (role == null )
            {
                context.Roles.Add(new IdentityRole { Name = "Admin" });
                context.SaveChanges();
                role = context.Roles.SingleOrDefault(m => m.Name == "Admin");
            }
           

            
            var user = context.Users.Where(m => m.Email == "ali@gmail.com").FirstOrDefault(); 

            if (user != null )
            {
                user.Roles.Add(new IdentityUserRole { RoleId = role.Id });
            }
        }
    }
}
