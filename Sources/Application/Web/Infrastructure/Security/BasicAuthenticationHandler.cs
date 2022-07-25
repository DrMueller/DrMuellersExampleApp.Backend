using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Mmu.DrMuellersExampleApp.CrossCutting.Services.Settings.Provisioning.Services;

namespace Mmu.DrMuellersExampleApp.Web.Infrastructure.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public const string MissingHeaderError = "Missing Authorization Header";
        public const string SchemeName = "BasicAuthentication";
        public const string WrongCredentialsError = "Wrong credentials";
        private readonly IAppSettingsProvider _appSettingsProvider;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IAppSettingsProvider appSettingsProvider)
            : base(options, logger, encoder, clock)
        {
            _appSettingsProvider = appSettingsProvider;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var endpoint = Context.GetEndpoint();

            if (endpoint?.Metadata.GetMetadata<IAllowAnonymous>() != null)
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.Fail(MissingHeaderError));
            }

            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);

            if (authHeader.Parameter == null)
            {
                return Task.FromResult(AuthenticateResult.Fail(MissingHeaderError));
            }

            var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
            var username = credentials[0];
            var password = credentials[1];

            if (username != _appSettingsProvider.Settings.ApiUserName || password != _appSettingsProvider.Settings.ApiPassword)
            {
                return Task.FromResult(AuthenticateResult.Fail(WrongCredentialsError));
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, "Tmp"),
                new Claim(ClaimTypes.Name, username)
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}