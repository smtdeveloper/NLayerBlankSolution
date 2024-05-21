using Entities.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace AdminPanel.Controllers;
[Authorize(Roles = "Admin, Manager")]
public class ManagerController : Controller
{
    private readonly IGenericService<Manager> _managerService;

    public ManagerController(IGenericService<Manager> managerService)
    {
        _managerService = managerService;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _managerService.GetAllAsync();
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
    public async Task<IActionResult> Create(Manager manager)
    {
        if (ModelState.IsValid)
        {
            var response = await _managerService.CreateAsync(manager);
            if (response.Success)
                return RedirectToAction(nameof(Index));
            else
                ModelState.AddModelError(string.Empty, response.Message);
        }
        return View(manager);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var response = await _managerService.GetByIdAsync(id.Value);
        if (response.Success)
            return View(response.Data);
        else
            return RedirectToAction("Error", "Home", new { errorMessage = response.Message });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Manager manager)
    {
        if (id != manager.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            var response = await _managerService.UpdateAsync(manager);
            if (response.Success)
                return RedirectToAction(nameof(Index));
            else
                ModelState.AddModelError(string.Empty, response.Message);
        }
        return View(manager);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var response = await _managerService.GetByIdAsync(id.Value);
        if (response.Success)
            return View(response.Data);
        else
            return RedirectToAction("Error", "Home", new { errorMessage = response.Message });
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var response = await _managerService.GetByIdAsync(id.Value);
        if (response.Success)
            return View(response.Data);
        else
            return RedirectToAction("Error", "Home", new { errorMessage = response.Message });
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var response = await _managerService.GetByIdAsync(id);
        if (response.Success)
        {
            var deleteResponse = await _managerService.DeleteAsync(response.Data);
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
