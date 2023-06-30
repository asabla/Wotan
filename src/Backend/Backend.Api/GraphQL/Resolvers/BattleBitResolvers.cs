using Wotan.Backend.Api.GraphQL.Extensions;

using Wotan.Integration.BattleBitAPI.Models.GraphQL;
using Wotan.Integration.BattleBitAPI.Models.GraphQL.Types;
using Wotan.Integration.BattleBitAPI.Services;

namespace Wotan.Backend.Api.GraphQL.Resolvers;

[ExtendObjectType(nameof(Query))]
public sealed class BattleBitResolvers
{
    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("Fetches all BattleBit servers from public API")]
    public async Task<IReadOnlyList<ServerInfo>> GetBattleBitServers(
        BattleBitAPIService bService,
        CancellationToken cancellationToken)
        => await bService.GetAllServerAsync(cancellationToken)
            .ContinueWith(serviceTask => serviceTask.Result
                .Select(x => new ServerInfo
                {
                    AntiCheat = x.AntiCheat.CastTo<AntiCheatType>(),
                    Build = x.Build,
                    DayNight = x.DayNight.CastTo<DayNightType>(),
                    GameMode = x.Gamemode.CastTo<GameModeType>(),
                    HasPassword = x.HasPassword,
                    Hz = x.Hz,
                    IsOfficial = x.IsOfficial,
                    Map = x.Map.CastTo<MapType>(),
                    MapSize = x.MapSize.CastTo<MapSizeType>(),
                    MaxPlayers = x.MaxPlayers,
                    Name = x.Name,
                    Players = x.Players,
                    QueuePlayers = x.QueuePlayers,
                    Region = x.Region.CastTo<RegionType>()
                }).ToList());

}