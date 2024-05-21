using Entities.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace AdminPanel.Controllers;

[Authorize(Roles = "Admin, Manager")]
public class ClaimController : Controller
{
    private readonly IGenericService<Claim> _claimService;

    public ClaimController(IGenericService<Claim> claimService)
    {
        _claimService = claimService;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _claimService.GetAllAsync();
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
    public async Task<IActionResult> Create(Claim claim)
    {
        if (ModelState.IsValid)
        {
            var response = await _claimService.CreateAsync(claim);
            if (response.Success)
                return RedirectToAction(nameof(Index));
            else
                ModelState.AddModelError(string.Empty, response.Message);
        }
        return View(claim);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var response = await _claimService.GetByIdAsync(id.Value);
        if (response.Success)
            return View(response.Data);
        else
            return RedirectToAction("Error", "Home", new { errorMessage = response.Message });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Claim claim)
    {
        if (id != claim.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            var response = await _claimService.UpdateAsync(claim);
            if (response.Success)
                return RedirectToAction(nameof(Index));
            else
                ModelState.AddModelError(string.Empty, response.Message);
        }
        return View(claim);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var response = await _claimService.GetByIdAsync(id.Value);
        if (response.Success)
            return View(response.Data);
        else
            return RedirectToAction("Error", "Home", new { errorMessage = response.Message });
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var response = await _claimService.GetByIdAsync(id.Value);
        if (response.Success)
            return View(response.Data);
        else
            return RedirectToAction("Error", "Home", new { errorMessage = response.Message });
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var response = await _claimService.GetByIdAsync(id);
        if (response.Success)
        {
            var deleteResponse = await _claimService.DeleteAsync(response.Data);
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

