
namespace TruCoNsole.Application.Service;

public class PeopleService
{
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
