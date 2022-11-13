using Bazar.Application.Services.Anuncio.Contracts;
using Bazar.Application.ViewModel;
using Bazar.View.Tools.Imagens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Bazar.View.Controllers;

[Authorize]
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
        [FromServices] IAnuncioService criarAnuncioUseCase,
        [FromServices] GerenciadorImagens gerirImagens)
    {
        if (ModelState.IsValid)
        {
            try
            {
                anuncioVM.ImagemPrincipal = gerirImagens.SalvarImagem(imagemPrincipal);
                anuncioVM.Imagens = string.Join("," ,gerirImagens.SalvarImagem(imagensSegundaria));

                await criarAnuncioUseCase.AdicionarAsync(anuncioVM);
            }
            catch(Exception e) 
            {
                if (anuncioVM.Imagens is not null && anuncioVM.ImagemPrincipal is not null)
                {
                    var imagens = anuncioVM.Imagens.Split(",").ToList();
                    imagens.Add(anuncioVM.ImagemPrincipal);
                    gerirImagens.ExcluirImagem(imagens.ToArray());
                }

                ModelState.AddModelError(string.Empty, e.Message);
                return View(anuncioVM);
            }

        }
        return RedirectToAction("Index","Home");
    }


    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> AnuncioView(
        int anuncioId,
        [FromServices] IObterAnuncioService useCase)
    {
        var anuncio = await useCase.ObterPoIdAsync(anuncioId);

        if (anuncio is null)
            return NotFound();

        return View(anuncio);
    }

    [HttpGet]
    public async Task<IActionResult> MeusAnuncios(
    int anuncioId,
    [FromServices] IObterAnuncioService useCase)
    {
        var usuarioLogadoId = ObterUsuarioId();

        var anuncio = await useCase.ObterAnuncioDoUsuarioAsync(usuarioLogadoId);

        if (anuncio is null)
            return NotFound();

        return View(anuncio);
    }

    [HttpGet]
    public async Task<IActionResult> Editar(
    int id,
    [FromServices] IObterAnuncioService useCase)
    {
        var anuncio = await useCase.ObterPoIdAsync(id);

        if (anuncio is null)
            return NotFound();

        return View(anuncio);
    }

    [HttpPost]
    public async Task<IActionResult> Editar(
        AnuncioViewModel anuncioVM,
        [FromServices] IAnuncioService service)
    {
        await service.AtualizarAsync(anuncioVM, ObterUsuarioId());

        return RedirectToAction(nameof(MeusAnuncios));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Deletar(
        int id,
        [FromServices] IObterAnuncioService useCase)
    {
        var anuncio = await useCase.ObterPoIdAsync(id);

        if (anuncio is null)
            return NotFound();

        return View(anuncio);
    }

    [HttpPost]
    public async Task<IActionResult> Deletar(
        int id,
        [FromServices] IAnuncioService service)
    {
        await service.DeletarAsync(id, ObterUsuarioId());

        return RedirectToAction(nameof(MeusAnuncios));
    }

    private string ObterUsuarioId() =>
        User.FindFirstValue(ClaimTypes.NameIdentifier);
}
