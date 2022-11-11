using Bazar.Application.Request;
using Bazar.Application.UseCase.Anuncio.Obter;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.View.Controllers;
public class HomeController : Controller
{

    public HomeController()
    {
    }

    public async Task<IActionResult> Index(
        string? cidade,
        string? titulo, 
        int? paginaAtual,
        [FromServices] IObterAnuncioUseCase useCase)
    {
        AnuncioQuery query = new()
        {
            Cidade = cidade,
            Titulo = titulo,
            ItensPorPagina= 1,
            PaginaAtual = paginaAtual ?? 1
        };

        var response = await useCase.GetAllAsync(query);
        return View(response);
    }

    public IActionResult Privacy()
    {
        return View();
    }

}
