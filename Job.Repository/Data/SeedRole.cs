using Job.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Repository.Data
{
    public static class SeedRole
    {
        public static void ConfigurationUserAndRole(this ModelBuilder modelBuilder)
        {
            //var roleId = Guid.NewGuid().ToString();
            //var userId = Guid.NewGuid().ToString();
            //var hasher = new PasswordHasher<IdentityUser>();

            // Seeding the "Admin" role
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                }
            );

            // Seeding the "Company" role
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "2c5e174e-3b0e-446f-86af-483d56fd7211",
                    Name = "company",
                    NormalizedName = "Company".ToUpper()
                }
            );

            // Seeding the "User" role
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "2c5e174e-3b0e-446f-86af-483d56fd7212",
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                }
            );
            var hasher = new PasswordHasher<IdentityUser>();
            // Seeding the "Admin" user
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserName = "Admin123@gmail.com",
                    Email = "Admin123@gmail.com",
                    Country = "Egypt",
                    City = "Cairo",
                    NormalizedUserName = "Admin123@gmail.com".ToUpper(),
                    NormalizedEmail = "Admin123@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "Admin123"),
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            );

          

            // Seeding the relation between the "Admin" user and role
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                }
            );
        }
    }
}

