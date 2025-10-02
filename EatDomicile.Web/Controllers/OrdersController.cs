using EatDomicile.Web.Services.Dtos;
using EatDomicile.Web.Services.Enums;
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

    public OrdersController(
        OrdersService ordersService,
        UsersService usersService,
        IngredientsService ingredientsService,
        DrinksService drinksService)
    {
        _ordersService = ordersService;
        _usersService = usersService;
        _ingredientsService = ingredientsService;
        _drinksService = drinksService;
    }

    // LISTE DES COMMANDES
    public async Task<ActionResult> Index()
    {
        var ordersDtos = await _ordersService.GetOrdersAsync();

        var orders = ordersDtos.Select(o => new OrderViewModel
        {
            Id = o.Id,
            UserId = o.UserId,
            OrderDate = o.OrderDate,
            DeliveryDate = o.DeliveryDate,
            Status = o.Status.ToString(),
            DeliveryAddress = $"{o.DeliveryAddress.Street} - {o.DeliveryAddress.City}",
            Products = o.Products?.Select(p => $"{p.GetType().Name}:{p.Id}").ToList() ?? new List<string>(),
            UserName = $"{o.User.FirstName} {o.User.LastName}"
        });

        return View(orders);
    }

    // DETAILS
    public async Task<ActionResult> Details(int id)
    {
        var order = await _ordersService.GetOrder(id);
        if (order is null) return NotFound();

        var orderVm = new OrderViewModel
        {
            Id = order.Id,
            UserId = order.UserId,
            UserName = $"{order.User.FirstName} {order.User.LastName}",
            OrderDate = order.OrderDate,
            DeliveryDate = order.DeliveryDate,
            Status = order.Status.ToString(),
            DeliveryAddress = $"{order.DeliveryAddress.Street} {order.DeliveryAddress.City}",
            Products = order.Products?.Select(p => p.Name).ToList() ?? new List<string>()
        };
        
        return View(orderVm);
    }

    // CREATION
    public async Task<ActionResult> Create()
    {
        var usersDtos = await _usersService.GetUsers();
        var ingredientsDtos = await _ingredientsService.GetIngredientsAsync();
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

        return View(new OrderViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind("UserId,DeliveryAddress,SelectedProducts,SelectedDrinks")] OrderViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);

        try
        {
            var dto = new OrderDTO(
                id: 0,
                orderDate: DateTime.Now,
                deliveryDate: DateTime.Now.AddDays(2),
                status: OrderStatus.EnCuisine,
                products: null,
                userId: viewModel.UserId,
                deliveryAddressId: 1
            );

            if (viewModel.SelectedProducts?.Any() == true)
                dto.ProductIds.AddRange(viewModel.SelectedProducts);

            if (viewModel.SelectedDrinks?.Any() == true)
                dto.ProductIds.AddRange(viewModel.SelectedDrinks);

            await _ordersService.CreateOrderAsync(dto);

            TempData["Message"] = "✅ Commande créée avec succès";
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            TempData["Message"] = "❌ Erreur lors de la création";
            return View(viewModel);
        }
    }

    // EDIT
    public async Task<ActionResult> Edit(int id)
    {
        var order = await _ordersService.GetOrder(id);
        if (order is null) return NotFound();

        return View(new OrderViewModel
        {
            Id = order.Id,
            UserId = order.UserId,
            OrderDate = order.OrderDate,
            DeliveryDate = order.DeliveryDate,
            Status = order.Status.ToString(),
            DeliveryAddress = $"AdresseId: {order.DeliveryAddressId}",
            Products = order.Products?.Select(p => $"{p.GetType().Name}:{p.Id}").ToList() ?? new List<string>()
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(int id, [Bind("Id,UserId,OrderDate,DeliveryDate,Status,DeliveryAddress,SelectedProducts,SelectedDrinks")] OrderViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);

        try
        {
            var dto = new OrderDTO(
                id: viewModel.Id,
                orderDate: viewModel.OrderDate,
                deliveryDate: viewModel.DeliveryDate,
                status: Enum.Parse<OrderStatus>(viewModel.Status),
                products: null,
                userId: viewModel.UserId,
                deliveryAddressId: 1
            );

            if (viewModel.SelectedProducts?.Any() == true)
                dto.ProductIds.AddRange(viewModel.SelectedProducts);

            if (viewModel.SelectedDrinks?.Any() == true)
                dto.ProductIds.AddRange(viewModel.SelectedDrinks);

            await _ordersService.UpdateOrderAsync(viewModel.Id, dto);

            TempData["Message"] = "✅ Commande mise à jour avec succès";
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            TempData["Message"] = "❌ Erreur lors de la mise à jour";
            return View(viewModel);
        }
    }

    // DELETE
    public async Task<ActionResult> Delete(int id)
    {
        var order = await _ordersService.GetOrder(id);
        if (order is null) return NotFound();

        return View(new OrderViewModel
        {
            Id = order.Id,
            UserId = order.UserId,
            OrderDate = order.OrderDate,
            DeliveryDate = order.DeliveryDate,
            Status = order.Status.ToString()
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
        try
        {
            await _ordersService.DeleteOrderAsync(id);
            TempData["Message"] = "✅ Commande supprimée avec succès";
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            TempData["Message"] = "❌ Erreur lors de la suppression";
            return RedirectToAction(nameof(Delete), new { id });
        }
    }
}
