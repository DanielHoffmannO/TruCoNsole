using TruCoNsole.Application.Services;
using TruCoNsole.Console;
using TruCoNsole.Domain.Entities;
using TruCoNsole.Domain.Enums;
using TruCoNsole.Domain.Interfaces;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// Tamanho fixo do terminal
try
{
    Console.SetWindowSize(62, 35);
    Console.SetBufferSize(62, 35);
}
catch { /* ignora se o terminal não suportar resize */ }

IBaralhoService baralho = new BaralhoService();
IJogoService jogo = new JogoService(baralho);

// Tela de boas-vindas
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

while (partida.Vencedor() is null)
{
    jogo.DistribuirCartas(partida);
    string? mensagemRodada = null;
    bool jogadorPuxa = true; // primeira rodada: jogador começa (depois quem ganha puxa)

    while (partida.Rodadas.Count < 3 && partida.ResolverMao() is null)
    {
        var rodada = jogo.IniciarRodada(partida);

        MesaRenderer.Desenhar(partida, mensagemRodada);
        mensagemRodada = null;

        Carta cartaBot;
        Carta cartaJogador;

        if (!jogadorPuxa)
        {
            // Bot joga primeiro
            MesaRenderer.Desenhar(partida, "🤔 Bot está pensando...");
            Thread.Sleep(1200);

            cartaBot = jogo.EscolherCartaBot(partida.Jogador2);
            rodada.RegistrarJogada(partida.Jogador2, cartaBot, false);

            MesaRenderer.Desenhar(partida, $"Bot jogou: {cartaBot}");
            Thread.Sleep(1000);

            // Jogador responde
            MesaRenderer.Desenhar(partida, $"Bot jogou: {cartaBot}");
            string prompt = partida.ValorMao < 12
                ? $"Rodada {partida.Rodadas.Count} │ Carta (1-{partida.Jogador1.Mao.Count}) ou [T]ruco: "
                : $"Rodada {partida.Rodadas.Count} │ Carta (1-{partida.Jogador1.Mao.Count}): ";
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(prompt);
            Console.ResetColor();
            var input = Console.ReadLine()?.Trim().ToUpper();

            if (input == "T" && partida.ValorMao < 12)
            {
                MesaRenderer.Desenhar(partida, "🃏 Você pediu TRUCO! Bot decidindo...");
                Thread.Sleep(1500);
                bool aceito = jogo.PedirTruco(partida);
                if (aceito)
                {
                    mensagemRodada = $"🔥 Bot ACEITA! Vale {partida.ValorMao} agora!";
                    MesaRenderer.Desenhar(partida, mensagemRodada);
                    Thread.Sleep(1200);
                }
                else
                {
                    partida.Jogador1.Pontos += partida.ValorMao;
                    mensagemRodada = "🏳️ Bot CORREU! Você ganha a mão.";
                    MesaRenderer.Desenhar(partida, mensagemRodada);
                    Thread.Sleep(2000);
                    break;
                }
                MesaRenderer.Desenhar(partida, mensagemRodada);
                Console.Write($"Rodada {partida.Rodadas.Count} │ Carta (1-{partida.Jogador1.Mao.Count}): ");
                input = Console.ReadLine()?.Trim();
            }

            if (!int.TryParse(input, out int esc) || esc < 1 || esc > partida.Jogador1.Mao.Count)
                esc = 1;

            cartaJogador = partida.Jogador1.JogarCarta(esc - 1);
            rodada.RegistrarJogada(partida.Jogador1, cartaJogador, true);
        }
        else
        {
            // Jogador joga primeiro
            string prompt = partida.ValorMao < 12
                ? $"Rodada {partida.Rodadas.Count} │ Carta (1-{partida.Jogador1.Mao.Count}) ou [T]ruco: "
                : $"Rodada {partida.Rodadas.Count} │ Carta (1-{partida.Jogador1.Mao.Count}): ";
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(prompt);
            Console.ResetColor();
            var input = Console.ReadLine()?.Trim().ToUpper();

            if (input == "T" && partida.ValorMao < 12)
            {
                MesaRenderer.Desenhar(partida, "🃏 Você pediu TRUCO! Bot decidindo...");
                Thread.Sleep(1500);
                bool aceito = jogo.PedirTruco(partida);
                if (aceito)
                {
                    mensagemRodada = $"🔥 Bot ACEITA! Vale {partida.ValorMao} agora!";
                    MesaRenderer.Desenhar(partida, mensagemRodada);
                    Thread.Sleep(1200);
                }
                else
                {
                    partida.Jogador1.Pontos += partida.ValorMao;
                    mensagemRodada = "🏳️ Bot CORREU! Você ganha a mão.";
                    MesaRenderer.Desenhar(partida, mensagemRodada);
                    Thread.Sleep(2000);
                    break;
                }
                MesaRenderer.Desenhar(partida, mensagemRodada);
                Console.Write($"Rodada {partida.Rodadas.Count} │ Carta (1-{partida.Jogador1.Mao.Count}): ");
                input = Console.ReadLine()?.Trim();
            }

            if (!int.TryParse(input, out int escolha) || escolha < 1 || escolha > partida.Jogador1.Mao.Count)
                escolha = 1;

            cartaJogador = partida.Jogador1.JogarCarta(escolha - 1);
            rodada.RegistrarJogada(partida.Jogador1, cartaJogador, true);

            MesaRenderer.Desenhar(partida, $"Você jogou: {cartaJogador}");
            Thread.Sleep(1000);

            // Bot responde
            MesaRenderer.Desenhar(partida, "🤔 Bot está pensando...");
            Thread.Sleep(1200);

            cartaBot = jogo.EscolherCartaBot(partida.Jogador2);
            rodada.RegistrarJogada(partida.Jogador2, cartaBot, false);
        }

        var vencedorRodada = jogo.ResolverRodada(rodada, partida);

        if (vencedorRodada is not null)
        {
            jogadorPuxa = vencedorRodada == partida.Jogador1;
            mensagemRodada = jogadorPuxa
                ? $"✓ Bot jogou {rodada.CartaJogador2} — Você venceu!"
                : $"✗ Bot jogou {rodada.CartaJogador2} — Bot venceu!";
        }
        else
        {
            // empate: quem puxou mantém
            mensagemRodada = $"⚡ Empate na rodada!";
        }

        MesaRenderer.Desenhar(partida, mensagemRodada);
        Thread.Sleep(1500);
    }

    // Fim da mão
    var vencedorMao = partida.ResolverMao();
    if (vencedorMao is not null)
    {
        partida.AplicarPontos();
        var msg = vencedorMao == partida.Jogador1
            ? $"★ Você venceu a mão! (+{partida.ValorMao} pts)"
            : $"★ Bot venceu a mão! (+{partida.ValorMao} pts)";
        MesaRenderer.Desenhar(partida, msg);
    }
    else
    {
        MesaRenderer.Desenhar(partida, mensagemRodada);
    }

    partida.ResetarMao();
    Thread.Sleep(2500);
}

// Tela de vitória
var campeao = partida.Vencedor()!;
Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine();
Console.WriteLine("  ╔══════════════════════════════════╗");
Console.WriteLine($"  ║  🏆 {campeao.Nome.PadRight(24)} VENCEU! ║");
Console.WriteLine($"  ║  Placar: {partida.Jogador1.Pontos,2} x {partida.Jogador2.Pontos,-2}                  ║");
Console.WriteLine("  ╚══════════════════════════════════╝");
Console.ResetColor();
