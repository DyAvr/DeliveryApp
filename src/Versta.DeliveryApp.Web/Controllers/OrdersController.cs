using MediatR;
using Microsoft.AspNetCore.Mvc;
using Versta.DeliveryApp.Application.UseCases.Commands.CreateOrder;
using Versta.DeliveryApp.Application.UseCases.Queries.GetOrderByNumber;
using Versta.DeliveryApp.Application.UseCases.Queries.GetOrders;

namespace Versta.DeliveryApp.Web.Controllers;

public class OrdersController(
    IMediator mediator
) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var orders = await mediator.Send(new GetOrdersQuery());
        return View(orders);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
    {
        var order = await mediator.Send(command);
        return Json(new { success = true, order });
    }

    [HttpGet("{orderNumber}")]
    public async Task<IActionResult> Details(string orderNumber)
    {
        var order = await mediator.Send(new GetOrderByNumberQuery(orderNumber));
        return View(order);
    }
}