using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Galaxy.MVC.Authentication.Models;
using Galaxy.MVC.Authentication.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;

namespace Galaxy.MVC.Authentication.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("signin")]
        public IActionResult SignIn()
        {
            //return Challenge(new AuthenticationProperties { RedirectUri ="/" });
            return View(new SignInModel());
        }

        [Route("signin/{provider}")]
        public IActionResult SignIn(string provider,string returnUrl)
        {
            return Challenge(new AuthenticationProperties { RedirectUri = returnUrl ?? "/" }, provider);
        }

        [Route("signin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                User user;
                if (await _userService.ValidateCredentials(model.Username, model.Password, out user))
                {
                    await SignInUser(user.Username);
                    if (returnUrl != null)
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        [Route("signout")]
        [HttpPost]
        public async Task<IActionResult> SignOut()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [Route("signup")]
        public IActionResult SignUp()
        {
            return View(new SignUpModel());
        }

        [Route("signup")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _userService.AddUser(model.Username, model.Password))
                {
                    await SignInUser(model.Username);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("Error", "Could not add user. Username already in use...");
            }
            return View(model);
        }

        public async Task SignInUser(string username)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, username),
                new Claim("name", username)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", null);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);
        }
    }
}