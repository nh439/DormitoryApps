﻿using dormitoryApps.Shared.Model.Other;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace dormitoryApps.Server.Securites
{
    public class JwTServices
    {
        private readonly IConfiguration _config;

        public JwTServices(IConfiguration config)
        {
            _config = config;
        }
        private string GenerateJSONWebToken(LoginParameter userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
