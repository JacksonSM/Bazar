using Bazar.View.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.View.Controllers;
public class AnuncioController : Controller
{
    [HttpGet]
    public IActionResult CriarAnuncio()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public Task<IActionResult> CriarAnuncio(IFormFile imagemPrincipal, IFormFileCollection imagensSegundaria,
    AnuncioViewModel anuncioVM)
    {
        throw new NotImplementedException();
    }
}
