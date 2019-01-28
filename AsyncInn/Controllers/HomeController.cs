using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// GET: Home/Index
        /// </summary>
        /// <returns> loads Home/Index view </returns>
        public IActionResult Index()
        {
            return View();
        }

    }
}
