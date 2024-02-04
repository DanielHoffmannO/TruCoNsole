
namespace TruCoNsole.Domain.Entity;

public class Deck
{
    public Deck()
    {
        for (byte nipe = 1; nipe < 4; nipe++)
            for (byte value = 1; value < 10; value++)
                Cards.Add(new(nipe, value));
    }

    public List<Card> Cards { get; set; } = new List<Card>();
}