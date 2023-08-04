using MStore.Application.Dtos.AppUsersDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<GetUserDto> Login(LoginDto loginDto);

        Task<GetUserDto> GetCurrentUser(string Email);
    }
}
