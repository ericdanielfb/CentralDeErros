using CentralDeErros.API.Extensions;

using CentralDeErros.Model.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CentralDeErros.Services
{
    public class TokenGeneratorService
    {
        private readonly AppSettings _appSettingsJWT;

        public TokenGeneratorService(IOptions<AppSettings> appSettingsJWT)
        {
            _appSettingsJWT = appSettingsJWT.Value;
        }

        public string TokenGenerator()
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettingsJWT.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
               Issuer = _appSettingsJWT.Issuer,
               Expires = DateTime.UtcNow.AddHours(_appSettingsJWT.ExpiresHours),
               SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return tokenHandler.WriteToken(token);

        }

    }
}