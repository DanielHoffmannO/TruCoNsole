using TruCoNsole.Domain.Entities;
using TruCoNsole.Domain.Enums;
using TruCoNsole.Domain.Interfaces;

namespace TruCoNsole.Application.Services;

public class BaralhoService : IBaralhoService
{
    private List<Carta> _cartas = new();
    private readonly Random _random = new();

    public BaralhoService()
    {
        GerarBaralho();
    }

    private void GerarBaralho()
    {
        _cartas.Clear();
        foreach (Naipe naipe in Enum.GetValues<Naipe>())
        foreach (Valor valor in Enum.GetValues<Valor>())
            _cartas.Add(new Carta(valor, naipe));
    }

    public void Embaralhar()
    {
        GerarBaralho();
        for (int i = _cartas.Count - 1; i > 0; i--)
        {
            int j = _random.Next(i + 1);
            (_cartas[i], _cartas[j]) = (_cartas[j], _cartas[i]);
        }
    }

    public List<Carta> Distribuir(int quantidade)
    {
        var mao = _cartas.Take(quantidade).ToList();
        _cartas.RemoveRange(0, quantidade);
        return mao;
    }

    public Carta Virar()
    {
        var carta = _cartas[0];
        _cartas.RemoveAt(0);
        return carta;
    }
}
