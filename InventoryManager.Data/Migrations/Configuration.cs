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

            //Cloths seed

            context.Clothes.AddOrUpdate(course => course.Name, new Cloth[]
            {
                new Cloth()
                {
                    Name = "Parka",
                    Type = Models.Enums.ClothTypes.Coat,
                    Size = Models.Enums.ClothSize.L,
                    Price = 200,
                    Quantity = 8,
                    Descripton = "Best choice for cold witner",
                    PictureUrl = "http://d3d71ba2asa5oz.cloudfront.net/12013664/images/lmj7805_khaki.jpg"
                },

                new Cloth()
                {
                    Name = "Leather Jacket",
                    Type = Models.Enums.ClothTypes.Jacket,
                    Size = Models.Enums.ClothSize.M,
                    Price = 68.00m,
                    Quantity = 6,
                    Descripton = "Nice leather jacket",
                    PictureUrl = "http://trendyleatherjacket.com/wp-content/uploads/2014/04/BLACK-RIVET.png"
                },

                new Cloth()
                {
                    Name = "Stylish Shirt",
                    Type = Models.Enums.ClothTypes.Shirt,
                    Size = Models.Enums.ClothSize.S,
                    Price = 22.00m,
                    Quantity = 12,
                    Descripton = "Stylish casual shirt",
                    PictureUrl = "https://i.s-jcrew.com/is/image/jcrew/02337_WD9388?$pdp_fs418$"
                },

                new Cloth()
                {
                    Name = "Cat T-Shirt",
                    Type = Models.Enums.ClothTypes.TShirt,
                    Size = Models.Enums.ClothSize.XL,
                    Price = 15.00m,
                    Quantity = 5,
                    Descripton = "Ice cream T-Shirt",
                    PictureUrl = "https://ctl.s6img.com/society6/img/1BYNF9lDk9fhFEXcpPJnt2HYgW4/h_550,w_550/tshirts/men/greybg/black/~artwork,bg_FFFFFFFF/s6-0086/a/33630461_7417944/~~/cats-ice-cream-tshirts.jpg"
                }
            });

        }
    }
}
