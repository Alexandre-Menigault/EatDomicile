using EatDomicile.Web.Services.Dtos;
using EatDomicile.Web.Services.Services;
using EatDomicile.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Controllers;

public sealed class OrdersController : Controller
{
    private readonly OrdersService _ordersService;
    private readonly UsersService _usersService;
    private readonly IngredientsService _ingredientsService;
    private readonly DrinksService _drinksService;

    public OrdersController(OrdersService ordersService, UsersService usersService, IngredientsService ingredientsService, DrinksService drinksService)
    {
        _ordersService = ordersService;
        _usersService = usersService;
        _ingredientsService = ingredientsService;
        _drinksService = drinksService;
    }

    public async Task<ActionResult> Index()
    {
        var ordersDtos = await _ordersService.GetOrders();
        var usersDtos = await _usersService.GetUsers();

        var orders = ordersDtos.Select(o => new OrderViewModel
        {
            Id = o.Id,
            UserId = o.UserId,
            OrderDate = o.OrderDate,
            DeliveryDate = o.DeliveryDate,
            Status = o.Status,
            DeliveryAddress = o.DeliveryAddress,
            Products = o.Products,
            UserName = usersDtos.FirstOrDefault(u => u.Id == o.UserId)?.FirstName + " " +
               usersDtos.FirstOrDefault(u => u.Id == o.UserId)?.LastName
        });

        return View(orders);
    }

    public async Task<ActionResult> Details(int id)
    {
        var order = await _ordersService.GetOrderByIdAsync(id);
        if (order is null) return NotFound();

        return View(new OrderViewModel
        {
            Id = order.Id,
            UserId = order.UserId,
            OrderDate = order.OrderDate,
            DeliveryDate = order.DeliveryDate,
            Status = order.Status
        });
    }


    public async Task<ActionResult> Create()
    {
        var usersDtos = await _usersService.GetUsers();
        var ingredientsDtos = await _ingredientsService.GetIngredients();
        var drinksDtos = await _drinksService.GetDrinks();

        ViewBag.Users = usersDtos
            .Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = $"{u.FirstName} {u.LastName}"
            })
            .ToList();

        ViewBag.Products = ingredientsDtos
        .Select(i => new SelectListItem
        {
            Value = i.Id.ToString(),
            Text = $"{i.Name} ({i.Kcal} kcal)"
        })
        .ToList();

        ViewBag.Drinks = drinksDtos
        .Select(d => new SelectListItem
        {
            Value = d.Id.ToString(),
            Text = $"{d.Name} ({d.KCal} kcal)"
        })
        .ToList();

        var firstUser = usersDtos.FirstOrDefault();

        return View(new OrderViewModel
        {

            DeliveryAddress = firstUser?.Address ?? ""
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind("UserId,DeliveryAddress,SelectedProducts,SelectedDrinks")] OrderViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            var usersDtos = await _usersService.GetUsers();
            var ingredientsDtos = await _ingredientsService.GetIngredients();
            var drinksDtos = await _drinksService.GetDrinks();

            ViewBag.Users = usersDtos
                .Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = $"{u.FirstName} {u.LastName}"
                })
                .ToList();

            ViewBag.Products = ingredientsDtos
                .Select(i => new SelectListItem
                {
                    Value = i.Id.ToString(),
                    Text = $"{i.Name} ({i.Kcal} kcal)"
                })
                .ToList();

            ViewBag.Drinks = drinksDtos
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = $"{d.Name} ({d.KCal} kcal)"
                })
                .ToList();

            return View(viewModel);
        }

        try
        {
            var dto = new OrdersDto
            {
                UserId = viewModel.UserId,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(2),
                Status = "En préparation",
                DeliveryAddress = viewModel.DeliveryAddress,
                Products = new List<string>()
            };


            if (viewModel.SelectedProducts?.Any() == true)
                dto.Products.AddRange(viewModel.SelectedProducts.Select(p => $"Ingredient:{p}"));


            if (viewModel.SelectedDrinks?.Any() == true)
                dto.Products.AddRange(viewModel.SelectedDrinks.Select(d => $"Drink:{d}"));

            await _ordersService.CreateOrderAsync(dto);

            TempData["Message"] = "Commande créée avec succès ✅";
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            TempData["Message"] = "❌ Erreur lors de la création de la commande.";
            return View(viewModel);
        }
    }



    public async Task<ActionResult> Edit(int id)
    {
        var order = await _ordersService.GetOrderByIdAsync(id);
        if (order is null) return NotFound();

        return View(new OrderViewModel
        {
            Id = order.Id,
            UserId = order.UserId,
            OrderDate = order.OrderDate,
            DeliveryDate = order.DeliveryDate,
            Status = order.Status,
            DeliveryAddress = order.DeliveryAddress
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, [Bind("Id,UserId,OrderDate,DeliveryDate,Status,DeliveryAddress,SelectedProducts")] OrderViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {

            var usersDtos = await _usersService.GetUsers();
            var ingredientsDtos = await _ingredientsService.GetIngredients();
            var drinksDtos = await _drinksService.GetDrinks();

            ViewBag.Users = usersDtos
                .Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = $"{u.FirstName} {u.LastName}"
                })
                .ToList();

            ViewBag.Products = ingredientsDtos
                .Select(i => new SelectListItem
                {
                    Value = $"Ingredient:{i.Id}",
                    Text = $"{i.Name} ({i.Kcal} kcal)"
                })
                .ToList();

            ViewBag.Drinks = drinksDtos
                .Select(d => new SelectListItem
                {
                    Value = $"Drink:{d.Id}",
                    Text = $"{d.Name} ({d.KCal} kcal)"
                })
                .ToList();

            return View(viewModel);
        }

        try
        {
            var dto = new OrdersDto
            {
                Id = viewModel.Id,
                UserId = viewModel.UserId,
                OrderDate = viewModel.OrderDate,
                DeliveryDate = viewModel.DeliveryDate,
                Status = viewModel.Status,
                DeliveryAddress = viewModel.DeliveryAddress,
                Products = viewModel.SelectedProducts?.Select(p => p.ToString()).ToList() ?? new List<string>()
            };

            await _ordersService.UpdateOrderAsync(dto);

            TempData["Message"] = "Commande mise à jour avec succès ✅";
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            TempData["Message"] = "❌ Une erreur est survenue lors de la mise à jour.";
            return View(viewModel);
        }
    }

    public async Task<ActionResult> Delete(int id)
    {
        var order = await _ordersService.GetOrderByIdAsync(id);
        if (order is null) return NotFound();

        return View(new OrderViewModel
        {
            Id = order.Id,
            UserId = order.UserId,
            OrderDate = order.OrderDate,
            DeliveryDate = order.DeliveryDate,
            Status = order.Status
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
        try
        {
            await _ordersService.DeleteOrderAsync(id);
            return RedirectToAction(nameof(Index));
        }
        catch { return View(nameof(Delete), new { id }); }
    }
}
