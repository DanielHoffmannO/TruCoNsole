using TruCoNsole.Domain.Enums;

namespace TruCoNsole.Domain.Entities;

public class Carta
{
    public Valor Valor { get; }
    public Naipe Naipe { get; }
    public int Forca => (int)Valor;

    public Carta(Valor valor, Naipe naipe)
    {
        Valor = valor;
        Naipe = naipe;
    }

    public override string ToString() => $"{Valor} de {Naipe}";
}
