using EatDomicile.Web.Services.Dtos;
using EatDomicile.Web.Services.Services;
using EatDomicile.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public sealed class DrinksController : Controller
{
    private readonly DrinksService _drinksService;

    public DrinksController(DrinksService drinksService)
    {
        this._drinksService = drinksService;
    }

    // GET: DrinksController
    public async Task<ActionResult> Index()
    {
        var drinksDtos = await _drinksService.GetDrinksAsync();

        var drinks = drinksDtos.Select(d => new DrinkViewModel
        {
            Id = d.Id,
            Name = d.Name,
            Price = d.Price,
            Fizzy = d.Fizzy,
            KCal = d.KCal
        });

        return View(drinks);
    }

    public async Task<ActionResult> Details(int id)
    {
        var drink = await _drinksService.GetDrink(id);
        if (drink is null) return NotFound();

        return View(new DrinkViewModel
        {
            Id = drink.Id,
            Name = drink.Name,
            Price = drink.Price,
            Fizzy = drink.Fizzy,
            KCal = drink.KCal
        });
    }

    public ActionResult Create() => View(new DrinkViewModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind("Name,Price,Fizzy,KCal")] DrinkViewModel vm)
    {
        if (!ModelState.IsValid) return View(vm);

        try
        {
            var dto = new DrinkDTO
            (vm.Name, vm.Price, vm.Fizzy, vm.KCal);
            await _drinksService.CreateDrinkAsync(dto);
            return RedirectToAction(nameof(Index));
        }
        catch { return View(vm); }
    }

    public async Task<ActionResult> Edit(int id)
    {
        var drink = await _drinksService.GetDrink(id);
        if (drink is null) return NotFound();

        return View(new DrinkViewModel
        {
            Id = drink.Id,
            Name = drink.Name,
            Price = drink.Price,
            Fizzy = drink.Fizzy,
            KCal = drink.KCal
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, [Bind("Id,Name,Price,Fizzy,KCal")] DrinkViewModel vm)
    {
        if (!ModelState.IsValid) return View(vm);

        try
        {
            var dto = new DrinkDTO
            (
                              vm.Name,
                 vm.Price,
                 vm.Fizzy,
                 vm.KCal
            );
            await _drinksService.UpdateDrinkAsync(dto.Id, dto);
            return RedirectToAction(nameof(Index));
        }
        catch { return View(vm); }
    }

    public async Task<ActionResult> Delete(int id)
    {
        var drink = await _drinksService.GetDrink(id);
        if (drink is null) return NotFound();

        return View(new DrinkViewModel
        {
            Id = drink.Id,
            Name = drink.Name,
            Price = drink.Price,
            Fizzy = drink.Fizzy,
            KCal = drink.KCal
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
        try
        {
            await _drinksService.DeleteDrinkAsync(id);
            return RedirectToAction(nameof(Index));
        }
        catch { return View(nameof(Delete), new { id }); }
    }
}
