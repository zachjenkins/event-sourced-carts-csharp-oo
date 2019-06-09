using Carts.Domain.CartAggregate;
using Carts.Infrastructure.Internal.EventStore;
using Carts.Infrastructure.Internal.InternalContracts;
using Carts.Infrastructure.Internal.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Carts.Infrastructure
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services)
            => services
                .AddTransient<ICartsRepository, CartsRepository>()
                .AddTransient<IEventStore, MongoEventStore>();
    }
}
