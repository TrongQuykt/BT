using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class HomeController : Controller
    {
        public INotyfService _notyfService { get; }
        public HomeController(INotyfService notyfService)
        {
            _notyfService = notyfService;
        }
        public IActionResult Index()
        {
            _notyfService.Success("Tài khoản của bạn là tài khoản Admin!");
            return View();
        }
        
    }
}
