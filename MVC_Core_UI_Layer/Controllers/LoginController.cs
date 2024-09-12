using ApplicationLayer.Models.DTOs;
using ApplicationLayer.Services.UserServices;
using DomainLayer.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Core_UI_Layer.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(IUserService userService, SignInManager<AppUser> signInManager)
        {
            _userService = userService;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDTO login)
        {
            var result = await _userService.LoginAsync(login);
            if (result.IsRegisteredUser)
            {
                await _signInManager.SignInAsync(result.AppUser, false);
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO user)
        {
            var result = await _userService.RegisterAsync(user);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
