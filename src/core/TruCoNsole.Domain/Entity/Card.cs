
using TruCoNsole.Domain.Enum;

namespace TruCoNsole.Domain.Entity;

public class Card
{
    public Card(byte nipe, byte value)
    {
        Nipe = (ENipe) nipe;
        Value = (EValueCard) value;
    }

    public ENipe Nipe { get; set; }
    public EValueCard Value { get; set; }
}