using AutoMapper;
using Bazar.Application.ViewModel;
using Bazar.Domain.Interfaces.Repositories;

namespace Bazar.Application.UseCase.Anuncio.Obter;
public class ObterAnuncioUseCase : IObterAnuncioUseCase
{
    private readonly IAnuncioRepository _anuncioRepo;
    private readonly IMapper _mapper;

    public ObterAnuncioUseCase(IAnuncioRepository anuncioRepo, IMapper mapper)
    {
        _anuncioRepo = anuncioRepo;
        _mapper = mapper;
    }

    public async Task<List<AnuncioViewModel>> GetAllAsync()
    {
        var anunciosEntity = await _anuncioRepo.GetAllAsync();

        return _mapper.Map<List<AnuncioViewModel>>(anunciosEntity);
    }

    public async Task<AnuncioViewModel> GetByIdAsync(int id)
    {
        var anuncioEntity = await _anuncioRepo.GetByIdAsync(id);

        return _mapper.Map<AnuncioViewModel>(anuncioEntity);
    }
}
