using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace Mariner.WebAPI.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IConfiguration _configuration;

        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger,
            UrlEncoder encoder, ISystemClock clock,IConfiguration configuration) : base(options, logger, encoder, clock)
        {
            this._configuration = configuration;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            try
            {

                var authHeader = AuthenticationHeaderValue.Parse(Request?.Headers?["Authorization"]);//this will be in encrypted format
               
                
                if (authHeader == null)
                    throw new ArgumentNullException("Invalid Credentials");

                var credentilas = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter ?? string.Empty));//admin:1234

                string[] usernamePassword = credentilas.Split(':');
                string _username = usernamePassword.FirstOrDefault();
                string _password = usernamePassword.LastOrDefault();

                if(!CheckCredentials(_username,_password))
                    throw new ArgumentNullException("Invalid Credentials");

                var claims = new List<Claim> { new Claim(ClaimTypes.Name, _username) };

                var identity = new ClaimsIdentity(claims,Scheme.Name);

                var principal = new ClaimsPrincipal(identity);

                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }
            catch (Exception ex)
            {

                return  AuthenticateResult.Fail($"Authenticaiton Failed {ex.Message}");
            }
        }

        private bool CheckCredentials(string userName, string Password)
        {
            var _username = _configuration["ApiConfiguration:ClientId"];
            var _password = _configuration["ApiConfiguration:ClientPwd"];

            return (userName.Equals(_username,StringComparison.OrdinalIgnoreCase) && Password == _password);
        }
    }
}
