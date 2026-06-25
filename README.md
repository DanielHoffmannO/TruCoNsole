[>] [English](README.en.md) | [Espanol](README.es.md)

# {K} TruCoNsole

[![.NET CI](https://github.com/DanielHoffmannO/TruCoNsole/actions/workflows/dotnet.yml/badge.svg)](https://github.com/DanielHoffmannO/TruCoNsole/actions)
![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet)
![xUnit](https://img.shields.io/badge/xUnit-tested-5FA04E)
![License](https://img.shields.io/badge/license-MIT-green)

> Truco Paulista no terminal -- desafie um bot com IA.

## [~] Gameplay

```
+---------------------+
|   BOT: [?] [?] [?]  |
|                     |
|   Mesa:  4<>  Q<>   |
|                     |
|  Voce:  7<>  J<>  A |
+---------------------+
  Placar: Voce 6 x 3 Bot
  [1] Jogar  [2] Truco!  [3] Correr
```

## {=} Tech Stack

- .NET 9 / Console App
- Arquitetura DDD (Domain, Application, Console)
- xUnit (testes unitarios)

## [!] Como Jogar

```bash
dotnet run --project src/TruCoNsole.Console
```

## [*] Regras

- Truco Paulista 1v1 contra bot
- Baralho de 40 cartas (sem 8, 9, 10)
- Primeiro a 12 pontos vence
- Pode pedir Truco (vale 3, 6, 9, 12)
- Bot decide se aceita ou corre
- Manilhas: a carta seguinte a vira

## [?] Testes

```bash
dotnet test
```

Cobertura: Partida, JogoService, BaralhoService.

## {/} Arquitetura

```
src/
+-- TruCoNsole.Domain        <- Entidades, Enums, Interfaces (DDD)
+-- TruCoNsole.Application   <- Services (Baralho, Jogo)
+-- TruCoNsole.Console       <- UI terminal + MesaRenderer
tests/
+-- TruCoNsole.Tests         <- xUnit
```

## [$] Licenca

Este projeto esta sob a licenca [MIT](LICENSE).
