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
    // LISTE
    public async Task<ActionResult> Index()
    {
        var ingredientsDtos = await _ingredientsService.GetIngredientsAsync();

        var ingredients = ingredientsDtos.Select(i => new IngredientViewModel
        {
            Id = i.Id,
            Name = i.Name,
            Kcal = i.Kcal,
            Allergene = i.Allergene
        });

        return View(ingredients);
    }

    // DETAILS
    public async Task<ActionResult> Details(int id)
    {
        var ingredient = await _ingredientsService.GetIngredient(id);

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

    // CREATE

    public ActionResult Create() => View(new IngredientViewModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind("Name,KCal,Allergene")] IngredientViewModel vm)
    {
        if (!ModelState.IsValid) return View(vm);

        try
        {
            var dto = new IngredientDTO(
                id: 0,
                name: vm.Name,
                kcal: vm.Kcal,
                allergene: vm.Allergene
            );

            await _ingredientsService.CreateIngredientAsync(dto);

            return RedirectToAction(nameof(Index));
        }
        catch { return View(vm); }
    }

    // EDIT
    public async Task<ActionResult> Edit(int id)
    {
        var ingredient = await _ingredientsService.GetIngredient(id);
        if (ingredient is null) return NotFound();

        return View(new IngredientViewModel
        {
            Id = ingredient.Id,
            Name = ingredient.Name,
            Kcal = ingredient.Kcal,
            Allergene = ingredient.Allergene
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, [Bind("Id,Name,KCal,Allergene")] IngredientViewModel vm)
    {
        if (!ModelState.IsValid) return View(vm);

        try
        {
            var dto = new IngredientDTO(
                id: vm.Id,
                name: vm.Name,
                kcal: vm.Kcal,
                allergene: vm.Allergene
            );

            await _ingredientsService.UpdateIngredientAsync(vm.Id, dto); // ✅ on passe l'id et le dto

            return RedirectToAction(nameof(Index));
        }
        catch { return View(vm); }
    }

    // DELETE
    public async Task<ActionResult> Delete(int id)
    {
        var ingredient = await _ingredientsService.GetIngredient(id);
        if (ingredient is null) return NotFound();

        return View(new IngredientViewModel
        {
            Id = ingredient.Id,
            Name = ingredient.Name,
            Kcal = ingredient.Kcal,
            Allergene = ingredient.Allergene
        });
    }


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
