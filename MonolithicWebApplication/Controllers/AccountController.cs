using Microsoft.AspNetCore.Mvc;
using MonolithicWebApplication.Models;

namespace MonolithicWebApplication.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            var loginModel = new LoginViewModel();
            return View(loginModel);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel userFormData)
        {
            if (ModelState.IsValid)
            {
                if (userFormData.Email == "")
                {
                    return RedirectToAction("Index", "Home");
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
        public IActionResult Register(RegisterViewModel userFormData)
        {
            if (ModelState.IsValid)
            {
                //Save DataBase
            }
            return View(userFormData);
        }
    }
}
