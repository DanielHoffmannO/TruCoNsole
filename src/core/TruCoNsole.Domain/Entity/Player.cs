
using System;
using TruCoNsole.Domain.Entity;
using TruCoNsole.Domain.Enum;

namespace TruCoConsole.Application.Service;

public class Player
{
    public Player(Card[] cards)
    {
        Cards = cards;
    }

    public byte Pontos { get; set; }
    public byte Tentos { get; set; }
    public byte Escolha { get; set; } = 255;
    public Card[] Cards { get; set; }

    public Card UsarCarta(byte Card)
    {
        Cards[Card].Usada = true;
        Escolha = Card;
        return Cards[Card];
    }

    public Card[] CartasUsadas() => Cards.Where(x => x.Usada).ToArray();

    public void ResetTentos() => Tentos = 0;
}
