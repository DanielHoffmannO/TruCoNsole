using TruCoNsole.Domain.Entities;

namespace TruCoNsole.Domain.Interfaces;

public interface IJogoService
{
    Partida IniciarPartida(string nomeJogador);
    void DistribuirCartas(Partida partida);
    Rodada IniciarRodada(Partida partida);
    Jogador? ResolverRodada(Rodada rodada, Partida partida);
    Jogador? ResolverMao(Partida partida);
    bool PedirTruco(Partida partida);
    Carta EscolherCartaBot(Jogador bot);
}
