using IsakSiteApi.Data;
using IsakSiteApi.Dtos;
using IsakSiteApi.Enums;
using IsakSiteApi.Interfaces;
using IsakSiteApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace IsakSiteApi.Services
{
    public class UserService : IUser
    {
        private PortfolioDbContext _context;
        private readonly IConfiguration _configuration;

        private readonly PasswordHasher<User> _passwordHasher = new();

        public UserService(PortfolioDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<EUser> CreateUser(UserCreateDto dto)
        {
            var exists = await _context.User.FirstOrDefaultAsync(
                u => u.Email == dto.Email
            );

            if (exists != null)
                return EUser.AlreadyExists;

            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email
            };

            user.PasswordHash = _passwordHasher.HashPassword(
                user, dto.Password
            );

            _context.User.Add(user);

            await _context.SaveChangesAsync();

            return EUser.Created;
        }


        public string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey
            (
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)
            );

            var credentials = new SigningCredentials
            (
                key, SecurityAlgorithms.HmacSha256
            );

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var token = new JwtSecurityToken
            (
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
