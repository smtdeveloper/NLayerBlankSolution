using AdminPanel.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Service.Services.ManagerService;

namespace AdminPanel.Controllers;

public class AccountController : Controller
{
    private readonly IManagerService _managerService;
    private readonly TokenService _tokenService;

    public AccountController(IManagerService managerService, TokenService tokenSernice)
    {
        _managerService = managerService;
        _tokenService = tokenSernice;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel model)
    {

        if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password))
            return RedirectToAction("Login", "Sign", new { Message = "Lütfen kullanıcı adı ve şifre bilgisini doldurunuz!", IsError = true });


        var manager = _managerService.GetByUserAsync(model.UserName, model.Password);

        if (manager.Result.Success == false)
            return RedirectToAction("Login", "Sign", new { Message = "Kayitli kullanici bulunamadi", IsError = true });

        var token = _tokenService.GenerateToken(model.UserName);

        HttpContext.Response.Headers.Add("Authorization", $"Bearer {token}");

        return RedirectToAction("Index", "Home");
    }




    public async Task<IActionResult> Logout()
    {
        // Kullanıcıyı oturumdan çıkış yapmaya yönlendir
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
}