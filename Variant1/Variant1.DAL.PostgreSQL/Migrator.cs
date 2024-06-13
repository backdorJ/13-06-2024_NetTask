using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Variant1.DAL.PostgreSQL;

public class Migrator
{
    public readonly ILogger<Migrator> _logger;
    public readonly EfContext _context;

    public Migrator(ILogger<Migrator> logger, EfContext efContext)
    {
        _logger = logger;
        _context = efContext;
    }

    public async Task MigrateAsync(CancellationToken cancellationToken)
    {
        try
        {
            var guid = Guid.NewGuid();
            _logger.LogInformation($"Старт накатывания миграций {guid}");
            await _context.Database.MigrateAsync(cancellationToken);
            _logger.LogInformation($"Конец накатывания миграций {guid}");
        }
        catch (Exception e)
        {
            _logger.LogCritical($"Что то пощло не так при накатывания миграции: {e.Message}");
        }
    }
}