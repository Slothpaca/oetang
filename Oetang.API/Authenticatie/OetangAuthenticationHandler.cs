using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Oetang.API.Database;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Oetang.API.Authenticatie
{
    public class OetangAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        const string HeaderName = "Oetang-User";
        private readonly OetangDbContext dbContext;

        public OetangAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            OetangDbContext dbContext)
            : base(options, logger, encoder)
        {
            this.dbContext = dbContext;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey(HeaderName))
            {
                return AuthenticateResult.Fail($"Authentication header \"{HeaderName}\" not found.");
            }

            var emailAddress = Request.Headers[HeaderName].ToString();
            var user = dbContext.User.SingleOrDefault(user => user.EmailAddress == emailAddress);

            if (user == null)
            {
                return AuthenticateResult.Fail($"User \"{emailAddress}\" not found.");
            }

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.EmailAddress),
            new Claim(ClaimTypes.Name, user.FullName)
        };

            foreach (var role in user.Roles)
            {
                var roleClaim = new Claim(ClaimTypes.Role, role);
                claims.Add(roleClaim);
            }

            var claimsIdentity = new ClaimsIdentity(claims, nameof(OetangAuthenticationHandler));
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(claimsIdentity), Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
