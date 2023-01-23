using DeliveryApp.Data;
using DeliveryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Controllers {
    public class OrdersController: Controller {
        private readonly DeliveryContext _context;

        public OrdersController(DeliveryContext context) {
            _context = context;
        }

        public IActionResult Index() {
            var orders = _context.Orders.ToList();
            return View(orders);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("FromCity,FromAddress,ToCity,ToAddress,Weight,PickupDate,OrderNumber")] Order order) {
            if(!ModelState.IsValid) {
                if(string.IsNullOrEmpty(order.FromCity))
                    ModelState.AddModelError("FromCity", @"Поле ""Город отправителя"" необходимо заполнить.");
                if(string.IsNullOrEmpty(order.FromAddress))
                    ModelState.AddModelError("FromAddress", @"Поле ""Адрес отправителя"" необходимо заполнить.");
                if(string.IsNullOrEmpty(order.ToCity))
                    ModelState.AddModelError("ToCity", @"Поле ""Город получателя"" необходимо заполнить.");
                if(string.IsNullOrEmpty(order.ToAddress))
                    ModelState.AddModelError("ToAddress", @"Поле ""Адрес получателя"" необходимо заполнить.");
                if(order.Weight <= 0)
                    ModelState.AddModelError("Weight", @"Поле ""Вес груза"" необходимо заполнить и его значение должно быть больше нуля.");
                if(order.PickupDate == DateTime.MinValue)
                    ModelState.AddModelError("PickupDate", @"Поле ""Дата забора груза"" необходимо заполнить.");
                return View(order);
            }
            else {
                order.OrderNumber = "D-" + DateTime.Now.ToString("yyyy.MM.dd") + "-" + order.Id;
                _context.Add(order);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Details(int id) {
            var order = _context.Orders.Find(id);
            if(order == null) {
                return NotFound();
            }

            return View(order);
        }
    }
}