using Microsoft.Extensions.DependencyInjection;
using Variant1.Core.Abstractions;

namespace Variant1.DAL.PostgreSQL;

public static class Entry
{
    public static void AddDAL(this IServiceCollection services)
    {
        services.AddScoped<IDbContext, EfContext>();
        services.AddTransient<Migrator>();
    }
}