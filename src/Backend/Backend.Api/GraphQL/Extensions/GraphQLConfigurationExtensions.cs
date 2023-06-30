using HotChocolate.Execution.Configuration;
using HotChocolate.Types.Pagination;

using Wotan.Integration.BattleBitAPI.Services;
using Wotan.Integration.SteamAPI.Services;

namespace Wotan.Backend.Api.GraphQL.Extensions;

internal static class GraphQLConfigurationExtensions
{
    public static WebApplicationBuilder ConfigureGraphQLServer(
        this WebApplicationBuilder builder)
    {
        builder.Services
            .AddMemoryCache()   // Used by persisted queries
            .AddGraphQLServer()
                .InitializeOnStartup()
                .ModifyRequestOptions(opt =>
                {
                    opt.Complexity.Enable = true;
                    opt.Complexity.MaximumAllowed = 1500;
                })
                .SetPagingOptions(new PagingOptions
                {
                    DefaultPageSize = 10,
                    MaxPageSize = 200,
                    IncludeTotalCount = true
                })
                .UseAutomaticPersistedQueryPipeline()
            .AddInMemoryQueryStorage()
            .AddGraphQLTypes()
            .AddFiltering()
            .AddProjections()
            .AddSorting()
            .RegisterAPIServices();

        return builder;
    }

    private static IRequestExecutorBuilder RegisterAPIServices(
        this IRequestExecutorBuilder builder)
    {
        builder
            .RegisterService<BattleBitAPIService>(ServiceKind.Resolver)
            .RegisterService<SteamAPIService>(ServiceKind.Resolver);

        return builder;
    }
}