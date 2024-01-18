
using System;
using TruCoNsole.Domain.Enum;

namespace TruCoNsole.Domain.Entity;

public class Deck
{
    public Deck()
    {
        for (byte nipe = 0; nipe < 4; nipe++)
            for (byte value = 0; value < 10; value++)
                Cards.Add(new(nipe, value));
    }

    public List<Card> Cards { get; set; } = new List<Card>();
}
