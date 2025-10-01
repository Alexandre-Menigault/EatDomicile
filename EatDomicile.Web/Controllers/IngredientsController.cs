using EatDomicile.Web.Services.Services;
using EatDomicile.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly IngredientsService _ingredientsService;

        public IngredientsController(IngredientsService ingredientsService)
        {
            this._ingredientsService = ingredientsService;
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
            }).ToList();

            return View(ingredients);
        }

        // GET: UserController/Details/5
        public async Task<ActionResult> Details(int id)
        {


            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
