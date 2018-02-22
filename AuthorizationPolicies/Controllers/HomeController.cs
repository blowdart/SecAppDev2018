using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationPolicies.Controllers
{
    public class HomeController : Controller
    {
        private ICondimentProvider _condimentProvider;

        public HomeController(ICondimentProvider condimentProvider)
        {
            _condimentProvider = condimentProvider;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new Model.HomeViewModel
            {
                Condiment = _condimentProvider.GetCondiment()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult CondimentPicker()
        {
            var model = new Model.HomeViewModel
            {
                Condiment = _condimentProvider.GetCondiment()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CondimentPicker(Condiment condiment)
        {
            _condimentProvider.SetCondiment(condiment);
            return RedirectToAction("Index");
        }
    }
}