using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
//IConfiguration
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        //Read-only
        //IConfiguration: WebAPI'mizdeki appsetting.json **okumaya** yarar
        private TokenOptions _tokenOptions;
        
        private DateTime _accessTokenExpiration;
        //Access token geçersizleşmesi
        
        //ctor yapısı
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration; //injection
            
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            //Section : WebAPI'de Appsetting.json'ın içindeki her süslü parantezle ayrılan alana denir.
            //TokenOptions section'daki bilgiyi alıp TokenOptions nesnesine aktarır.
        }

        //ITokenHelper method
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            //10 dk ekledik
            
            //Standart kod olduğu için SecurityKeyHelper class'ı oluşturduk. (IdentityModel'dan gelir.)
            // var securityKey = new SymetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey))
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            //ClaimExtensions ile bu şekilde yazabiliyoruz.
            claims.AddNameIdentifier(user.UserId.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
