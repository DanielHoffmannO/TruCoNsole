
using System.ComponentModel.DataAnnotations;
using TruCoNsole.Domain.Entity;
using TruCoNsole.Domain.Enum;

namespace TruCoNsole.Application.Service;

public class Jogo
{
    private static readonly Random random = new();

    public byte BotPontos = 0;
    public byte PeoplePontos = 0;

    public byte BotTento = 0;
    public byte PeopleTento = 0;

    public byte ValorJogo = 1;

    public bool sair;

    public void Game()
    {
        while (BotPontos < 12 || PeoplePontos < 12 || sair)
        {
            Board board = new();

            var quemComeca = random.Next(2) == 1;
            for (int i = 0; BotTento > 2 || PeopleTento > 2 || i > 3; i++)
            {
                ValorJogo = 1;

                Card people;
                Card bot;
                if (quemComeca)
                {
                    bot = board.BotCards[random.Next(1, 4)];//BotAtaca
                    people = board.BotCards[Escolhas()];
                }
                else
                {
                    people = board.BotCards[Escolhas()];
                    bot = board.BotCards[random.Next(1, 4)];//BotContraAtaca
                }

                if (ValidaJogadorGanhou(people, bot))
                {
                    PeopleTento++;
                    quemComeca = true;
                }
                else
                {
                    BotTento++;
                    quemComeca = false;
                }
            }

            if (PeopleTento > BotTento)
                PeoplePontos += ValorJogo;
            else
                BotTento += ValorJogo;
        }
    }

    public bool ValidaJogadorGanhou(Card People, Card Bot)
    {
        if (People.Value > Bot.Value)
            return true;
        else if (Bot.Value > People.Value)
            return false;
        else if (People.Nipe > Bot.Nipe)
            return true;

        return false;
    }

    public byte Escolhas()
    {
        while (true)
        {
            try
            {
                byte escolha = byte.Parse(Console.ReadLine() ?? "0");
                byte[] valoresPermitidos = { 1, 2, 3, 4, 5, 6 };

                if (!valoresPermitidos.Contains(escolha))
                    throw new("Escolha deve ser um valor entre 1 e 5");

                switch ((EOption)escolha)
                {
                    case EOption.Carta1:
                    case EOption.Carta2:
                    case EOption.Carta3:
                        //Montar tela 
                        //Esperar algums segundos 
                        break;
                    case EOption.AceitarTruco:
                    case EOption.Truco:
                        Truco();
                        break;
                    case EOption.Sair:
                        sair = true;
                        break;
                }

                return escolha;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }
    }

    public void Truco()
    {
        if (ValorJogo == 1)
            ValorJogo = 0;

        if (ValorJogo == 12)
            throw new("Truco é até 12 apenas");

        ValorJogo = +3;
    }
}