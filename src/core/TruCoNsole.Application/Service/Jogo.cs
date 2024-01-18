
using Microsoft.VisualBasic.FileIO;
using TruCoNsole.Domain.Entity;
using TruCoNsole.Domain.Enum;

namespace TruCoNsole.Application.Service;

public class Jogo
{
    public byte BotPontos = 0;
    public byte PEssoaPontos = 0;


    public void Jogo()
    {
        while (BotPontos < 12 || PEssoaPontos < 12)
        {
            //Montar todas as cartas e a mesa
            Board board = new();

            //Montar tela 

            switch ((EOption)Escolhas())
            {
                case EOption.Carta1:
                    //Montar tela 
                    //Esperar algums segundos 
                    break;
                case EOption.Carta2:
                    //Montar tela 
                    //Esperar algums segundos 
                    break;
                case EOption.Carta3:
                    //Montar tela 
                    //Esperar algums segundos 
                    break;
                case EOption.Truco:
                    //Montar tela 
                    break;
                case EOption.Sair:
                    //Montar tela 
                    break;
            }
        }
    }

    public byte Escolhas()
    {
        while (true)
        {
            try
            {
                byte escolha = byte.Parse(Console.ReadLine() ?? "0");
                byte[] valoresPermitidos = { 1, 2, 3, 4, 5 };

                if (!valoresPermitidos.Contains(escolha))
                    throw new("Escolha deve ser um valor entre 1 e 5");

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
}
