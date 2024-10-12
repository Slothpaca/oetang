namespace Oetang.API.Domain
{
    public class User
    {
        // Underneath is the "default constructor" defined -> "private User()".
        // (If no constructors are defined in code, then a default constructer will be created implicitly by the compiler.)

        // If a constructor is defined explicitly (see "public User" constructor under the "private User" constructor),
        // then you are obligated to define a default constructor in code (does not have to be public, can be private).

        private User() { } // Defining the default constructor.


        public User(string name, string surname, string emailAddress) // Defining a Department constructor.
        {
            // More validation, calling this constructor requires the following to be checked:

            // The first name of the user cannot be empty or null.
            if (string.IsNullOrWhiteSpace(name))
                throw new BadHttpRequestException("A name is required when creating a new user.");

            // The last name of the user cannot be empty or null.
            if (string.IsNullOrWhiteSpace(surname))
                throw new BadHttpRequestException("A surname is required when creating a new user.");

            // The email address for the user cannot be empty or null.
            if (string.IsNullOrWhiteSpace(emailAddress))
                throw new BadHttpRequestException("An email address is required when creating a new user.");

            // After validation, fill in the following properties using the given parameters.

            Name = name;
            Surname = surname;
            EmailAddress = emailAddress;
        }


        // Define all properties.
        public long Id { get; private set; }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string EmailAddress { get; private set; }

        public List<string> Roles { get; private set; }
        public string FullName => $"{Name} {Surname}";


        // Method can be called in a handler to make a user department head. (If the role "DepartmentManager" is not already in the list of roles, then add the role.)
        public void MakeDepartmentHead()
        {
            if (!HasDepartmentHeadRole())
            {
                Roles.Add(UserRoles.DepartmentManager);
            }
            else
            {
                //throw new InvalidOperationException("User is already a department manager.");
            }

        }
        public bool HasDepartmentHeadRole()
        {
            // The part "Contains" already returns either true or false, this way no if/else is required.
            return Roles.Contains(UserRoles.DepartmentManager);

        }
        public void RemoveDepartmentHeadRole()
        {
            if (HasDepartmentHeadRole())
            {
                Roles.Remove(UserRoles.DepartmentManager);
            }
        }
    }


    // All possible roles that a user can have, are defined here.
    public static class UserRoles
    {
        public const string Administrator = nameof(Administrator);
        public const string Consultant = nameof(Consultant);
        public const string DepartmentManager = nameof(DepartmentManager);
    }
}
