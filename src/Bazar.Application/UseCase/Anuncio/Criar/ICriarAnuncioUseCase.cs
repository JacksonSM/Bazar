using Bazar.Application.ViewModel;

namespace Bazar.Application.UseCase.Anuncio.Criar;
public interface ICriarAnuncioUseCase
{
    Task<AnuncioViewModel> ExecuteAsync(AnuncioViewModel model);
    Task DeletarAnuncioAsync(int anuncioId, string usuarioId);
    Task AtualizarAnuncioAsync(AnuncioViewModel anuncioVM, string usuarioId);
}
