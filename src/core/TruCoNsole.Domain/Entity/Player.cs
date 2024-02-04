
using TruCoNsole.Domain.Entity;

namespace TruCoConsole.Application.Service
{
    public class Player
    {
        public Player(Card[] cards)
        {
            Cards = cards;
        }

        public byte Points { get; set; }
        public byte Tentos { get; set; }
        public byte Choice { get; set; } = 255;
        public Card[] Cards { get; set; }

        public Card UseCard(byte cardIndex)
        {
            Cards[cardIndex].Used = true;
            Choice = cardIndex;
            return Cards[cardIndex];
        }

        public Card[] UsedCards() => Cards.Where(card => card.Used).ToArray();

        public void ResetTentos() => Tentos = 0;
    }
}