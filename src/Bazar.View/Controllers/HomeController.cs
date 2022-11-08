using Bazar.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.View.Controllers;
public class HomeController : Controller
{

    public HomeController()
    {
    }

    public IActionResult Index()
    {
        return View(new List<AnuncioViewModel>());
    }

    public IActionResult Privacy()
    {
        return View();
    }

}
