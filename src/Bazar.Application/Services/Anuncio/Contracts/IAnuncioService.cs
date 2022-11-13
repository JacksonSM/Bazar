using Bazar.Application.ViewModel;

namespace Bazar.Application.Services.Anuncio.Contracts;
public interface IAnuncioService
{
    Task<AnuncioViewModel> AdicionarAsync(AnuncioViewModel model);
    Task DeletarAsync(int anuncioId, string usuarioId);
    Task AtualizarAsync(AnuncioViewModel anuncioVM, string usuarioId);
}
