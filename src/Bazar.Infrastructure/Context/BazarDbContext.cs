using Bazar.Domain.Entities;
using Bazar.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bazar.Infrastructure.Context;
public class BazarDbContext : IdentityDbContext<ApplicationUser>
{
    public BazarDbContext(DbContextOptions<BazarDbContext> options) : base(options) { }

    public DbSet<Anuncio> Anuncios { get; set; }
}
