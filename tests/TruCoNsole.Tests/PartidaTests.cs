using TruCoNsole.Domain.Entities;
using TruCoNsole.Domain.Enums;

namespace TruCoNsole.Tests;

public class PartidaTests
{
    [Fact]
    public void Vencedor_QuandoNinguemTemPontos_DeveRetornarNull()
    {
        var partida = new Partida(new Jogador("A"), new Jogador("B"));
        Assert.Null(partida.Vencedor());
    }

    [Fact]
    public void Vencedor_QuandoJogador1Tem12Pontos_DeveRetornarJogador1()
    {
        var j1 = new Jogador("A") { Pontos = 12 };
        var partida = new Partida(j1, new Jogador("B"));
        Assert.Equal(j1, partida.Vencedor());
    }

    [Fact]
    public void Rodada_CartaMaiorDeveVencer()
    {
        var j1 = new Jogador("A");
        var j2 = new Jogador("B");
        var rodada = new Rodada();

        var cartaForte = new Carta(Valor.Tres, Naipe.Paus);
        var cartaFraca = new Carta(Valor.Quatro, Naipe.Ouros);

        rodada.RegistrarJogada(j1, cartaForte, true);
        rodada.RegistrarJogada(j2, cartaFraca, false);

        var vencedor = rodada.Resolver(j1, j2);
        Assert.Equal(j1, vencedor);
    }

    [Fact]
    public void Rodada_CartasIguais_DeveEmpatar()
    {
        var j1 = new Jogador("A");
        var j2 = new Jogador("B");
        var rodada = new Rodada();

        var carta1 = new Carta(Valor.Sete, Naipe.Paus);
        var carta2 = new Carta(Valor.Sete, Naipe.Ouros);

        rodada.RegistrarJogada(j1, carta1, true);
        rodada.RegistrarJogada(j2, carta2, false);

        var vencedor = rodada.Resolver(j1, j2);
        Assert.Null(vencedor);
    }

    [Fact]
    public void Jogador_JogarCarta_DeveRemoverDaMao()
    {
        var jogador = new Jogador("Test");
        jogador.ReceberCartas(new List<Carta>
        {
            new(Valor.As, Naipe.Copas),
            new(Valor.Dois, Naipe.Espadas),
            new(Valor.Tres, Naipe.Paus)
        });

        var carta = jogador.JogarCarta(1);
        Assert.Equal(Valor.Dois, carta.Valor);
        Assert.Equal(2, jogador.Mao.Count);
    }
}
