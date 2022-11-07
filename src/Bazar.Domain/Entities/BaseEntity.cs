namespace Bazar.Domain.Entities;
public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTimeOffset DataCriacao { get; set; }
}
