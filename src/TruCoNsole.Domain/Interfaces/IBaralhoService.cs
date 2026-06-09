using TruCoNsole.Domain.Entities;

namespace TruCoNsole.Domain.Interfaces;

public interface IBaralhoService
{
    void Embaralhar();
    List<Carta> Distribuir(int quantidade);
}
