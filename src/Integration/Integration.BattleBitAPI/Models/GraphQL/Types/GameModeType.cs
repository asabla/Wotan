using HotChocolate;

namespace Wotan.Integration.BattleBitAPI.Models.GraphQL.Types;

[GraphQLDescription("Supported game modes")]
public enum GameModeType
{
    [GraphQLDescription("None - was unable to prase value")]
    None,

    [GraphQLDescription("Conquest")]
    CONQ,

    [GraphQLDescription("Domination")]
    DOMI,

    [GraphQLDescription("Elimination")]
    ELI,

    [GraphQLDescription("Frontline")]
    FRONTLINE,

    [GraphQLDescription("Gun game free for all")]
    GunGameFFA,

    [GraphQLDescription("Infantry Conquest")]
    INFCONQ,

    [GraphQLDescription("Rush")]
    RUSH,

    [GraphQLDescription("Team death match")]
    TDM
}