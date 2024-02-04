
using TruCoNsole.Application.Service;
using TruCoNsole.Domain.Entity;

namespace TruCoNsole;

class Program
{
    private static readonly Random random = new();

    static async Task Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.Black;

        var board = new Board();

        while (board.People.Pontos < 12 || board.Bot.Pontos < 12 || board.Sair)
        {
            while (board.People.Tentos < 2 && board.Bot.Tentos < 2 || board.Sair)
            {
                TelaService.ExibirCartas(board);

                if (board.PeopleVez)
                {
                    board.PeopleDecidir();
                    TelaService.ExibirCartas(board);
                    await Task.Delay(1000);

                    board.BotDecidir();
                    await Task.Delay(1000);
                    TelaService.ExibirCartas(board);
                }
                else
                {
                    board.BotDecidir();
                    await Task.Delay(1000);
                    TelaService.ExibirCartas(board);

                    board.PeopleDecidir();
                    TelaService.ExibirCartas(board);
                    await Task.Delay(1000);
                }

                board.SetTento();
            }
            board.SetPonto();
        }
    }
}