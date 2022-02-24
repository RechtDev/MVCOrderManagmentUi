using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCOrderManagmentUi.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVCOrderManagmentUi.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpPost, AllowAnonymous]
        public IActionResult Register()
        {
            UserRegistrationDto model = new UserRegistrationDto();
            return View(model);
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(UserRegistrationDto request)
        {
            if(ModelState.IsValid)
            {
                var userCheck = await userManager.FindByEmailAsync(request.Email);

                if (userCheck == null)
                {
                    var user = new IdentityUser
                    {
                        UserName = request.UserName,
                        NormalizedUserName = request.UserName,
                        Email = request.Email,
                        EmailConfirmed = true,
                    };
                    var result = await userManager.CreateAsync(user, request.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        if (result.Errors.Count() > 0)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("message", error.Description);
                            }
                        }
                        return View(request);
                    }
                }
                else
                {
                    ModelState.AddModelError("message", "Email already Exists");
                    return View(request);
                }
            }
            return View(request);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            UserLoginDTO model = new UserLoginDTO();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDTO loginDTO)
        {
            if(ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(loginDTO.Email);
                if (user!= null && !user.EmailConfirmed)
                {
                    ModelState.AddModelError("message", "Email not confimred yet!");
                    return View(loginDTO);
                }
                if (await userManager.CheckPasswordAsync(user, loginDTO.Password)==false)
                {
                    ModelState.AddModelError("message", "Invalid credentials");
                    return View(loginDTO);
                }
                var result = await signInManager.PasswordSignInAsync(loginDTO.Email,loginDTO.Password,loginDTO.RememberMe, true);
                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new Claim("UserRole", "Admin"));
                    return RedirectToAction("ShowDashboard", "Dashboard");
                }
                else if (result.IsLockedOut)
                {
                    return View("AccountLocked");
                }
            }
        }
    } 
}
