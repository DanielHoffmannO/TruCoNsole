namespace TruCoNsole.Domain.Entities;

public class Rodada
{
    public Carta? CartaJogador1 { get; private set; }
    public Carta? CartaJogador2 { get; private set; }
    public Jogador? Vencedor { get; private set; }

    public void RegistrarJogada(Jogador jogador, Carta carta, bool ehJogador1)
    {
        if (ehJogador1)
            CartaJogador1 = carta;
        else
            CartaJogador2 = carta;
    }

    public Jogador? Resolver(Jogador jogador1, Jogador jogador2, Carta? vira = null)
    {
        if (CartaJogador1 is null || CartaJogador2 is null)
            return null;

        var forca1 = CartaJogador1.ForcaComManilha(vira);
        var forca2 = CartaJogador2.ForcaComManilha(vira);

        if (forca1 > forca2)
            Vencedor = jogador1;
        else if (forca2 > forca1)
            Vencedor = jogador2;

        return Vencedor;
    }
}
