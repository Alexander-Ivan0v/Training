// https://www.c-sharpcorner.com/article/asp-net-core-2-0-bearer-authentication/
// https://stackoverflow.com/questions/45686477/jwt-on-net-core-2-0

using System;
using Training.Authentication;
using Training.Authentication.Jwt;
using Training.Authentication.MyAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Training.Authentication.Input;
using Training.Authentication.Output;
using Microsoft.Extensions.Logging;

namespace Training.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly int _currentUser;
        private readonly IConfiguration _config;
        private readonly IMyAuth _auth;
        ILogger _logger;
        //private readonly IUserManager _userManager;

        public AuthController(ILogger logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IMyAuth auth /*, IUserManager userManager*/)
        {
            _currentUser = httpContextAccessor.CurrentUser();
            _config = configuration;
            _auth = auth;
            _logger = logger;
            //_userManager = userManager;
        }

        // POST /api/v1/auth
        [HttpPost]
        public IActionResult Auth(Login auth)
        {
            _logger.LogInformation("sdfadasdasdasd");

            UInt16 ttl = UInt16.TryParse(_config["Jwt:ExpiresMinutes"], out var tmp) ? tmp : UInt16.Parse("15");
            if (_auth.Authorize(auth.login, auth.pass))
            {   
                var token = new JwtTokenBuilder()
                                    .AddSecurityKey(JwtSecurityKey.Create(_config["Jwt:Secret"]))
                                    .AddSubject(_config["Jwt:Subject"])
                                    .AddIssuer(_config["Jwt:Issuer"])
                                    .AddAudience(_config["Jwt:Audience"])
                                    .AddClaim("MembershipId", "111")
                                    .AddTTL(ttl)
                                    .Build();

                return Ok(new Token(token.value));
            }
            else {
                return Unauthorized();
            }
        }
    }
}