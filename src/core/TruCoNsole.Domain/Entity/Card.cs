
using TruCoNsole.Domain.Enum;

namespace TruCoNsole.Domain.Entity;

public class Card
{
    public Card(byte suit, byte value)
    {
        Suit = (ESuit)suit;
        Value = (EValueCard)value;
    }

    public ESuit Suit { get; set; }
    public EValueCard Value { get; set; }
    public bool Manilha { get; set; }
    public bool Used { get; set; }

    public string[] BuildCard()
    {
        string[] card = new string[5];

        card[0] = "+----+";
        card[1] = $"|{Value.GetDescription()}   |";
        card[2] = $"| {Suit.GetDescription()} |";
        card[3] = $"|   {Value.GetDescription()}|";
        card[4] = "+----+";

        return card;
    }

    public string[] BuildBackCard()
    {
        string[] card = new string[5];

        card[0] = "+----+";
        card[1] = "|/\\\\/|";
        card[2] = "|\\//\\|";
        card[3] = "|/\\/\\|";
        card[4] = "+----+";

        return card;
    }
}