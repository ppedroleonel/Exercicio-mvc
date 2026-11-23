using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Exercicio1.Models;

namespace Exercicio1.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
