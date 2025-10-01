using EatDomicile.Web.Services.Dtos;
using EatDomicile.Web.Services.Services;
using EatDomicile.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public sealed class DrinksController : Controller
{
    private readonly DrinksService _drinksService;

    public DrinksController(DrinksService drinksService)
    {
        this._drinksService = drinksService;
    }

    // GET: DrinkController
    public async Task<ActionResult> Index()
    {


        var drinksDtos = await _drinksService.GetDrinks();

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

    // GET: UserController/Details/5
    public async Task<ActionResult> Details(int id)
    {
        var drink = await this._drinksService.GetDrinkByIdAsync(id);

        if (drink is null)
        {
            return this.NotFound();
        }

        var drinkViewModel = new DrinkViewModel
        {
            Id = drink.Id,
            Name = drink.Name,
            Price = drink.Price,
            Fizzy = drink.Fizzy,
            KCal = drink.KCal
        };
        return this.View(drinkViewModel);
    }

    // GET: UserController/Create
    public ActionResult Create()
    {
        var drinkCreateViewModel = new DrinkViewModel();
        return View(drinkCreateViewModel);
    }

    // POST: UserController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind("Name,Price,Fizzy,KCal")] DrinkViewModel drinkCreateViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(drinkCreateViewModel);
        }
        try
        {
            var newDrink = new DrinksDto
            {
                Name = drinkCreateViewModel.Name,
                Price = drinkCreateViewModel.Price,
                Fizzy = drinkCreateViewModel.Fizzy,
                KCal = drinkCreateViewModel.KCal
            };
            await _drinksService.CreateDrinkAsync(newDrink);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: UserController/Edit/5
    public async Task<ActionResult> Edit(int id)
    {
        var drink = await this._drinksService.GetDrinkByIdAsync(id);
        if (drink is null)
        {
            return this.NotFound();
        }

        var drinkEditViewModel = new DrinkViewModel
        {
            Id = drink.Id,
            Name = drink.Name,
            Price = drink.Price,
            Fizzy = drink.Fizzy,
            KCal = drink.KCal
        };
        return View(drinkEditViewModel);
    }

    // POST: UserController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, [Bind("Id,Name,Price,Fizzy,KCal")] DrinkViewModel drinkEditViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(drinkEditViewModel);
        }

        try
        {
            var updatedDrink = new DrinksDto
            {
                Id = drinkEditViewModel.Id,
                Name = drinkEditViewModel.Name,
                Price = drinkEditViewModel.Price,
                Fizzy = drinkEditViewModel.Fizzy,
                KCal = drinkEditViewModel.KCal
            };
            await _drinksService.UpdateDrinkAsync(updatedDrink);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: UserController/Delete/5
    public async Task<ActionResult> Delete(int id)
    {
        var drink = await this._drinksService.GetDrinkByIdAsync(id);
        if (drink is null)
        {
            return this.NotFound();
        }

        var drinkDeleteViewModel = new DrinkViewModel
        {
            Id = drink.Id,
            Name = drink.Name,
            Price = drink.Price,
            Fizzy = drink.Fizzy,
            KCal = drink.KCal
        };
        return View(drinkDeleteViewModel);
    }

    // POST: UserController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
        try
        {
            await _drinksService.DeleteDrinkAsync(id);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return this.View(nameof(this.Details));
        }
    }
}
