using Bazar.Application.Request;
using Bazar.Application.Response;
using Bazar.Application.ViewModel;

namespace Bazar.Application.UseCase.Anuncio.Obter;

public interface IObterAnuncioUseCase
{
    Task<ObterAnuncioResponse> GetAllAsync(AnuncioQuery query);
    Task<AnuncioViewModel> GetByIdAsync(int id);
}
