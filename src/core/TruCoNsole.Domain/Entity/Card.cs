
using TruCoNsole.Domain.Enum;

namespace TruCoNsole.Domain.Entity;

public class Card
{
    public Card(byte nipe, byte value)
    {
        Nipe = (ENipe)nipe;
        Value = (EValueCard)value;
    }

    public ENipe Nipe { get; set; }
    public EValueCard Value { get; set; }
    public bool Manilha { get; set; }
    public bool Usada { get; set; }

    public string[] MontaCarta()
    {
        string[] carta = new string[5];

        carta[0] = "+----+";
        carta[1] = $"|{Value.GetDescription()}   |";
        carta[2] = $"| {Nipe.GetDescription()} |";
        carta[3] = $"|   {Value.GetDescription()}|";
        carta[4] = "+----+";

        return carta;
    }

    public string[] MontaCartaBunda()
    {
        string[] carta = new string[5];

        carta[0] = "+----+";
        carta[1] = "|/\\\\/|";
        carta[2] = "|\\//\\|";
        carta[3] = "|/\\/\\|";
        carta[4] = "+----+";

        return carta;
    }
}