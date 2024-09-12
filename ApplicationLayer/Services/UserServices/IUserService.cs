using ApplicationLayer.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.UserServices
{
    public interface IUserService
    {
        Task<LoginResultDTO> LoginAsync(LoginDTO login);
        Task<bool> RegisterAsync(RegisterDTO user);
        Task<int> GetUserIdAsync(ClaimsPrincipal claims);
        Task LogoutAsync();
    }
}
