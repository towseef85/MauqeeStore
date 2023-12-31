﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MStore.Domain.Entities.Identities;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MStore.Persistence.Mappings
{
    public class TokenService
    {
        private readonly UserManager<AppUsers> _userManager;
        private readonly IConfiguration _config;

        public TokenService(UserManager<AppUsers> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }

        public async Task<string> GenerateToken(AppUsers user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("subscriptionId", user.SubscriptionId.ToString()),
               
            };


            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTSettings:TokenKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenOptions = new JwtSecurityToken
            (
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}
