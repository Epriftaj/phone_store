namespace PROJECT_FINAL.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PROJECT_FINAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PROJECT_FINAL.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PROJECT_FINAL.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var adminRole = "Administrator";
            var user = "SimpleUser";

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);


            if (!roleManager.RoleExists(adminRole))
            {

                var role1 = new IdentityRole()
                {
                    Name = adminRole
                };
                roleManager.Create(role1);

                var role2 = new IdentityRole()
                {
                    Name = user
                };
                roleManager.Create(role2);

                var adminUser = new ApplicationUser()
                {
                    Email = "admin@gmail.com",
                    UserName = "admin@gmail.com",
                    FirstName = "Admin",
                    LastName = "Admini",
                    Birthday = "01/01/1997",
                    PhoneNumber = "0697256379"
                };
                userManager.Create(adminUser, "Admin@123");

                userManager.AddToRole(adminUser.Id, adminRole);
            }

        }
    }
    
}
