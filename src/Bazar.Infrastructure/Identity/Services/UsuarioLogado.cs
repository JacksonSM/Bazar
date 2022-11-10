using Bazar.Domain.Account;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Bazar.Infrastructure.Identity.Services;
public class UsuarioLogado : IUsuarioLogado
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public UsuarioLogado(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public bool IsAutenticado(){ return _signInManager.Context.User.Identity.IsAuthenticated; }

    public string ObterUsuarioId()
    {
        return _signInManager.Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    public async Task<string> ObterUsuarioNomeCompletoAsync()
    {
        var usuarioLogado = await ObterUsuarioLogado();
        return usuarioLogado.NomeCompleto;
    }

    private async Task<ApplicationUser> ObterUsuarioLogado()
    {
        return await _userManager.GetUserAsync(_signInManager.Context.User);
    }
}
