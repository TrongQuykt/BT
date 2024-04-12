using Microsoft.AspNetCore.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // Hiển thị danh sách đơn hàng
        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetAllOrders();
            return View(orders); // Trả về view kèm theo danh sách các đơn hàng
        }

        // Hiển thị form thêm đơn hàng mới
        public IActionResult Create()
        {
            return View();
        }

        // Xử lý thêm đơn hàng mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _orderService.AddOrder(order);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // Hiển thị form cập nhật đơn hàng
        public IActionResult Edit(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // Xử lý cập nhật đơn hàng
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _orderService.UpdateOrder(order);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // Xác nhận xóa đơn hàng
        public IActionResult Delete(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // Xử lý xóa đơn hàng
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            _orderService.DeleteOrder(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
