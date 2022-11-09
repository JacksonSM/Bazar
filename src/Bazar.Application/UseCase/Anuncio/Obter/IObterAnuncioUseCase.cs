using Bazar.Application.ViewModel;

namespace Bazar.Application.UseCase.Anuncio.Obter;

public interface IObterAnuncioUseCase
{
    Task<List<AnuncioViewModel>> GetAllAsync();
    Task<AnuncioViewModel> GetByIdAsync(int id);
}
