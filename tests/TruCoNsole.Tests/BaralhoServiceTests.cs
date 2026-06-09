using TruCoNsole.Application.Services;

namespace TruCoNsole.Tests;

public class BaralhoServiceTests
{
    private readonly BaralhoService _baralho = new();

    [Fact]
    public void Embaralhar_DeveGerarBaralhoCompleto()
    {
        _baralho.Embaralhar();
        var cartas = _baralho.Distribuir(40);
        Assert.Equal(40, cartas.Count);
    }

    [Fact]
    public void Distribuir_DeveRetornarQuantidadePedida()
    {
        _baralho.Embaralhar();
        var mao = _baralho.Distribuir(3);
        Assert.Equal(3, mao.Count);
    }

    [Fact]
    public void Distribuir_NaoDeveRepetirCartas()
    {
        _baralho.Embaralhar();
        var mao1 = _baralho.Distribuir(3);
        var mao2 = _baralho.Distribuir(3);

        foreach (var carta in mao1)
            Assert.DoesNotContain(carta, mao2);
    }
}
