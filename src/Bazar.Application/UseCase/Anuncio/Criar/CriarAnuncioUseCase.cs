using AutoMapper;
using Bazar.Application.ViewModel;
using Bazar.Domain.Interfaces;
using Bazar.Domain.Interfaces.Repositories;

namespace Bazar.Application.UseCase.Anuncio.Criar;
public class CriarAnuncioUseCase : ICriarAnuncioUseCase
{
    private readonly IAnuncioRepository _anuncioRepo;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CriarAnuncioUseCase(IAnuncioRepository anuncioRepo, IUnitOfWork uow, IMapper mapper)
    {
        _anuncioRepo = anuncioRepo;
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<AnuncioViewModel> ExecuteAsync(AnuncioViewModel model)
    {
        var anuncioEntity = new Domain.Entities.Anuncio
            (
                titulo: model.Titulo,
                descricao: model.Descricao,
                tempoUso: model.TempoUso,
                cidade: model.Cidade,
                preco: model.Preco,
                imagemPrincipal: model.ImagemPrincipal,
                imagens: model.Imagens
            );

        await _anuncioRepo.Add(anuncioEntity);
        await _uow.CommitAsync();

        return _mapper.Map<AnuncioViewModel>(anuncioEntity);
    }
}
