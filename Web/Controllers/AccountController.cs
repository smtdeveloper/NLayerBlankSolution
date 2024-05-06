using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Web.Models;
using Repository.Repositories;
using Entities.Models.Auth;

namespace Web.Controllers;

public class AccountController : Controller
{
    private readonly IGenericRepository<Manager> _managerService;

    public AccountController(IGenericRepository<Manager> managerService)
    {
        _managerService = managerService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Login(LoginViewModel model)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        var manager = await _managerService.GetByUsernameAsync(model.UserName);

    //        if (manager != null && PasswordHelper.VerifyPassword(model.Password, manager.PasswordHash))
    //        {
    //            // Kullanıcı doğrulandı, rolleri yükleyin
    //            var roles = await _managerService.GetRolesAsync(manager.Id);
    //            var claims = new List<Claim>
    //            {
    //                new Claim(ClaimTypes.Name, manager.UserName),
    //                new Claim(ClaimTypes.Email, manager.Email),
    //                new Claim(ClaimTypes.NameIdentifier, manager.Id.ToString())
    //            };

    //            foreach (var role in roles)
    //            {
    //                claims.Add(new Claim(ClaimTypes.Role, role.Name));
    //            }

    //            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    //            var principal = new ClaimsPrincipal(identity);

    //            // Kullanıcıyı oturum açmaya yönlendir
    //            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

    //            return RedirectToAction("Index", "Home");
    //        }
    //        else
    //        {
    //            ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya parola");
    //        }
    //    }

    //    // Giriş sayfasını tekrar göster
    //    return View(model);
    //}

    public async Task<IActionResult> Logout()
    {
        // Kullanıcıyı oturumdan çıkış yapmaya yönlendir
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
}
