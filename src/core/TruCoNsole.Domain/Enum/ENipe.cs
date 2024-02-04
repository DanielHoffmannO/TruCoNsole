
using System.ComponentModel;

public enum ENipe : byte
{
    [Description("♣️")]
    Clube = 4,
    [Description("♥️")]
    Coracao = 3,
    [Description("♠️")]
    Espada = 2,
    [Description("♦️")]
    Diamante = 1,
}

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
        return attribute == null ? value.ToString() : attribute.Description;
    }
}