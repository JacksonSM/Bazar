using Bazar.Domain.Entities;

namespace Bazar.Domain.Interfaces.Repositories;
public interface IAnuncioRepository
{
    Task<Anuncio> Add(Anuncio anuncio);
    Task<(IEnumerable<Anuncio>, int totalAnuncios)> GetAllAsync(string titulo, string cidade,
        int? paginaAtual, int? itensPorPagina);
    Task<Anuncio> GetByIdAsync(int id);
    Task<IEnumerable<Anuncio>> GetByUsuarioId(string usuarioId);
}
