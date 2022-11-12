using AutoMapper;
using Bazar.Application.ViewModel;
using Bazar.Domain.Account;
using Bazar.Domain.Interfaces;
using Bazar.Domain.Interfaces.Repositories;

namespace Bazar.Application.UseCase.Anuncio.Criar;
public class CriarAnuncioUseCase : ICriarAnuncioUseCase
{
    private readonly IUsuarioLogado _usuarioLogado;
    private readonly IAnuncioRepository _anuncioRepo;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CriarAnuncioUseCase(
        IUsuarioLogado usuarioLogado,
        IAnuncioRepository anuncioRepo,
        IUnitOfWork uow,
        IMapper mapper)
    {
        _anuncioRepo = anuncioRepo;
        _uow = uow;
        _mapper = mapper;
        _usuarioLogado = usuarioLogado;
    }

    public async Task AtualizarAnuncioAsync(AnuncioViewModel anuncioVM, string usuarioId)
    {
        var anuncioEntity = await _anuncioRepo.GetByIdAsync(anuncioVM.Id);

        if (anuncioEntity == null)
            throw new HttpRequestException("", null, statusCode: System.Net.HttpStatusCode.NotFound);

        if (!anuncioEntity.AnuncianteId.Equals(usuarioId))
            throw new HttpRequestException("", null, statusCode: System.Net.HttpStatusCode.Unauthorized);

        anuncioEntity.Atualiza
            (
                titulo: anuncioVM.Titulo,
                descricao: anuncioVM.Descricao,
                tempoUso: anuncioVM.TempoUso,
                cidade: anuncioVM.Cidade,
                preco: anuncioVM.Preco,
                telefoneAnunciante: anuncioVM.TelefoneAnunciante
            );

        _anuncioRepo.Update(anuncioEntity);
        await _uow.CommitAsync();
    }

    public async Task DeletarAnuncioAsync(int anuncioId, string usuarioId)
    {
        var anuncioEntity = await _anuncioRepo.GetByIdAsync(anuncioId);

        if (anuncioEntity == null)
            throw new HttpRequestException("", null, statusCode: System.Net.HttpStatusCode.NotFound);
        
        if(!anuncioEntity.AnuncianteId.Equals(usuarioId))
            throw new HttpRequestException("", null, statusCode: System.Net.HttpStatusCode.Unauthorized);

        anuncioEntity.DesativarAnuncio();
        _anuncioRepo.Update(anuncioEntity);
        await _uow.CommitAsync();
    }

    public async Task<AnuncioViewModel> ExecuteAsync(AnuncioViewModel model)
    {
        string nomeCompletoUsuarioLogado = await _usuarioLogado.ObterUsuarioNomeCompletoAsync();
        string idUsuarioLogado = _usuarioLogado.ObterUsuarioId();
        string telefoneUsuarioLogado = await _usuarioLogado.ObterUsuarioTelefoneAsync();

        var anuncioEntity = new Domain.Entities.Anuncio
            (
                titulo: model.Titulo,
                descricao: model.Descricao,
                tempoUso: model.TempoUso,
                cidade: model.Cidade,
                preco: model.Preco,
                imagemPrincipal: model.ImagemPrincipal,
                imagens: model.Imagens,
                nomeAnunciante: nomeCompletoUsuarioLogado,
                anuncianteId: idUsuarioLogado,
                telefoneAnunciante: telefoneUsuarioLogado
            );

        await _anuncioRepo.Add(anuncioEntity);
        await _uow.CommitAsync();

        return _mapper.Map<AnuncioViewModel>(anuncioEntity);
    }
}
