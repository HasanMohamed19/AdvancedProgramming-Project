﻿using Microsoft.AspNetCore.Mvc;
using ServiceTitanWebApp.Models;
using System.Diagnostics;
using System.Net.Mail;

namespace ServiceTitanWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            //EmailController.Instance().SendAccountCreatedEmail("servicetitanbh@gmail.com", "username", "firstName", "lastName");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}