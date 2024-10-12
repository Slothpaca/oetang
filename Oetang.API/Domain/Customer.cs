namespace Oetang.API.Domain
{
    public class Customer
    {
        // Underneath is the "default constructor" defined -> "private Customer()".
        // (If no constructors are defined in code, then a default constructer will be created implicitly by the compiler.)

        // If a constructor is defined explicitly (see "public Customer" constructor under the "private Customer" constructor),
        // then you are obligated to define a default constructor in code (does not have to be public, can be private).

        private Customer(){ } // Defining the default constructor.

        public Customer(string name) // Defining a Customer constructor.
        {
            // More validation, calling this constructor requires the following to be checked:

            // If the name is empty, then throw an error
            if (name == null)
                throw new BadHttpRequestException("A customer name is required!");

            // After validation, fill in the following properties using the given parameters.
            Name = name;
        }


        // Define all properties.
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
