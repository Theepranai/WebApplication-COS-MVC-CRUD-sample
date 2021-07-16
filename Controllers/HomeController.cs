using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using WebApplication_COS_MVC_CRUD_sample.Models;
using WebApplication_COS_MVC_CRUD_sample.Services;

namespace WebApplication_COS_MVC_CRUD_sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly HomeService _homeService;

        public HomeController(
            ILogger<HomeController> logger,
            HomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            var rto = _homeService.GetAll();
            ViewData["edit"] = new HomeModel()
            {
                Id = 0,
                Name = "",
                LastName = ""
            };
            return View(rto);
        }

        public IActionResult Edit(int id)
        {
            var rto = _homeService.GetAll();
            ViewData["edit"] = new HomeModel();

            if (id > 0 && rto.First(x => x.Id == id) != null)
            {
                ViewData["edit"] = rto.FirstOrDefault(x => x.Id == id);
            }
            return View("Index", rto);
        }

        [HttpPost]
        public IActionResult Edit(HomeModel model)
        {
            if (model.Id == 0)
            {
                _homeService.Add(model);
            }
            else
            {
                _homeService.Edit(model);
            }

            return Redirect("/home");
        }

        public IActionResult Del(int id)
        {
            _homeService.Delete(id);
            return Redirect("/home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}