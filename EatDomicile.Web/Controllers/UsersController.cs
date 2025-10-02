using EatDomicile.Web.Services.Dtos;
using EatDomicile.Web.Services.Services;
using EatDomicile.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public sealed class UsersController : Controller
{
    private readonly UsersService _usersService;

    public UsersController(UsersService usersService)
    {
        _usersService = usersService;
    }

    // LISTE
    public async Task<ActionResult> Index()
    {
        var usersDtos = await _usersService.GetUsers();

        var users = usersDtos.Select(u => new UserViewModel
        {
            Id = u.Id,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Email = u.Email,
            Phone = u.Phone,
            Address = u.Address
        });

        return View(users);
    }

    // DETAILS
    public async Task<ActionResult> Details(int id)
    {
        var user = await _usersService.GetUser(id);
        if (user is null) return NotFound();

        return View(new UserViewModel
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Phone = user.Phone,
            Address = user.Address
        });
    }

    // CREATION
    public ActionResult Create() => View(new UserViewModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind("FirstName,LastName,Email,Phone,Address")] UserViewModel vm)
    {
        if (!ModelState.IsValid) return View(vm);

        try
        {
            var dto = new UserDTO
            {
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Email = vm.Email,
                Phone = vm.Phone,
                Address = vm.Address
            };
            await _usersService.CreateUserAsync(dto);

            return RedirectToAction(nameof(Index));
        }
        catch { return View(vm); }
    }

    // EDITION
    public async Task<ActionResult> Edit(int id)
    {
        var user = await _usersService.GetUser(id);
        if (user is null) return NotFound();

        return View(new UserViewModel
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Phone = user.Phone,
            Address = user.Address
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Phone,Address")] UserViewModel vm)
    {
        if (!ModelState.IsValid) return View(vm);

        try
        {
            var dto = new UserDTO
            {
                Id = vm.Id,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Email = vm.Email,
                Phone = vm.Phone,
                Address = vm.Address
            };
            await _usersService.UpdateUserAsync(dto.Id, dto);

            return RedirectToAction(nameof(Index));
        }
        catch { return View(vm); }
    }

    // SUPPRESSION
    public async Task<ActionResult> Delete(int id)
    {
        var user = await _usersService.GetUser(id);
        if (user is null) return NotFound();

        return View(new UserViewModel
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Phone = user.Phone,
            Address = user.Address
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
        try
        {
            await _usersService.DeleteUserAsync(id);
            return RedirectToAction(nameof(Index));
        }
        catch { return View(nameof(Delete), new { id }); }
    }
}
