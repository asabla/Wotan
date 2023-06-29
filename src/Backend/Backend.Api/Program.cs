using Wotan.Backend.Api.Settings;
using Wotan.Backend.Api.GraphQL.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder
    .APIConfigurationSetup()
    .ConfigureGraphQLServer();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapGraphQL();

// Only used for heart beats (such as Application Insight)
app.MapGet("/", () => StatusCodes.Status200OK);

// Used for handling startup parameteres regarding Hotchocolate
// such as generating a schema without starting the API
await app.RunWithGraphQLCommandsAsync(args);
