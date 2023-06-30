using HotChocolate;

namespace Wotan.Integration.BattleBitAPI.Models.GraphQL.Types;

[GraphQLDescription("Supported AntiCheat systems")]
public enum AntiCheatType
{
    [GraphQLDescription("No detected Anti system is active")]
    None,

    [GraphQLDescription("Easy AntiCheat")]
    EAC
}