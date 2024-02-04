using TruCoConsole.Application.Service;
using TruCoNsole.Domain.Entity;

namespace TruCoNsole.Application.Service;

public static class TelaService
{
    public static void ExibirCartas(Board board)
    {
        Console.Clear();

        ExibirPontos(board.Bot);
        ExibirCartasBot(board.Bot);

        ExibirCartasTombo(board.Tombo);

        ExibirCartasPeople(board.People);
        ExibirPontos(board.People);
    }

    private static void ExibirCartasBot(Player player)
    {
        for (byte linha = 0; linha <= 6; linha++)
        {
            for (byte index = 0; index < player.Cards.Length; index++)
            {
                if (player.Escolha == index || player.Cards[index].Usada)
                {
                    string[] carta = player.Cards[index].MontaCarta();

                    int indice = linha - (player.Escolha != index ? 0 : 2);
                    string valorExibido = (indice >= 0 && indice < carta.Length) ? carta[indice] : "      ";
                    Console.Write("   " + valorExibido);
                }
                else
                {
                    string[] carta = player.Cards[index].MontaCartaBunda();

                    int indice = linha - (player.Escolha != index ? 0 : 2);
                    string valorExibido = (indice >= 0 && indice < carta.Length) ? carta[indice] : "      ";
                    Console.Write("   " + valorExibido);
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    private static void ExibirPontos(Player player)
    {
        Console.WriteLine($"==|Pontos ({player.Pontos})|===|Tento ({player.Tentos})|==\n");
    }

    private static void ExibirCartasTombo(Card cartas)
    {
        for (int linha = 0; linha <= 4; linha++)
            Console.WriteLine("            " + cartas.MontaCarta()[linha]);
        Console.WriteLine();
    }

    private static void ExibirCartasPeople(Player player)
    {
        for (byte linha = 0; linha <= 6; linha++)
        {
            for (byte index = 0; index < player.Cards.Length; index++)
            {
                if (player.Escolha != index && player.Cards[index].Usada)
                {
                    string[] carta = player.Cards[index].MontaCartaBunda();
                    int indice = linha - (player.Escolha == index ? 0 : 2);
                    string valorExibido = (indice >= 0 && indice < carta.Length) ? carta[indice] : "      ";
                    Console.Write("   " + valorExibido);
                }
                else
                {
                    string[] carta = player.Cards[index].MontaCarta();

                    if (player.Escolha == index || linha > 1)
                    {
                        int indice = linha - (player.Escolha == index ? 0 : 2);
                        string valorExibido = (indice >= 0 && indice < carta.Length) ? carta[indice] : "      ";
                        Console.Write("   " + valorExibido);
                    }
                    else
                        Console.Write("         ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine("      [1]      [2]      [3]\n");
    }
}