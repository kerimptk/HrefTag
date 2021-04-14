using BaseCore.Utilities.Extensions;
using Blog.Domain.Entities;
using Blog.Domain.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Blog.Domain.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public readonly IConfiguration Configuration;
        private readonly TokenOptions _tokenOptions;
        private readonly DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration = DateTime.UtcNow.AddDays(7);
        }
        public AccessToken CreateToken(User user, List<Role> roles)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, roles);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<Role> roles)
        {
            if (signingCredentials == null) throw new ArgumentNullException(nameof(signingCredentials));
            var key = Encoding.ASCII.GetBytes
                (Configuration["TokenOptions:SecurityKey"]);

            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                audience: tokenOptions.Audience,
                expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
                claims: SetClaims(user, roles),
                signingCredentials: new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            );
            return jwt;
        }

        private static IEnumerable<Claim> SetClaims(User user, IEnumerable<Role> roles)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddRoles(roles.Select(c => c.Name).ToArray());
            //claims.AddName(user.UserDetail.Name);
            return claims;
        }

        public class TokenOptions
        {
            public string Audience { get; set; }
            public string Issuer { get; set; }
            public int AccessTokenExpiration { get; set; }
            public string SecurityKey { get; set; }
        }
    }
}