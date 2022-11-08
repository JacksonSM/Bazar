using Bazar.Application.UseCase.Anuncio.Obter;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.View.Controllers;
public class HomeController : Controller
{

    public HomeController()
    {
    }

    public async Task<IActionResult> Index([FromServices] IObterAnuncioUseCase useCase)
    {
        return View(await useCase.GetAllAsync());
    }

    public IActionResult Privacy()
    {
        return View();
    }

}
