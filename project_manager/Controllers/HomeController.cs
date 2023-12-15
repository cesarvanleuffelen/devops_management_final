using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project_manager.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Contentful.Core;

namespace project_manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContentfulClient _client;

        public HomeController(ILogger<HomeController> logger, IContentfulClient client)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var tmProjects = await _client.GetEntries<Project>();
            return View(tmProjects);
        }

        public  IActionResult Edit(int id)
        {
            return View();
        }

        public IActionResult Add(int id)
        {
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
