﻿using Microsoft.AspNetCore.Mvc;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
