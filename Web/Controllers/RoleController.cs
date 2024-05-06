using Entities.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace Web.Controllers;

[Authorize(Roles = "Admin, Manager")]
public class RoleController : Controller
{
    private readonly IGenericService<Role> _roleService;

    public RoleController(IGenericService<Role> roleService)
    {
        _roleService = roleService;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _roleService.GetAllAsync();
        if (response.Success)
            return View(response.Data);
        else
            return RedirectToAction("Error", "Home", new { errorMessage = response.Message });
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Role role)
    {
        if (ModelState.IsValid)
        {
            var response = await _roleService.CreateAsync(role);
            if (response.Success)
                return RedirectToAction(nameof(Index));
            else
                ModelState.AddModelError(string.Empty, response.Message);
        }
        return View(role);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var response = await _roleService.GetByIdAsync(id.Value);
        if (response.Success)
            return View(response.Data);
        else
            return RedirectToAction("Error", "Home", new { errorMessage = response.Message });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Role role)
    {
        if (id != role.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            var response = await _roleService.UpdateAsync(role);
            if (response.Success)
                return RedirectToAction(nameof(Index));
            else
                ModelState.AddModelError(string.Empty, response.Message);
        }
        return View(role);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var response = await _roleService.GetByIdAsync(id.Value);
        if (response.Success)
            return View(response.Data);
        else
            return RedirectToAction("Error", "Home", new { errorMessage = response.Message });
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var response = await _roleService.GetByIdAsync(id.Value);
        if (response.Success)
            return View(response.Data);
        else
            return RedirectToAction("Error", "Home", new { errorMessage = response.Message });
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var response = await _roleService.GetByIdAsync(id);
        if (response.Success)
        {
            var deleteResponse = await _roleService.DeleteAsync(response.Data);
            if (deleteResponse.Success)
                return RedirectToAction(nameof(Index));
            else
                ModelState.AddModelError(string.Empty, deleteResponse.Message);
        }
        else
        {
            ModelState.AddModelError(string.Empty, response.Message);
        }
        return View(response.Data);
    }
}
