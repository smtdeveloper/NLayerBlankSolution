using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Web.Models;
using Repository.Repositories;
using Entities.Models.Auth;
using Service.Services.ManagerService;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Web.Controllers;

public class AccountController : Controller
{
    private readonly IManagerService _managerService;

    public AccountController(IManagerService managerService)
    {
        _managerService = managerService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return RedirectToAction("Login", "Sign", new { Message = "ModelState not valid", IsError = true });

      

        if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password))
            return RedirectToAction("Login", "Sign", new { Message = "Lütfen kullanıcı adı ve şifre bilgisini doldurunuz!", IsError = true });

      


        return View(model);
    }

    


    public async Task<IActionResult> Logout()
    {
        // Kullanıcıyı oturumdan çıkış yapmaya yönlendir
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
}
