﻿using Bazar.Domain.Entities;
using Bazar.Domain.Interfaces.Repositories;
using Bazar.Infrastructure.Context;

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
}