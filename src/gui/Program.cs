using TruCoNsole.Application.Service;
using TruCoNsole.Domain.Entity;
using System;
using System.Threading.Tasks;

namespace TruCoNsole
{
    class Program
    {
        private static readonly Random random = new();

        static async Task Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;

            var board = new Board();
            await PlayGame(board);
        }

        static async Task PlayGame(Board board)
        {
            while (board.Player.Points < 12 || board.Opponent.Points < 12 || board.Quit)
            {
                while (board.Player.Tentos < 2 && board.Opponent.Tentos < 2 || board.Quit)
                {
                    DisplayService.DisplayCards(board);

                    if (board.IsPlayerTurn)
                    {
                        board.PlayerDecide();
                        DisplayService.DisplayCards(board);

                        board.OpponentDecide();
                        await Task.Delay(1000);
                        DisplayService.DisplayCards(board);
                        await Task.Delay(1000);
                    }
                    else
                    {
                        board.OpponentDecide();
                        await Task.Delay(1000);
                        DisplayService.DisplayCards(board);
                        await Task.Delay(1000);

                        board.PlayerDecide();
                        DisplayService.DisplayCards(board);
                        await Task.Delay(1000);
                    }

                    board.SetTento();
                }
                board.SetPoint();
            }
        }
    }
}
