using AutoMapper;
using Bazar.Application.Request;
using Bazar.Application.Response;
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

    public async Task<ObterAnuncioResponse> GetAllAsync(AnuncioQuery query)
    {
        (var anunciosEntity, int totalAnuncios) = await _anuncioRepo.GetAllAsync
            (
                titulo: query.Titulo,
                cidade: query.Cidade,
                paginaAtual: query.PaginaAtual,
                itensPorPagina: query.ItensPorPagina
            );

        Paginacao paginacao = new()
        {
            PaginaAtual = query.PaginaAtual.Value,
            ItensPorPagina = query.ItensPorPagina.Value,
            TotalAnuncio = totalAnuncios,
            TotalPaginas = (totalAnuncios / query.ItensPorPagina.Value)
        };

        var anunciosVM = _mapper.Map<List<AnuncioViewModel>>(anunciosEntity);

        return new ObterAnuncioResponse
        {
            anunciosVM = anunciosVM,
            Paginacao = paginacao
        };
    }

    public async Task<AnuncioViewModel> GetByIdAsync(int id)
    {
        var anuncioEntity = await _anuncioRepo.GetByIdAsync(id);

        return _mapper.Map<AnuncioViewModel>(anuncioEntity);
    }

    public async Task<IEnumerable<AnuncioViewModel>> ObterAnuncioUsuario(string id)
    {
        var anunciosEntity = await _anuncioRepo.GetByUsuarioId(id);

        return _mapper.Map<List<AnuncioViewModel>>(anunciosEntity);
    }
}
