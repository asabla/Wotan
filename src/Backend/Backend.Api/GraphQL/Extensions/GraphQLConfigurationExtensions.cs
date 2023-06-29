using HotChocolate.Types.Pagination;

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
            .AddSorting();

        return builder;
    }
}