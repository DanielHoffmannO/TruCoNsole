
using System;

namespace TruCoNsole.Domain.Entity;

public class Board
{
    private static readonly Random random = new();

    public Board()
    {
        Deck = new Deck();
        Deck.Cards = Deck.Cards.OrderBy(x => random.Next()).ToList();

        Tombo = Deck.Cards[0];
        PeopleCards = Deck.Cards.Skip(1).Take(3).ToArray();
        BotCards = Deck.Cards.Skip(4).Take(3).ToArray();
    }

    public Deck Deck { get; private set; }

    public Card Tombo { get; private set; }
    public Card[] PeopleCards { get; private set; }
    public Card[] BotCards { get; private set; }
}
