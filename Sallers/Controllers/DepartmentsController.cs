using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Sallers.Models;

namespace Sallers.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Departmeent> list = new List<Departmeent>();
            list.Add(new Departmeent { Id = 1, Name= "Eletronics"});
            list.Add(new Departmeent { Id = 2, Name = "Fashion" });

            return View(list);
        }
    }
}
