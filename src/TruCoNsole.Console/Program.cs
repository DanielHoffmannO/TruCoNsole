using TruCoNsole.Application.Services;
using TruCoNsole.Domain.Entities;
using TruCoNsole.Domain.Enums;
using TruCoNsole.Domain.Interfaces;

IBaralhoService baralho = new BaralhoService();
IJogoService jogo = new JogoService(baralho);

Console.Clear();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("╔══════════════════════════════╗");
Console.WriteLine("║       🃏 TRU-CO-NSOLE 🃏      ║");
Console.WriteLine("║     Truco Paulista v1.0      ║");
Console.WriteLine("╚══════════════════════════════╝");
Console.ResetColor();
Console.WriteLine();

Console.Write("Seu nome: ");
var nome = Console.ReadLine()?.Trim();
if (string.IsNullOrWhiteSpace(nome)) nome = "Jogador";

var partida = jogo.IniciarPartida(nome);
Console.WriteLine($"\n⚔️  {partida.Jogador1.Nome} vs {partida.Jogador2.Nome}");
Console.WriteLine($"Primeiro a {Partida.PontosParaVencer} pontos vence!\n");

while (partida.Vencedor() is null)
{
    jogo.DistribuirCartas(partida);
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"━━━ Nova Mão (vale {partida.ValorMao}) ━━━");
    Console.ResetColor();
    Console.WriteLine($"Placar: {partida.Jogador1.Nome} {partida.Jogador1.Pontos} x {partida.Jogador2.Pontos} {partida.Jogador2.Nome}");

    while (partida.Rodadas.Count < 3 && partida.ResolverMao() is null)
    {
        var rodada = jogo.IniciarRodada(partida);
        Console.WriteLine($"\n--- Rodada {partida.Rodadas.Count} ---");

        // Mostrar mão do jogador
        Console.WriteLine("Suas cartas:");
        for (int i = 0; i < partida.Jogador1.Mao.Count; i++)
            Console.WriteLine($"  [{i + 1}] {partida.Jogador1.Mao[i]}");

        // Opção de pedir truco
        if (partida.ValorMao < 12)
        {
            Console.Write("Jogar carta (1-3) ou [T]ruco: ");
        }
        else
        {
            Console.Write("Jogar carta (1-3): ");
        }

        var input = Console.ReadLine()?.Trim().ToUpper();

        if (input == "T" && partida.ValorMao < 12)
        {
            bool aceito = jogo.PedirTruco(partida);
            if (aceito)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"🔥 Bot ACEITA! Mão agora vale {partida.ValorMao}!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("🏳️  Bot CORREU! Você ganha a mão.");
                Console.ResetColor();
                partida.Jogador1.Pontos += partida.ValorMao;
                break;
            }
            Console.Write("Agora jogue sua carta (1-3): ");
            input = Console.ReadLine()?.Trim();
        }

        if (!int.TryParse(input, out int escolha) || escolha < 1 || escolha > partida.Jogador1.Mao.Count)
        {
            Console.WriteLine("Jogada inválida, jogando carta 1.");
            escolha = 1;
        }

        var cartaJogador = partida.Jogador1.JogarCarta(escolha - 1);
        rodada.RegistrarJogada(partida.Jogador1, cartaJogador, true);
        Console.WriteLine($"Você jogou: {cartaJogador}");

        var cartaBot = jogo.EscolherCartaBot(partida.Jogador2);
        rodada.RegistrarJogada(partida.Jogador2, cartaBot, false);
        Console.WriteLine($"Bot jogou: {cartaBot}");

        var vencedorRodada = jogo.ResolverRodada(rodada, partida);
        if (vencedorRodada is not null)
        {
            Console.ForegroundColor = vencedorRodada == partida.Jogador1 ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine($"✓ {vencedorRodada.Nome} venceu a rodada!");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("⚡ Empate na rodada!");
        }
    }

    var vencedorMao = partida.ResolverMao();
    if (vencedorMao is not null)
    {
        partida.AplicarPontos();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"\n★ {vencedorMao.Nome} venceu a mão! (+{partida.ValorMao} pts)");
        Console.ResetColor();
    }

    partida.ResetarMao();
    Console.WriteLine();
}

var campeao = partida.Vencedor()!;
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("╔══════════════════════════════╗");
Console.WriteLine($"║  🏆 {campeao.Nome.PadRight(20)} VENCEU!  ║");
Console.WriteLine($"║  Placar: {partida.Jogador1.Pontos} x {partida.Jogador2.Pontos}              ║");
Console.WriteLine("╚══════════════════════════════╝");
Console.ResetColor();
