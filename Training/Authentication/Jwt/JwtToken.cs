using System.IdentityModel.Tokens.Jwt;

namespace Training.Authentication.Jwt
{
    public class JwtToken
    {
        public string value;
        public JwtToken(string token)
        {
            value = token;
        }
    }
}
