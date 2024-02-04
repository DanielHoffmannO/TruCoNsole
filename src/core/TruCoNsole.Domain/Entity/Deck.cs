
namespace TruCoNsole.Domain.Entity;

public class Deck
{
    public Deck()
    {
        for (byte suit = 1; suit < 4; suit++)
            for (byte value = 1; value < 10; value++)
                Cards.Add(new Card(suit, value));
    }

    public List<Card> Cards { get; set; } = new();
}