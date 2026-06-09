using TruCoNsole.Domain.Enums;

namespace TruCoNsole.Domain.Entities;

public class Partida
{
    public Jogador Jogador1 { get; }
    public Jogador Jogador2 { get; }
    public List<Rodada> Rodadas { get; } = new();
    public StatusPartida Status { get; set; } = StatusPartida.Aguardando;
    public int ValorMao { get; set; } = 1;
    public Jogador? VencedorMao { get; private set; }
    public Carta? Vira { get; set; }
    public const int PontosParaVencer = 12;

    public Partida(Jogador jogador1, Jogador jogador2)
    {
        Jogador1 = jogador1;
        Jogador2 = jogador2;
    }

    public Rodada NovaRodada()
    {
        var rodada = new Rodada();
        Rodadas.Add(rodada);
        return rodada;
    }

    public Jogador? ResolverMao()
    {
        int vitoriasJ1 = 0, vitoriasJ2 = 0;

        foreach (var rodada in Rodadas)
        {
            if (rodada.Vencedor == Jogador1) vitoriasJ1++;
            else if (rodada.Vencedor == Jogador2) vitoriasJ2++;
        }

        if (vitoriasJ1 >= 2) VencedorMao = Jogador1;
        else if (vitoriasJ2 >= 2) VencedorMao = Jogador2;
        else if (Rodadas.Count == 3 && vitoriasJ1 == vitoriasJ2)
            VencedorMao = Rodadas[0].Vencedor; // quem ganhou a primeira

        return VencedorMao;
    }

    public void AplicarPontos()
    {
        if (VencedorMao is not null)
            VencedorMao.Pontos += ValorMao;
    }

    public void ResetarMao()
    {
        Rodadas.Clear();
        VencedorMao = null;
        ValorMao = 1;
    }

    public Jogador? Vencedor()
    {
        if (Jogador1.Pontos >= PontosParaVencer) return Jogador1;
        if (Jogador2.Pontos >= PontosParaVencer) return Jogador2;
        return null;
    }
}
