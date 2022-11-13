using Bazar.Application.Request;
using Bazar.Application.Response;
using Bazar.Application.ViewModel;

namespace Bazar.Application.Services.Anuncio.Contracts;

public interface IObterAnuncioService
{
    Task<ObterAnuncioResponse> ObterTodosAsync(ObterAnuncioRequest query);
    Task<IEnumerable<AnuncioViewModel>> ObterAnuncioDoUsuarioAsync(string id);
    Task<AnuncioViewModel> ObterPoIdAsync(int id);
}
