
using TruCoConsole.Application.Service;
using TruCoNsole.Domain.Enum;

namespace TruCoNsole.Domain.Entity;

public class Board
{
    private static readonly Random Random = new();

    private void Shuffle()
    {
        Deck = new Deck();
        Deck.Cards = Deck.Cards.OrderBy(x => Random.Next()).ToList();

        SetTombo();

        Player ??= new Player(Deck.Cards.Skip(1).Take(3).ToArray());
        Opponent ??= new Player(Deck.Cards.Skip(4).Take(3).ToArray());

        Player.Cards = Deck.Cards.Skip(1).Take(3).ToArray();
        Opponent.Cards = Deck.Cards.Skip(4).Take(3).ToArray();
    }

    private void SetTombo()
    {
        Tombo = Deck.Cards[0];

        var manilha = Tombo.Value == EValueCard.C3 ? EValueCard.C4 : (Tombo.Value + 1);
        Deck.Cards.ForEach(x => x.Manilha = x.Value == manilha);
    }

    public Board() => Shuffle();

    public Deck Deck { get; set; }
    public Card Tombo { get; set; }
    public Player Player { get; set; }
    public Player Opponent { get; set; }

    public bool IsPlayerTurn { get; set; } = Random.Next(2) == 1;
    public byte GameValue { get; set; } = 1;
    public bool Quit { get; set; }

    public void SetTento()
    {
        var playerCard = Player.Cards[Player.Choice];
        var opponentCard = Opponent.Cards[Opponent.Choice];

        IsPlayerTurn = playerCard.Value > opponentCard.Value || playerCard.Manilha || (playerCard.Value == opponentCard.Value && playerCard.Suit > opponentCard.Suit);
        if (IsPlayerTurn)
            Player.Tentos++;
        else
            Opponent.Tentos++;

        Player.Choice = 255;
        Opponent.Choice = 255;
    }

    public void SetPoint()
    {
        if (Player.Tentos > Opponent.Tentos)
            Player.Points++;
        else
            Opponent.Points++;

        GameValue = 1;
        Player.Tentos = 0;
        Opponent.Tentos = 0;

        Shuffle();
    }

    public Card OpponentDecide()
    {
        byte randomIndex;
        do
        {
            randomIndex = (byte)Random.Next(0, Opponent.Cards.Length);
        } while (Opponent.Cards[randomIndex].Used);
        Opponent.UseCard(randomIndex);

        return Opponent.Cards[randomIndex];
    }

    public byte PlayerDecide()
    {
        while (true)
        {
            try
            {
                if (!Player.Cards[0].Used)
                    Console.WriteLine("1 - To select Card 1");
                if (!Player.Cards[1].Used)
                    Console.WriteLine("2 - To select Card 2");
                if (!Player.Cards[2].Used)
                    Console.WriteLine("3 - To select Card 3");

                Console.WriteLine("4 - To accept the truco\n" +
                                  "5 - To quit the game\n");
                Console.WriteLine("==============================");

                Console.Write("<User> ");
                byte choice = byte.Parse(Console.ReadLine() ?? "0");
                byte[] allowedValues = { 1, 2, 3, 4, 5 };

                if (!allowedValues.Contains(choice))
                    throw new ArgumentException("Choice must be a value between 1 and 5\n");

                choice -= 1;
                if (Player.Cards[choice].Used)
                    throw new ArgumentException("Already used this card\n");

                switch ((EOption)choice)
                {
                    case EOption.Card1:
                    case EOption.Card2:
                    case EOption.Card3:
                        Player.UseCard(choice);
                        break;

                    case EOption.Truco:
                        Truco();
                        break;

                    case EOption.Quit:
                        throw new();
                }

                return choice;
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
        if (GameValue == 1)
            GameValue = 0;

        if (GameValue == 12)
            throw new("Truco is up to 12 only");

        GameValue += 3;
    }
}