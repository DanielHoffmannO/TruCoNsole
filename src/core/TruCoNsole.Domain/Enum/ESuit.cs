using System.ComponentModel;

namespace TruCoNsole.Domain.Enum;

public enum ESuit : byte
{
    [Description("♣️")]
    Club = 4,
    [Description("♥️")]
    Heart = 3,
    [Description("♠️")]
    Spade = 2,
    [Description("♦️")]
    Diamond = 1,
}