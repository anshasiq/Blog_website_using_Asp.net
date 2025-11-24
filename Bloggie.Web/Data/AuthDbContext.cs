using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "1",
                    Name = "ADMIN",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin"
                },
                new IdentityRole
                {
                    Id = "3",
                    Name = "User",
                    NormalizedName = "User"
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            //var SuperAdminUser = new IdentityUser
            //{
            //    Id = "100",
            //    UserName = "superadmin",
            //    NormalizedUserName = "superadmin",
            //    Email = "superadmin@bloge.com",
            //};
            //SuperAdminUser.PasswordHash =
            //new PasswordHasher<IdentityUser>().HashPassword(SuperAdminUser, "SuperAdmin@123");
            //builder.Entity<IdentityUser>().HasData(SuperAdminUser);


            //var superAdminUserRole = new List <IdentityUserRole<string>>
            //{
            //    new IdentityUserRole<string>
            //    {
            //        RoleId = "2",
            //        UserId = "100"
            //    },
            //    new IdentityUserRole<string>
            //    {
            //        RoleId = "1",
            //        UserId = "100"
            //    },
            //    new IdentityUserRole<string>
            //    {
            //        RoleId = "3",
            //        UserId = "100"
            //    }

            //};
            //builder.Entity<IdentityUserRole<string>>().HasData(superAdminUserRole);

        }
    }
}