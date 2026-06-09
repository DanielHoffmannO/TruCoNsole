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

    public Jogador? Resolver(Jogador jogador1, Jogador jogador2)
    {
        if (CartaJogador1 is null || CartaJogador2 is null)
            return null;

        if (CartaJogador1.Forca > CartaJogador2.Forca)
            Vencedor = jogador1;
        else if (CartaJogador2.Forca > CartaJogador1.Forca)
            Vencedor = jogador2;
        // empate = null (empardou)

        return Vencedor;
    }
}
