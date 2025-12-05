using JobApplicationEvaluation.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationEvaluation.DataAccess.Concrete.Context
{
    public class JobApplicationEvaluationContext : DbContext
    {

        public JobApplicationEvaluationContext(DbContextOptions<JobApplicationEvaluationContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Recourse> Recourses { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Status> RecourseStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Recourses)
                .WithOne(r => r.Company)
                .HasForeignKey(r => r.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Company>()
                .HasMany(c => c.Reviews)
                .WithOne(r => r.Company)
                .HasForeignKey(r => r.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<User>()
                .HasMany(u => u.Recourses)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Status>()
                .HasMany(s => s.Recourses)
                .WithOne(r => r.Status)
                .HasForeignKey(r => r.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Status>()
                .HasMany(s => s.Reviews)
                .WithOne(r => r.Status)
                .HasForeignKey(r => r.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }


    }
}
