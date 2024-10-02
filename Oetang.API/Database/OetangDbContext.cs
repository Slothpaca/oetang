using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Oetang.API.Domain;

namespace Oetang.API.Database
{
    public class OetangDbContext : DbContext
    {
        public OetangDbContext(DbContextOptions<OetangDbContext> options) : base(options)
        { }
            
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasMany(p => p.Consultants).WithMany();
            modelBuilder.Entity<Customer>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<Project>()
                .HasDiscriminator<string>("Type")
                .HasValue<Project>("Internal")
                .HasValue<CustomerProject>("External");

            modelBuilder.Entity<TimesheetAction>()
                .HasDiscriminator<string>("Type")
                .HasValue<TimesheetOpenedAction>("Opened")
                .HasValue<TimesheetSubmittedAction>("Submitted")
                .HasValue<TimesheetApprovedAction>("Approved")
                .HasValue<TimesheetRejectedAction>("Rejected")
                .HasValue<TimesheetCommentAddedAction>("Comment Added")
                .HasValue<TimesheetEntryAddedAction>("Entry Added");
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(100);

            configurationBuilder.Conventions.Remove(typeof(CascadeDeleteConvention));
            configurationBuilder.Conventions.Remove(typeof(SqlServerOnDeleteConvention));
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }
    }
}
