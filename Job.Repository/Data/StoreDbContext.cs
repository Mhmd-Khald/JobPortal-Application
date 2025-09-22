using Job.Core.Entities;
using Job.Repository.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Job.Repository.Data
{
    public class StoreDbContext : IdentityDbContext<AppUser>
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }
        public DbSet<RateUser> rateUsers { get; set; }

        public DbSet<FreelanceJob> freelanceJobs { get; set; }
        public DbSet<Offers> Offers { get; set; }
        public DbSet<JobApplication> Application { get; set; }
        public DbSet<Jobs> jobs { get; set; }
        public DbSet<OfferCompany> OfferCompany { get; set; }






        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OfferCompany>()
           .HasOne(o => o.Sender)
           .WithMany(u => u.SentOffers)
           .HasForeignKey(o => o.SenderId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<OfferCompany>()
                .HasOne(o => o.Recipient)
                .WithMany()
                .HasForeignKey(o => o.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FreelanceJob>()
                .HasOne(j => j.User)
                .WithMany(u => u.freelanceJobs)
                .HasForeignKey(j => j.AppUserId);

            builder.Entity<RateUser>()
                  .HasOne(o => o.ratee)
                  .WithMany()
                  .HasForeignKey(o => o.rateeId)
                  .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<RateUser>()
               .HasOne(o => o.Rater)
                  .WithMany()
               .HasForeignKey(o => o.RaterId)
               .OnDelete(DeleteBehavior.Restrict);


            // builder.Entity<JobApplication>()
            //.HasKey(ja => new { ja.AppuserId, ja.JobId });

            // builder.Entity<JobApplication>()
            // .HasOne(ja => ja.user)
            // .WithMany(u => u.JobAppications)
            //  .HasForeignKey(ja => ja.AppuserId);


            // builder.Entity<JobApplication>()
            //     .HasOne(ja => ja.Jobs)
            //     .WithMany(j => j.JobAppications)
            //     .HasForeignKey(ja => ja.JobId);


            base.OnModelCreating(builder);
            builder.ConfigurationUserAndRole();

            //this.SeedUserss(builder);
            //this.SeedUserRoles(builder);



        }
        private void SeedUserss(ModelBuilder builder)
        {
            AppUser user = new AppUser()
            {
                Id = "52C70279-B3A4-4DE6-A612-F1F32875743F",
                UserName = "Admin",
                Email = "admin@gmail.com",
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                Country = "Egypt",
                City = "Cairo",
                DisplayName = "Admin",
                DateOfBirth = "1-1-2001"
            };

            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            passwordHasher.HashPassword(user, "Moh123456");

            builder.Entity<AppUser>().HasData(user);
        }
        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "59274726-3a20-4b3a-80e5-7e8b06981d2a", UserId = "52C70279-B3A4-4DE6-A612-F1F32875743F" }
                );
        }
    }
}

