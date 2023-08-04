using MediatR;
using Microsoft.AspNetCore.Identity;
using MStore.Application.Core;
using MStore.Application.Dtos.AppUsersDtos;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Identities;
using MStore.Persistence.Context;
using MStore.Persistence.Mappings;

namespace MStore.Persistence.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUsers> _userManager;
        public readonly ApplicationDbContext _context;
        private readonly TokenService _tokenService;
        public UserRepository(UserManager<AppUsers> userManager, ApplicationDbContext context, TokenService tokenService)
        {

            _userManager = userManager;
            _context = context;
            _tokenService = tokenService;
        }
        public async Task<GetUserDto> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return null;
            var getUser = new GetUserDto
            {
                Email = user.Email,
                Token = await _tokenService.GenerateToken(user),
                DisplayName = user.EngName,
                UserName = user.UserName,
                UserId = user.Id
            };
            return getUser;
        }

        public async Task<GetUserDto> GetCurrentUser(string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            return  new GetUserDto
            {
                UserId = user.Id,
                Token = await _tokenService.GenerateToken(user),
                Email = user.Email,
                UserName = user.UserName,

            };

        }
    }
}
