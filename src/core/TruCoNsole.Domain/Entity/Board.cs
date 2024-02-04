
using TruCoConsole.Application.Service;
using TruCoNsole.Domain.Enum;

namespace TruCoNsole.Domain.Entity;

public class Board
{
    private static readonly Random random = new();

    private void Shuffle()
    {
        Deck = new Deck();
        Deck.Cards = Deck.Cards.OrderBy(x => random.Next()).ToList();

        SetTombo();

        People ??= new Player(Deck.Cards.Skip(1).Take(3).ToArray());
        Bot ??= new Player(Deck.Cards.Skip(4).Take(3).ToArray());

        People.Cards = Deck.Cards.Skip(1).Take(3).ToArray();
        Bot.Cards = Deck.Cards.Skip(4).Take(3).ToArray();
    }

    private void SetTombo()
    {
        Tombo = Deck.Cards[0];

        var manilha = Tombo.Value == EValueCard.C3 ? EValueCard.C4 : (Tombo.Value + 1);
        Deck.Cards.ForEach(x => x.Manilha = x.Value == manilha);
    }
    public Board()
    {
        Shuffle();
    }

    public Deck Deck { get; set; }
    public Card Tombo { get; set; }
    public Player People { get; set; }
    public Player Bot { get; set; }

    public bool PeopleVez { get; set; } = random.Next(2) == 1;
    public byte ValorJogo { get; set; } = 1;
    public bool Sair { get; set; }

    public void SetTento()
    {
        var people = People.Cards[People.Escolha];
        var bot = Bot.Cards[Bot.Escolha];

        PeopleVez = people.Value > bot.Value || people.Manilha || (people.Value == bot.Value && people.Nipe > bot.Nipe);
        if (PeopleVez)
            People.Tentos++;
        else Bot.Tentos++;

        People.Escolha = 255;
        Bot.Escolha = 255;
    }

    public void SetPonto()
    {
        if (People.Tentos > Bot.Tentos)
            People.Pontos++;
        else Bot.Pontos++;

        ValorJogo = 1;
        People.Tentos = 0;
        Bot.Tentos = 0;

        Shuffle();
    }

    public Card BotDecidir()
    {
        byte randomIndex;
        do
        {
            randomIndex = (byte)random.Next(0, Bot.Cards.Length);
        } while (Bot.Cards[randomIndex].Usada);
        Bot.UsarCarta(randomIndex);

        return Bot.Cards[randomIndex];
    }

    public byte PeopleDecidir()
    {
        while (true)
        {
            try
            {
                if (!People.Cards[0].Usada)
                    Console.WriteLine("1 - Para selecionar a Carta 1");
                if (!People.Cards[1].Usada)
                    Console.WriteLine("2 - Para selecionar a Carta 2");
                if (!People.Cards[2].Usada)
                    Console.WriteLine("3 - Para selecionar a Carta 3");

                Console.WriteLine("4 - Para aceitar o truco\n" +
                                  "5 - Para sair do jogo\n");
                Console.WriteLine("==============================");


                Console.Write("<User> ");
                byte escolha = byte.Parse(Console.ReadLine() ?? "0");
                byte[] valoresPermitidos = { 1, 2, 3, 4, 5 };

                if (!valoresPermitidos.Contains(escolha))
                    throw new ArgumentException("Escolha deve ser um valor entre 1 e 5\n");

                escolha -= 1;
                if (People.Cards[escolha].Usada)
                    throw new ArgumentException("Já usou essa carta\n");

                switch ((EOption)escolha)
                {
                    case EOption.Carta1:
                    case EOption.Carta2:
                    case EOption.Carta3:
                        People.UsarCarta(escolha);
                        break;

                    case EOption.Truco:
                        Truco();
                        break;

                    case EOption.Sair:
                        throw new();
                }


                return escolha;
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(ex.Message);
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Black;
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