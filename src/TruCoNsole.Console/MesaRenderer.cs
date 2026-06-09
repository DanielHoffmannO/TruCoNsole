using TruCoNsole.Domain.Entities;
using TruCoNsole.Domain.Enums;

namespace TruCoNsole.Console;

public static class MesaRenderer
{
    private const int Largura = 60;

    public static void Desenhar(Partida partida, string? mensagem = null)
    {
        System.Console.Clear();

        // Header
        EscreverCentralizado("🃏 TRU-CO-NSOLE 🃏", ConsoleColor.Green);
        System.Console.WriteLine();

        // Cartas do Bot (viradas, 5 linhas)
        EscreverCentralizado($"🤖 {partida.Jogador2.Nome}", ConsoleColor.DarkGray);
        DesenharCartasViradas(partida.Jogador2.Mao.Count);
        System.Console.WriteLine();

        // Mesa central com placar e tombo
        DesenharMesa(partida);
        System.Console.WriteLine();

        // Cartas do jogador
        DesenharCartasJogador(partida.Jogador1.Mao, partida.Vira);
        EscreverCentralizado($"👤 {partida.Jogador1.Nome}", ConsoleColor.Cyan);

        // Mensagem
        if (!string.IsNullOrEmpty(mensagem))
        {
            System.Console.WriteLine();
            EscreverCentralizado(mensagem, ConsoleColor.Yellow);
        }

        System.Console.WriteLine();
    }

    private static void DesenharCartasViradas(int quantidade)
    {
        if (quantidade == 0) return;
        var t = "┌─────┐";
        var m = "│▒▒▒▒▒│";
        var b = "└─────┘";
        var bloco = string.Join(" ", Enumerable.Repeat(t, quantidade));
        var pad = Pad(bloco.Length);

        System.Console.ForegroundColor = ConsoleColor.DarkYellow;
        System.Console.WriteLine($"{pad}{string.Join(" ", Enumerable.Repeat(t, quantidade))}");
        System.Console.WriteLine($"{pad}{string.Join(" ", Enumerable.Repeat(m, quantidade))}");
        System.Console.WriteLine($"{pad}{string.Join(" ", Enumerable.Repeat(m, quantidade))}");
        System.Console.WriteLine($"{pad}{string.Join(" ", Enumerable.Repeat(m, quantidade))}");
        System.Console.WriteLine($"{pad}{string.Join(" ", Enumerable.Repeat(b, quantidade))}");
        System.Console.ResetColor();
    }

    private static void DesenharMesa(Partida partida)
    {
        var mesaLarg = 40;
        var pad = Pad(mesaLarg);

        // Construir linhas da mesa
        System.Console.ForegroundColor = ConsoleColor.DarkCyan;
        System.Console.WriteLine($"{pad}┌{'─'.Repetir(mesaLarg - 2)}┐");
        System.Console.Write($"{pad}│");
        System.Console.ResetColor();

        // Linha do tombo
        var tomboTxt = partida.Vira is not null ? $"Vira: {FormatarCarta(partida.Vira)}  │  Manilha: {NomeManilha(partida.Vira)}" : "Sem vira";
        System.Console.ForegroundColor = ConsoleColor.White;
        System.Console.Write(tomboTxt.Centralizar(mesaLarg - 2));
        System.Console.ForegroundColor = ConsoleColor.DarkCyan;
        System.Console.WriteLine("│");

        // Separador
        System.Console.WriteLine($"{pad}│{'─'.Repetir(mesaLarg - 2)}│");

        // Rodadas jogadas
        if (partida.Rodadas.Count == 0)
        {
            System.Console.Write($"{pad}│");
            System.Console.ResetColor();
            System.Console.Write("Aguardando jogada...".Centralizar(mesaLarg - 2));
            System.Console.ForegroundColor = ConsoleColor.DarkCyan;
            System.Console.WriteLine("│");

            System.Console.Write($"{pad}│");
            System.Console.Write(" ".Repetir(mesaLarg - 2));
            System.Console.WriteLine("│");

            System.Console.Write($"{pad}│");
            System.Console.Write(" ".Repetir(mesaLarg - 2));
            System.Console.WriteLine("│");
        }
        else
        {
            foreach (var rodada in partida.Rodadas)
            {
                var c1 = rodada.CartaJogador1 is not null ? FormatarCarta(rodada.CartaJogador1) : "···";
                var c2 = rodada.CartaJogador2 is not null ? FormatarCarta(rodada.CartaJogador2) : "···";
                var resultado = rodada.Vencedor is not null ? $"→ {rodada.Vencedor.Nome}" : "→ Empate";
                var linha = $"{c1}  vs  {c2}  {resultado}";

                System.Console.Write($"{pad}│");
                System.Console.ResetColor();
                System.Console.Write(linha.Centralizar(mesaLarg - 2));
                System.Console.ForegroundColor = ConsoleColor.DarkCyan;
                System.Console.WriteLine("│");
            }
            for (int i = partida.Rodadas.Count; i < 3; i++)
            {
                System.Console.Write($"{pad}│");
                System.Console.Write(" ".Repetir(mesaLarg - 2));
                System.Console.WriteLine("│");
            }
        }

        System.Console.WriteLine($"{pad}└{'─'.Repetir(mesaLarg - 2)}┘");
        System.Console.ResetColor();

        // Placar abaixo da mesa
        var placar = $"{partida.Jogador1.Nome}: {partida.Jogador1.Pontos}  │  {partida.Jogador2.Nome}: {partida.Jogador2.Pontos}  │  Vale: {partida.ValorMao}";
        EscreverCentralizado(placar, ConsoleColor.White);
    }

