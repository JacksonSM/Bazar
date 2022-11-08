using Bazar.Application.UseCase.Anuncio.Criar;
using Bazar.Application.ViewModel;
using Bazar.Domain.Validation;
using Bazar.View.Tools.Imagens;
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
    public async Task<IActionResult> CriarAnuncio(
        IFormFile imagemPrincipal,
        IFormFileCollection imagensSegundaria,
        AnuncioViewModel anuncioVM,
        [FromServices] ICriarAnuncioUseCase criarAnuncioUseCase,
        [FromServices] GerenciadorImagens gerirImagens)
    {
        if (ModelState.IsValid)
        {
            try
            {
                anuncioVM.ImagemPrincipal = gerirImagens.SalvarImagem(imagemPrincipal);
                anuncioVM.Imagens = string.Join("," ,gerirImagens.SalvarImagem(imagensSegundaria));

                await criarAnuncioUseCase.ExecuteAsync(anuncioVM);
            }
            catch(Exception e) 
            {

                ModelState.AddModelError(string.Empty, e.Message);
                return View(anuncioVM);
            }
            finally
            {
                if (anuncioVM.Imagens is not null && anuncioVM.ImagemPrincipal is not null)
                {
                    var imagens = anuncioVM.Imagens.Split(",").ToList();
                    imagens.Add(anuncioVM.ImagemPrincipal);
                    gerirImagens.ExcluirImagem(imagens.ToArray());
                }
            }
        }
        return RedirectToAction("Index","Home");
    }
}
