using Bazar.Application.Request;
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
        AnuncioQuery query = new()
        {
            Cidade = "",
            Titulo = "",
            ItensPorPagina= 2,
            PaginaAtual = 1
        };

        var response = await useCase.GetAllAsync(query);

        return View(response.anunciosVM);
    }

    public IActionResult Privacy()
    {
        return View();
    }

}
