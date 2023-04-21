﻿using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api.Helpers
{
    public class AuthHelper
    {
        private readonly IConfiguration _config;
        public AuthHelper(IConfiguration config)
        {
            _config = config;
        }
        public byte[] GetPasswordHash(string password, byte[] passwordSalt)
        {
            string passwordSaltPlusString = _config.GetSection("AppSettings:PasswordKey").Value +
                Convert.ToBase64String(passwordSalt);

            byte[] passwordHash = KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.ASCII.GetBytes(passwordSaltPlusString),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 1000000,
                numBytesRequested: 256 / 8
            );
            return passwordHash;
        }

        public string CreateToken(int userId)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("userId", userId.ToString())
            };

            SymmetricSecurityKey tokenKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _config.GetSection("AppSettings:TokenKey").Value!
                    )
                );
            SigningCredentials credentials = new SigningCredentials(
                tokenKey,
                SecurityAlgorithms.HmacSha512Signature
            );
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials,
                Expires = DateTime.Now.AddDays(1)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityToken token = handler.CreateToken(descriptor);

            return handler.WriteToken(token);
        }
    }
}
