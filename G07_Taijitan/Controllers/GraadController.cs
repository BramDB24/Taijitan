using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace G07_Taijitan.Controllers
{
    public class GraadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}