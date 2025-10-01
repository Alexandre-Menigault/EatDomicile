using EatDomicile.Web.Services.Dtos;
using EatDomicile.Web.Services.Services;
using EatDomicile.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public sealed class IngredientsController : Controller
{
    private readonly IngredientsService _ingredientsService;

    public IngredientsController(IngredientsService ingredientsService)
    {
        _ingredientsService = ingredientsService;
    }

    // GET: IngredientController
    public async Task<ActionResult> Index()
    {
        var ingredientsDtos = await _ingredientsService.GetIngredients();

        var ingredients = ingredientsDtos.Select(i => new IngredientViewModel
        {
            Id = i.Id,
            Name = i.Name,
            Kcal = i.Kcal,
            Allergene = i.Allergene
        });

        return View(ingredients);
    }

    // GET: IngredientController/Details/5
    public async Task<ActionResult> Details(int id)
    {
        var ingredient = await _ingredientsService.GetIngredientByIdAsync(id);

        if (ingredient is null)
        {
            return NotFound();
        }

        var ingredientVm = new IngredientViewModel
        {
            Id = ingredient.Id,
            Name = ingredient.Name,
            Kcal = ingredient.Kcal,
            Allergene = ingredient.Allergene
        };

        return View(ingredientVm);
    }

    // GET: IngredientController/Create
    public ActionResult Create() => View(new IngredientViewModel());

    // POST: IngredientController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind("Name,KCal,Allergene")] IngredientViewModel vm)
    {
        if (!ModelState.IsValid) return View(vm);

        try
        {
            var dto = new IngredientsDto
            {
                Name = vm.Name,
                Kcal = vm.Kcal,
                Allergene = vm.Allergene
            };

            await _ingredientsService.CreateIngredientAsync(dto);

            return RedirectToAction(nameof(Index));
        }
        catch { return View(vm); }
    }

    // GET: IngredientController/Edit/5
    public async Task<ActionResult> Edit(int id)
    {
        var ingredient = await _ingredientsService.GetIngredientByIdAsync(id);
        if (ingredient is null) return NotFound();

        return View(new IngredientViewModel
        {
            Id = ingredient.Id,
            Name = ingredient.Name,
            Kcal = ingredient.Kcal,
            Allergene = ingredient.Allergene
        });
    }

    // POST: IngredientController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, [Bind("Id,Name,KCal,Allergene")] IngredientViewModel vm)
    {
        if (!ModelState.IsValid) return View(vm);

        try
        {
            var dto = new IngredientsDto
            {
                Id = vm.Id,
                Name = vm.Name,
                Kcal = vm.Kcal,
                Allergene = vm.Allergene
            };
            await _ingredientsService.UpdateIngredientAsync(dto);

            return RedirectToAction(nameof(Index));
        }
        catch { return View(vm); }
    }

    // GET: IngredientController/Delete/5
    public async Task<ActionResult> Delete(int id)
    {
        var ingredient = await _ingredientsService.GetIngredientByIdAsync(id);
        if (ingredient is null) return NotFound();

        return View(new IngredientViewModel
        {
            Id = ingredient.Id,
            Name = ingredient.Name,
            Kcal = ingredient.Kcal,
            Allergene = ingredient.Allergene
        });
    }

    // POST: IngredientController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
        try
        {
            await _ingredientsService.DeleteIngredientAsync(id);
            return RedirectToAction(nameof(Index));
        }
        catch { return View(nameof(Delete), new { id }); }
    }
}
