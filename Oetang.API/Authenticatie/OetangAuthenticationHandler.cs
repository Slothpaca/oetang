// Import necessary namespaces for authentication and database access.
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Oetang.API.Database;
using System.Security.Claims;
using System.Text.Encodings.Web;


namespace Oetang.API.Authenticatie
{

    // OetangAuthenticationHandler class inherits from AuthenticationHandler, providing custom authentication logic.
    public class OetangAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {

        // Define a constant for the header name used for authentication.
        const string HeaderName = "Oetang-User";
        private readonly OetangDbContext dbContext;     // Reference to the database context.


        // Constructor for OetangAuthenticationHandler
        public OetangAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,       // Options for authentication scheme.
            ILoggerFactory logger,                                      // Logger factory for logging.
            UrlEncoder encoder,                                         // URL encoder.
            OetangDbContext dbContext)                                  // Database context for accessing user data.
            : base(options, logger, encoder)                            // Pass the parameters to the base class constructor.
        {
            this.dbContext = dbContext;                                 // Initialize the database context.
        }


        // Override the HandleAuthenticateAsync method to provide custom authentication logic.
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {

            // Check if the request contains the authentication header.
            if (!Request.Headers.ContainsKey(HeaderName))
            {
                return AuthenticateResult.Fail($"Authentication header \"{HeaderName}\" not found.");
            }


            // Retrieve the email address from the authentication header.
            var emailAddress = Request.Headers[HeaderName].ToString();

            // Look for a user in the database that matches the provided email address.
            var user = dbContext.User.SingleOrDefault(user => user.EmailAddress == emailAddress);


            // If the user is not found, return a failed authentication result.
            if (user == null)
            {
                return AuthenticateResult.Fail($"User \"{emailAddress}\" not found.");
            }


            // Create a list of claims based on the user data.
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.EmailAddress),
            new Claim(ClaimTypes.Name, user.FullName)
        };


            // Add role claims for each role assigned to the user.
            foreach (var role in user.Roles)
            {
                var roleClaim = new Claim(ClaimTypes.Role, role);       // Create a role claim.
                claims.Add(roleClaim);                                  // Add the role claim to the claims list.
            }


            // Create a ClaimsIdentity from the claims list, identifying it by the handler name.
            var claimsIdentity = new ClaimsIdentity(claims, nameof(OetangAuthenticationHandler));

            // Create an authentication ticket containing the claims principal and the authentication scheme.
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(claimsIdentity), Scheme.Name);


            // Return a successful authentication result with the authentication ticket.
            return AuthenticateResult.Success(ticket);
        }
    }
}
