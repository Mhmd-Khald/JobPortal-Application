//using Job.Core.Entities;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Job.Repository.Data
//{
//    public class StoreContext: DbContext
//    {
//        public StoreContext(DbContextOptions<StoreContext> options): base(options)
//        {

//        }
        
//        public DbSet<JobSeeker> JobSeekers { get; set; }
//        public DbSet<Company> Companies { get; set; }
//        //public DbSet<JobDetails> Details { get; set; }
//        public DbSet<JobApplication> Application { get; set; }
//        public DbSet<Jobs> jobs { get; set; }
//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Jobs>(entity =>
//            {
//                entity.ToTable("jobs");
//                entity.HasMany(job => job.JobAppications)
//             .WithOne(jobApp => jobApp.Jobs)
//             .HasForeignKey(job => job.JobId);
//            });
//            modelBuilder.Entity<JobSeeker>(entity =>
//            {
//                entity.ToTable("JobSeekers");
//                //.OwnsOne(x=>x.users);
//                entity.HasMany(j => j.JobApplications)
//                .WithOne(m => m.JobSeeker)
//                .HasForeignKey(l => l.JobSeekerId);
//            });
//            //modelBuilder.Entity<Company>(entity =>
//            //{
//            //    entity.ToTable("Companies");
//            //     //.OwnsOne (x => x.company);
//            //    //entity.HasMany(company => company.JobDetails)
//            //    .WithOne(j => j.company)
//            //    .HasForeignKey(company => company.CompanyId);
//            //});
//            //modelBuilder.Entity<Skill>()
//            //     .HasMany(j => j.jobSeekers)
//            //     .WithMany(j => j.skills)
//            //     .UsingEntity<UserSkill>(
//            //          j => j
//            //          .HasOne(us => us.JobSeeker)
//            //          .WithMany(js => js.users)
//            //          .HasForeignKey(us => us.JobSeekerId),
//            //           j => j
//            //           .HasOne( us => us.Skills)
//            //           .WithMany(js=>js.userSkills)
//            //           .HasForeignKey(j=>j.SkillId),
//            //           j=> j.HasKey (t=>new { t.JobSeekerId, t.SkillId })

//            //    );
             

//        }


//    }
//}
