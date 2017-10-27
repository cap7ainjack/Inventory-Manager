namespace InventoryManager.Data.Migrations
{
    using InventoryManager.Models.EntityModels;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InventoryManager.Data.InventoryManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "InventoryManager.Data.InventoryManagerContext";
        }

        protected override void Seed(InventoryManager.Data.InventoryManagerContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                ApplicationUser user = new ApplicationUser();
                user.Email = "admin@gmail.com";
                user.UserName = "admin@gmail.com";

                string userPWD = "admin123";

                IdentityResult createdUser = userManager.Create(user, userPWD);

                if (createdUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("Viewer"))
            {
                var role = new IdentityRole();
                role.Name = "Viewer";
                roleManager.Create(role);
            }
        }
    }
}
