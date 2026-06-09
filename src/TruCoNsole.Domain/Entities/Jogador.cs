namespace TruCoNsole.Domain.Entities;

public class Jogador
{
    public string Nome { get; }
    public List<Carta> Mao { get; private set; } = new();
    public int Pontos { get; set; }
    public bool EhBot { get; }

    public Jogador(string nome, bool ehBot = false)
    {
        Nome = nome;
        EhBot = ehBot;
    }

    public void ReceberCartas(List<Carta> cartas) => Mao = cartas;

    public Carta JogarCarta(int indice)
    {
        var carta = Mao[indice];
        Mao.RemoveAt(indice);
        return carta;
    }
}
