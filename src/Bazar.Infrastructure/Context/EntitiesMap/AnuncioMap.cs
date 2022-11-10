using Bazar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Infrastructure.Context.EntitiesMap;
public class AnuncioMap : IEntityTypeConfiguration<Anuncio>
{
    public void Configure(EntityTypeBuilder<Anuncio> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Imagens)
               .IsRequired(false);

        builder.Property(x => x.AnuncianteId)
               .IsRequired();

        builder.Property(x => x.NomeAnunciante)
                .IsRequired();
    }
}
