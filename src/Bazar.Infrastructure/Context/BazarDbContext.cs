using Bazar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bazar.Infrastructure.Context;
public class BazarDbContext : DbContext
{
    public BazarDbContext(DbContextOptions<BazarDbContext> options) : base(options) { }

    public DbSet<Anuncio> Anuncios { get; set; }
}
