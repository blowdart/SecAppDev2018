using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationPolicies.Controllers
{
    [Authorize]
    public class FoodController : Controller
    {
        [HttpGet]
        [Authorize(Policy = AuthorizationPolicies.Condiment)]
        public IActionResult Index()
        {
            TempData["Result"] = true;
            return RedirectToAction("Index", "Home");
        }
    }
}