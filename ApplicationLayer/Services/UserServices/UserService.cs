using ApplicationLayer.Models.DTOs;
using DomainLayer.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<int> GetUserIdAsync(ClaimsPrincipal claims)
        {
            var user = await _userManager.GetUserAsync(claims);
            return user.Id;
        }

        public async Task<LoginResultDTO> LoginAsync(LoginDTO login)
        {
            LoginResultDTO result = new LoginResultDTO() { IsAdmin = false, IsRegisteredUser = false };
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user == null) return result;

            result.IsAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            result.IsRegisteredUser = await _userManager.CheckPasswordAsync(user, login.Password);
            result.AppUser = user;
            return result;
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterAsync(RegisterDTO user)
        {
            AppUser newUser = new AppUser();
            newUser.Name = user.Name;
            newUser.Email = user.Email;
            newUser.UserName = user.UserName;
            newUser.Surname = user.SurName;
            newUser.Address = user.Address;

            PasswordHasher<AppUser> hasher = new PasswordHasher<AppUser>();
            newUser.PasswordHash = hasher.HashPassword(newUser, user.Password);

            var result = await _userManager.CreateAsync(newUser);

            //Role ilişkisi
            await _userManager.AddToRoleAsync(newUser, "Uye");

            return result.Succeeded;
        }
    }
}
