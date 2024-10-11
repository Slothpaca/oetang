// Include needed namespaces.
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Oetang.API.Domain;


namespace Oetang.API.Database
{

    // This class represents the database context for the application, allowing access to the database tables.
    public class OetangDbContext : DbContext
    {

        // Constructor that accepts options (like connection strings) and passes them to the base DbContext class.
        public OetangDbContext(DbContextOptions<OetangDbContext> options) : base(options)
        { }


        // This method is called when the model is being created, allowing customization of the entity mappings.
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {

            // In Entity Framework, a navigation property represents a relationship between two entities.
            // In this case, the Consultants property in the Project entity represents a list of consultants assigned to the project.
            modelBuilder.Entity<Project>().Metadata
                .FindNavigation(nameof(Project.Consultants))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            // Configures a many-to-many relationship between 'Project' and 'Consultants'.
            // 'WithMany()' implies that a consultant can also be associated with multiple projects.
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Consultants)
                .WithMany();

            // Ensures that the 'Name' property of the 'Customer' entity is unique by adding a unique index.
            modelBuilder.Entity<Customer>()
                .HasIndex(x => x.Name)
                .IsUnique();
        }


        // This method allows configuring global conventions for the database, such as data types or constraints.
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {

            // Configures all properties of type string in the entire model to have a maximum length of 100 characters.
            configurationBuilder.Properties<string>().HaveMaxLength(100);

            // Removes the CascadeDeleteConvention (Prevent the deletion of child entities when a parent entity gets deleted).
            // This means that cascade deletes won't be configured by default.
            configurationBuilder.Conventions.Remove(typeof(CascadeDeleteConvention));

            // Removes the SqlServerOnDeleteConvention, which configures the delete behavior for SQL Server databases.
            // Turns off that if you delete a record in a parent table, the related records in the child table will also be deleted automatically.
            configurationBuilder.Conventions.Remove(typeof(SqlServerOnDeleteConvention));
        }


        // DbSet properties represent tables in the database and allow querying and saving instances of the entities.
        public DbSet<Department> Departments { get; set; }  // Represents the 'Departments' table.    
        public DbSet<Customer> Customers { get; set; }      // Represents the 'Customer' table.
        public DbSet<User> User { get; set; }               // Represents the 'User' table.
        public DbSet<Consultant> Consultants { get; set; }  // Represents the 'Consultants' table.
        public DbSet<Project> Projects { get; set; }        // Represents the 'Projects' table.
        public DbSet<Timesheet> Timesheets { get; set; }    // Represents the 'Timesheets' table.
    }
}
