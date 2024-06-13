using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Variant1.Core.Services.DateTimeProvider;

namespace Variant1.Core;

public static class Entry
{
    public static void AddCore(this IServiceCollection services)
    {
        services.AddMediatR(conf => conf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
    }
}