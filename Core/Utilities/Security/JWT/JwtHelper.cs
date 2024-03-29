﻿using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }//api'dekli appsettings okumaya yarar, değerleri okur..(IConfiguration)
        private TokenOptions _tokenOptions; //apideki değerlerin karşılığı olan nesneye atılır
        private DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();//appsettings içindeki TokenOptions'u al ve şu TokenOptions sınafın değerlerini kullanırak map'le 

        }



        public AccessToken CreatToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);//Token ne zaman biteceğini belirler 
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);//securitykey oluşturulur
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);//algoritma ve hangi anahtar 
            var jwt = CreateJwtSecurityToken(_tokenOptions,user,signingCredentials,operationClaims);
            var jwtSecurityTokenHanler = new JwtSecurityTokenHandler();//elimizdeki token bilgisi yazılacak 
            var token = jwtSecurityTokenHanler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer:tokenOptions.Issuer,
                audience:tokenOptions.Audience,
                expires:_accessTokenExpiration,
                notBefore:DateTime.Now,//şuandan önceki değerler verelemez
                claims:SetClaims(user,operationClaims),//claims ler 
                signingCredentials:signingCredentials
                );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());//operationClaims list oolduğu için array cevirildi

            return claims;
            
        }
    }
}
