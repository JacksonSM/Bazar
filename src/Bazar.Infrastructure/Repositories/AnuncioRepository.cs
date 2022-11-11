using Bazar.Domain.Entities;
using Bazar.Domain.Interfaces.Repositories;
using Bazar.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Bazar.Infrastructure.Repositories;
public class AnuncioRepository : IAnuncioRepository
{
    private readonly BazarDbContext _context;

    public AnuncioRepository(BazarDbContext context)
    {
        _context = context;
    }

    public async Task<Anuncio> Add(Anuncio anuncio)
    {
        await _context.Anuncios.AddAsync(anuncio);
        return anuncio;
    }
    public string? Titulo { get; set; }
    public string? Cidade { get; set; }
    public int? PaginaAtual { get; set; }
    public int? ItensPorPagina { get; set; }

    public async Task<(IEnumerable<Anuncio>, int totalAnuncios)> GetAllAsync(
        string? titulo, string? cidade,
        int? paginaAtual, int? itensPorPagina)
    {
        var query = _context.Anuncios.AsQueryable();
        
        if(!string.IsNullOrEmpty(titulo))
            query.Where(x => x.Titulo.ToLower().Contains(titulo.ToLower()));

        if (!string.IsNullOrEmpty(cidade))
            query.Where(x => x.Cidade.ToLower().Contains(cidade.ToLower()));

        if (!(paginaAtual.HasValue && itensPorPagina.HasValue))    
            return (await query.ToListAsync(), query.Count());
        

        var anuncios = await query.Skip((paginaAtual.Value - 1) * itensPorPagina.Value)
                                  .Take(itensPorPagina.Value).ToListAsync();

        return (anuncios , query.Count());
    }

    public async Task<Anuncio> GetByIdAsync(int id) =>
        await _context.Anuncios.FirstOrDefaultAsync(x => x.Id == id);
}
