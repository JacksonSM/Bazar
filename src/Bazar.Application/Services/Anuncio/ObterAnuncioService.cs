using AutoMapper;
using Bazar.Application.Request;
using Bazar.Application.Response;
using Bazar.Application.Services.Anuncio.Contracts;
using Bazar.Application.ViewModel;
using Bazar.Domain.Interfaces.Repositories;

namespace Bazar.Application.Services.Anuncio;
public class ObterAnuncioService : IObterAnuncioService
{
    private readonly IAnuncioRepository _anuncioRepo;
    private readonly IMapper _mapper;

    public ObterAnuncioService (IAnuncioRepository anuncioRepo, IMapper mapper)
    {
        _anuncioRepo = anuncioRepo;
        _mapper = mapper;
    }

    public async Task<ObterAnuncioResponse> ObterTodosAsync(ObterAnuncioRequest query)
    {
        (var anunciosEntity, int totalAnuncios) = await _anuncioRepo.GetAllAsync
            (
                titulo: query.Titulo,
                cidade: query.Cidade,
                paginaAtual: query.PaginaAtual,
                itensPorPagina: query.ItensPorPagina
            );

        var totalPaginas = Math.Ceiling(totalAnuncios / (decimal)query.ItensPorPagina.Value);

        Paginacao paginacao = new()
        {
            PaginaAtual = query.PaginaAtual.Value,
            ItensPorPagina = query.ItensPorPagina.Value,
            TotalAnuncio = totalAnuncios,
            TotalPaginas = (int) totalPaginas
        };

        var anunciosVM = _mapper.Map<List<AnuncioViewModel>>(anunciosEntity);

        return new ObterAnuncioResponse
        {
            anunciosVM = anunciosVM,
            Paginacao = paginacao
        };
    }

    public async Task<AnuncioViewModel> ObterPoIdAsync(int id)
    {
        var anuncioEntity = await _anuncioRepo.GetByIdAsync(id);

        return _mapper.Map<AnuncioViewModel>(anuncioEntity);
    }

    public async Task<IEnumerable<AnuncioViewModel>> ObterAnuncioDoUsuarioAsync(string id)
    {
        var anunciosEntity = await _anuncioRepo.GetByUsuarioId(id);

        return _mapper.Map<List<AnuncioViewModel>>(anunciosEntity);
    }
}
