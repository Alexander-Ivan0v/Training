using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Training.Authentication.Jwt
{
    public class JwtTokenBuilder
    {
        private Dictionary<string, string> claims = new Dictionary<string, string>();
        private SymmetricSecurityKey securityKey;
        private string subject;
        private string issuer;
        private string audience;
        private UInt16 ttlMin;

        public JwtTokenBuilder()
        {
        }

        public JwtTokenBuilder AddSecurityKey(SymmetricSecurityKey key)
        {
            securityKey = key;
            return this;
        }
        public JwtTokenBuilder AddSubject(string sub)
        {
            subject = sub;
            return this;
        }
        public JwtTokenBuilder AddIssuer(string iss)
        {
            issuer = iss;
            return this;
        }
        public JwtTokenBuilder AddAudience(string aud)
        {
            audience = aud;
            return this;
        }
        public JwtTokenBuilder AddClaim(string key, string value)
        {
            claims.Add(key, value);
            return this;
        }

        public JwtTokenBuilder AddTTL(UInt16 t)
        {
            ttlMin = t;
            return this;
        }

        private void EnsureArguments()
        {
            if (
                this.securityKey == null ||
                string.IsNullOrEmpty(this.subject) ||
                string.IsNullOrEmpty(this.issuer) ||
                string.IsNullOrEmpty(this.audience) ||
                ttlMin < 1 || ttlMin > 180 // 3 hrs.
            )
            {
                throw new Exception("JwtTokenBuilder: Incomplete arguments for Build()");
            }
        }

        public JwtToken Build()
        {
            EnsureArguments();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, this.subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }
            .Union(this.claims.Select(item => new Claim(item.Key, item.Value)));

            var token = new JwtSecurityToken(
                              issuer: this.issuer,
                              audience: this.audience,
                              claims: claims,
                              expires: DateTime.UtcNow.AddMinutes(this.ttlMin),
                              signingCredentials: new SigningCredentials(this.securityKey, SecurityAlgorithms.HmacSha256));

            return new JwtToken(
                new JwtSecurityTokenHandler().WriteToken(token)
            );
        }
    }
}
