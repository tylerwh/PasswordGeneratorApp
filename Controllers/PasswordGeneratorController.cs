using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PasswordGeneratorApp.Models;

namespace PasswordGeneratorApp.Controllers
{
    public class PasswordGeneratorController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            /**
                int min = 6;
                int max = 15;
                List<int> Sizes = new List<int>();
                for (int i = min; i <= max; i++)
                {
                    Sizes.Add(i);
                }
                ViewData["Sizes"] = new SelectList(Sizes, "PasswordSize", "PasswordSize");
                */
            ViewBag.Password = "";
            ViewBag.NoSelectionFound = "";
            return View();
        }

        [HttpPost]
        public IActionResult Index(PasswordGenerator model)
        {
            if (ModelState.IsValid)
            {
                if (model.UseLower || model.UseUpper || model.UseNumbers || model.UseSpecialChars)
                {
                    ViewBag.Password = model.GeneratedPassword;
                    ViewBag.NoSelectionFound = "";
                }
                else
                {
                    ViewBag.Password = "";
                    ViewBag.NoSelectionFound = "You must select at least one option above.";
                }
            }
            else
            {
                /**
                int min = 6;
                int max = 15;
                List<int> Sizes = new List<int>();
                for (int i = min; i <= max; i++)
                {
                    Sizes.Add(i);
                }
                ViewData["Sizes"] = new SelectList(Sizes, "PasswordSize", "PasswordSize");
                */
                ViewBag.Password = "";
                ViewBag.NoSelectionFound = "You must select at least one option above.";
            }
            
            return View(model);
        }
    }
}
