using Microsoft.AspNetCore.Mvc;

namespace Bazar.View.Controllers;
public class AnuncioController : Controller
{
    public IActionResult CriarAnuncio()
    {
        return View();
    }
}
