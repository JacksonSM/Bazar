namespace Bazar.Domain.Interfaces;
public interface IUnitOfWork
{
    Task CommitAsync();
}
