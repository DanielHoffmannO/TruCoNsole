
using System.ComponentModel;

namespace TruCoNsole.Domain.Enum
{
    public enum EValueCard : byte
    {
        [Description("3")]
        C3 = 10,
        [Description("2")]
        C2 = 9,
        [Description("A")]
        CA = 8,
        [Description("K")]
        CK = 7,
        [Description("Q")]
        CQ = 6,
        [Description("J")]
        CJ = 5,
        [Description("7")]
        C7 = 4,
        [Description("6")]
        C6 = 3,
        [Description("5")]
        C5 = 2,
        [Description("4")]
        C4 = 1,
    }
}