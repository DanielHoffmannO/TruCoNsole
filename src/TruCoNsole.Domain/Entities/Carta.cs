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

    public int ForcaComManilha(Carta? vira)
    {
        if (vira is null) return Forca;
        var valorManilha = ProximoValor(vira.Valor);
        if (Valor != valorManilha) return Forca;

        // Manilhas: Paus < Copas < Espadas < Ouros (zap)
        return 11 + Naipe switch
        {
            Naipe.Paus => 1,
            Naipe.Copas => 2,
            Naipe.Espadas => 3,
            Naipe.Ouros => 4,
            _ => 0
        };
    }

    private static Valor ProximoValor(Valor valor) => valor switch
    {
        Valor.Quatro => Valor.Cinco,
        Valor.Cinco => Valor.Seis,
        Valor.Seis => Valor.Sete,
        Valor.Sete => Valor.Dama,
        Valor.Dama => Valor.Valete,
        Valor.Valete => Valor.Rei,
        Valor.Rei => Valor.As,
        Valor.As => Valor.Dois,
        Valor.Dois => Valor.Tres,
        Valor.Tres => Valor.Quatro,
        _ => Valor.Quatro
    };

    public bool EhManilha(Carta? vira) => vira is not null && Valor == ProximoValor(vira.Valor);

    public override string ToString() => $"{Valor} de {Naipe}";
}
