using TruCoNsole.Domain.Entities;
using TruCoNsole.Domain.Enums;
using TruCoNsole.Domain.Interfaces;

namespace TruCoNsole.Application.Services;

public class JogoService : IJogoService
{
    private readonly IBaralhoService _baralho;
    private readonly Random _random = new();

    public JogoService(IBaralhoService baralho)
    {
        _baralho = baralho;
    }

    public Partida IniciarPartida(string nomeJogador)
    {
        var jogador = new Jogador(nomeJogador);
        var bot = new Jogador("Bot", ehBot: true);
        var partida = new Partida(jogador, bot) { Status = StatusPartida.EmAndamento };
        return partida;
    }

    public void DistribuirCartas(Partida partida)
    {
        _baralho.Embaralhar();
        partida.Jogador1.ReceberCartas(_baralho.Distribuir(3));
        partida.Jogador2.ReceberCartas(_baralho.Distribuir(3));
    }

    public Rodada IniciarRodada(Partida partida) => partida.NovaRodada();

    public Jogador? ResolverRodada(Rodada rodada, Partida partida)
        => rodada.Resolver(partida.Jogador1, partida.Jogador2);

    public Jogador? ResolverMao(Partida partida) => partida.ResolverMao();

    public bool PedirTruco(Partida partida)
    {
        // Bot aceita com 60% de chance
        bool aceita = _random.Next(100) < 60;
        if (aceita)
            partida.ValorMao = partida.ValorMao switch
            {
                1 => 3,
                3 => 6,
                6 => 9,
                9 => 12,
                _ => partida.ValorMao
            };
        return aceita;
    }

    public Carta EscolherCartaBot(Jogador bot)
    {
        // Bot joga a carta mais fraca disponível
        var indice = 0;
        for (int i = 1; i < bot.Mao.Count; i++)
        {
            if (bot.Mao[i].Forca < bot.Mao[indice].Forca)
                indice = i;
        }
        return bot.JogarCarta(indice);
    }
}
