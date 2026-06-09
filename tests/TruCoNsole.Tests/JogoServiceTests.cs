using TruCoNsole.Application.Services;
using TruCoNsole.Domain.Entities;

namespace TruCoNsole.Tests;

public class JogoServiceTests
{
    private readonly JogoService _jogo;

    public JogoServiceTests()
    {
        _jogo = new JogoService(new BaralhoService());
    }

    [Fact]
    public void IniciarPartida_DeveCriarDoisJogadores()
    {
        var partida = _jogo.IniciarPartida("Daniel");
        Assert.Equal("Daniel", partida.Jogador1.Nome);
        Assert.Equal("Bot", partida.Jogador2.Nome);
        Assert.True(partida.Jogador2.EhBot);
    }

    [Fact]
    public void DistribuirCartas_DeveDistribuir3CartasParaCadaJogador()
    {
        var partida = _jogo.IniciarPartida("Daniel");
        _jogo.DistribuirCartas(partida);

        Assert.Equal(3, partida.Jogador1.Mao.Count);
        Assert.Equal(3, partida.Jogador2.Mao.Count);
    }

    [Fact]
    public void EscolherCartaBot_DeveRemoverCartaDaMao()
    {
        var partida = _jogo.IniciarPartida("Daniel");
        _jogo.DistribuirCartas(partida);

        _jogo.EscolherCartaBot(partida.Jogador2);
        Assert.Equal(2, partida.Jogador2.Mao.Count);
    }
}