    private static void DesenharCartasJogador(List<Carta> cartas, Carta? vira)
    {
        if (cartas.Count == 0) return;

        var labels = cartas.Select(c => GetLabel(c.Valor)).ToArray();
        var simbolos = cartas.Select(c => GetSimbolo(c.Naipe)).ToArray();
        var cores = cartas.Select(c => GetCor(c.Naipe)).ToArray();
        var manilhas = cartas.Select(c => c.EhManilha(vira)).ToArray();

        var blocoLarg = cartas.Count * 8 - 1;
        var pad = Pad(blocoLarg);

        // Topo
        System.Console.Write(pad);
        for (int i = 0; i < cartas.Count; i++)
            System.Console.Write(i < cartas.Count - 1 ? "┌─────┐ " : "┌─────┐");
        System.Console.WriteLine();

        // Valor superior
        System.Console.Write(pad);
        for (int i = 0; i < cartas.Count; i++)
        {
            System.Console.Write("│ ");
            System.Console.ForegroundColor = manilhas[i] ? ConsoleColor.Yellow : cores[i];
            System.Console.Write($"{labels[i],-2}");
            System.Console.ResetColor();
            System.Console.Write(i < cartas.Count - 1 ? "  │ " : "  │");
        }
        System.Console.WriteLine();

        // Naipe central
        System.Console.Write(pad);
        for (int i = 0; i < cartas.Count; i++)
        {
            System.Console.Write("│  ");
            System.Console.ForegroundColor = manilhas[i] ? ConsoleColor.Yellow : cores[i];
            System.Console.Write(simbolos[i]);
            System.Console.ResetColor();
            System.Console.Write(i < cartas.Count - 1 ? "  │ " : "  │");
        }
        System.Console.WriteLine();

        // Valor inferior
        System.Console.Write(pad);
        for (int i = 0; i < cartas.Count; i++)
        {
            System.Console.Write("│  ");
            System.Console.ForegroundColor = manilhas[i] ? ConsoleColor.Yellow : cores[i];
            System.Console.Write($"{labels[i],2}");
            System.Console.ResetColor();
            System.Console.Write(i < cartas.Count - 1 ? " │ " : " │");
        }
        System.Console.WriteLine();

        // Base
        System.Console.Write(pad);
        for (int i = 0; i < cartas.Count; i++)
            System.Console.Write(i < cartas.Count - 1 ? "└─────┘ " : "└─────┘");
        System.Console.WriteLine();

        // Índices
        System.Console.Write(pad);
        for (int i = 0; i < cartas.Count; i++)
        {
            var tag = manilhas[i] ? $"[{i + 1}]★" : $" [{i + 1}] ";
            System.Console.Write(i < cartas.Count - 1 ? $"  {tag}  " : $"  {tag}");
        }
        System.Console.WriteLine();
    }

    private static string FormatarCarta(Carta c) => $"{GetLabel(c.Valor)}{GetSimbolo(c.Naipe)}";

    private static string NomeManilha(Carta vira)
    {
        var proximo = vira.Valor switch
        {
            Valor.Quatro => "5",
            Valor.Cinco => "6",
            Valor.Seis => "7",
            Valor.Sete => "Q",
            Valor.Dama => "J",
            Valor.Valete => "K",
            Valor.Rei => "A",
            Valor.As => "2",
            Valor.Dois => "3",
            Valor.Tres => "4",
            _ => "?"
        };
        return proximo;
    }

    private static string GetSimbolo(Naipe naipe) => naipe switch
    {
        Naipe.Ouros => "♦",
        Naipe.Espadas => "♠",
        Naipe.Copas => "♥",
        Naipe.Paus => "♣",
        _ => "?"
    };

    private static ConsoleColor GetCor(Naipe naipe) => naipe switch
    {
        Naipe.Ouros or Naipe.Copas => ConsoleColor.Red,
        _ => ConsoleColor.White
    };

    private static string GetLabel(Valor valor) => valor switch
    {
        Valor.Quatro => "4",
        Valor.Cinco => "5",
        Valor.Seis => "6",
        Valor.Sete => "7",
        Valor.Dama => "Q",
        Valor.Valete => "J",
        Valor.Rei => "K",
        Valor.As => "A",
        Valor.Dois => "2",
        Valor.Tres => "3",
        _ => "?"
    };

    private static void EscreverCentralizado(string texto, ConsoleColor cor)
    {
        var p = (Largura - texto.Length) / 2;
        System.Console.ForegroundColor = cor;
        System.Console.WriteLine($"{new string(' ', Math.Max(p, 0))}{texto}");
        System.Console.ResetColor();
    }

    private static string Pad(int blocoLarg) => new(' ', Math.Max((Largura - blocoLarg) / 2, 0));
}

public static class StringExtensions
{
    public static string Repetir(this char c, int count) => new(c, Math.Max(count, 0));
    public static string Repetir(this string s, int count) => string.Concat(Enumerable.Repeat(s, Math.Max(count, 0)));
    public static string Centralizar(this string s, int largura)
    {
        if (s.Length >= largura) return s[..largura];
        var pad = (largura - s.Length) / 2;
        return s.PadLeft(pad + s.Length).PadRight(largura);
    }
}
