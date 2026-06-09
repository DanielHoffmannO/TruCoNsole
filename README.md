# 🃏 TruCoNsole

Jogo de Truco Paulista no terminal — contra um bot com IA simples.

## Tech Stack

- .NET 9 / Console App
- Arquitetura DDD (Domain, Application, Console)
- xUnit

## Como Jogar

```bash
dotnet run --project src/TruCoNsole.Console
```

## Regras

- Truco Paulista simplificado (1v1 contra bot)
- Baralho de 40 cartas (sem 8, 9, 10)
- Primeiro a 12 pontos vence
- Pode pedir Truco (3, 6, 9, 12)
- Bot decide se aceita ou corre

## Testes

```bash
dotnet test
```

## Arquitetura

```
src/
├── TruCoNsole.Domain        ← Entidades, Enums, Interfaces (DDD)
├── TruCoNsole.Application   ← Services (BaralhoService, JogoService)
└── TruCoNsole.Console       ← UI no terminal
tests/
└── TruCoNsole.Tests         ← xUnit
```

## Autor

Daniel Hoffmann
