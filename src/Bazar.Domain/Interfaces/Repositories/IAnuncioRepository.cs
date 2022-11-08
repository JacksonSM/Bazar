using Bazar.Domain.Entities;

namespace Bazar.Domain.Interfaces.Repositories;
public interface IAnuncioRepository
{
    Task<Anuncio> Add(Anuncio anuncio);
}
