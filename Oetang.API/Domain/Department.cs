using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace Oetang.API.Domain
{
    public class Department
    {
        // Underneath is the "default constructor" defined -> "private Department()".
        // (If no constructors are defined in code, then a default constructer will be created implicitly by the compiler.)

        // If a constructor is defined explicitly (see "public Department" constructor under the "private Department" constructor),
        // then you are obligated to define a default constructor in code (does not have to be public, can be private).


        private Department(){} // Defining the default constructor.


        public Department(string name, User manager) // Defining a Department constructor.
        {
            // More validation, calling this constructor requires the following to be checked:

            // If the name is empty, then throw an error
            if (name == null)
                throw new ArgumentException("A department name is required!");

            // If the ID is not found, then throw an error
            if (manager == null)
                throw new ArgumentException("The specified user does not exist.");

            // After validation, fill in the following properties using the given parameters.
            Name = name;
            Manager = manager;

            // Assign the DepartmentManager role to the user
            manager.MakeDepartmentHead(); // This will add the role if it does not exist
        }


        // Define all properties.
        public long Id { get; set; }
        public string Name { get; set; }
        public User Manager { get; set; }
    }
}
