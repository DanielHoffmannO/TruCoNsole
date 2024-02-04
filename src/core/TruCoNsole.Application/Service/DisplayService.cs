using TruCoConsole.Application.Service;
using TruCoNsole.Domain.Entity;

namespace TruCoNsole.Application.Service;

public static class DisplayService
{
    public static void DisplayCards(Board board)
    {
        Console.Clear();

        DisplayPoints(board.Opponent);
        DisplayOpponentCards(board.Opponent);

        DisplayTomboCards(board.Tombo);

        DisplayPlayerCards(board.Player);
        DisplayPoints(board.Player);
    }

    private static void DisplayOpponentCards(Player player)
    {
        for (byte linha = 0; linha <= 6; linha++)
        {
            for (byte index = 0; index < player.Cards.Length; index++)
            {
                if (player.Choice == index || player.Cards[index].Used)
                {
                    string[] carta = player.Cards[index].BuildCard();

                    int indice = linha - (player.Choice != index ? 0 : 2);
                    string valorExibido = (indice >= 0 && indice < carta.Length) ? carta[indice] : "      ";
                    Console.Write("   " + valorExibido);
                }
                else
                {
                    string[] carta = player.Cards[index].BuildBackCard();

                    int indice = linha - (player.Choice != index ? 0 : 2);
                    string valorExibido = (indice >= 0 && indice < carta.Length) ? carta[indice] : "      ";
                    Console.Write("   " + valorExibido);
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    private static void DisplayPoints(Player player)
    {
        Console.WriteLine($"==|Pontos ({player.Points})|===|Tento ({player.Tentos})|==\n");
    }

    private static void DisplayTomboCards(Card cartas)
    {
        for (int linha = 0; linha <= 4; linha++)
            Console.WriteLine("            " + cartas.BuildCard()[linha]);
        Console.WriteLine();
    }

    private static void DisplayPlayerCards(Player player)
    {
        for (byte linha = 0; linha <= 6; linha++)
        {
            for (byte index = 0; index < player.Cards.Length; index++)
            {
                if (player.Choice != index && player.Cards[index].Used)
                {
                    string[] carta = player.Cards[index].BuildBackCard();
                    int indice = linha - (player.Choice == index ? 0 : 2);
                    string valorExibido = (indice >= 0 && indice < carta.Length) ? carta[indice] : "      ";
                    Console.Write("   " + valorExibido);
                }
                else
                {
                    string[] carta = player.Cards[index].BuildCard();

                    if (player.Choice == index || linha > 1)
                    {
                        int indice = linha - (player.Choice == index ? 0 : 2);
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