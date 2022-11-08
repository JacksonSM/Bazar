using Bazar.Domain.Interfaces;

namespace Bazar.Infrastructure.Context;
public class UnitOfWork : IUnitOfWork
{
    private readonly BazarDbContext _context;

    public UnitOfWork(BazarDbContext context)
    {
        _context = context;
    }

    public async Task CommitAsync()
        => await _context.SaveChangesAsync();
}
