using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MonolithicWebApplication.Business.Entities;
using MonolithicWebApplication.Models;
using System.Threading.Tasks;

namespace MonolithicWebApplication.Controllers
{
    public class AccountController : Controller
    {
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _singInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> singInManager) 
        {
            _userManager = userManager;
            _singInManager = singInManager;

        }

        [HttpGet]
        public IActionResult Login()
        {
            var loginModel = new LoginViewModel();
            return View(loginModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel userFormData)
        {
            if (ModelState.IsValid)
            {
                var result = await _singInManager.PasswordSignInAsync(userFormData.Email, userFormData.Password, false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }
                else {
                    ModelState.AddModelError("", "Invalid Credentials");
                }
            }
            return View();
        }

        public IActionResult Register() 
        {
            var registerModel = new RegisterViewModel();
            return View(registerModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel userFormData)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Email = userFormData.Email,
                    DateBirthday = userFormData.DateBirthday,
                    StreetAddress = userFormData.StreetAddress,
                    City = userFormData.City,
                    Name = userFormData.Name,
                    UserName = userFormData.Email,
                    NormalizedEmail = userFormData.Email,
                    Password = userFormData.Password,
                };
                var result = await _userManager.CreateAsync(user, user.Password);
                if (result.Succeeded) 
                {
                    await _singInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index","Home");
                }
                //
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("",item.Description);
                }
            }
            return View(userFormData);
        }

        public async Task<IActionResult> Logout()
        {
            await _singInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
