🌐 [Português](README.md) | [Español](README.es.md)

# 🃏 TruCoNsole

Truco Paulista card game in the terminal — play against a bot with simple AI.

## Tech Stack

- .NET 9 / Console App
- DDD Architecture (Domain, Application, Console)
- xUnit

## How to Play

```bash
dotnet run --project src/TruCoNsole.Console
```

## Rules

- Simplified Truco Paulista (1v1 against bot)
- 40-card deck (no 8, 9, 10)
- First to 12 points wins
- Can call Truco (3, 6, 9, 12 points)
- Bot decides whether to accept or fold

## Tests

```bash
dotnet test
```

## Architecture

```
src/
├── TruCoNsole.Domain        ← Entities, Enums, Interfaces (DDD)
├── TruCoNsole.Application   ← Services (BaralhoService, JogoService)
└── TruCoNsole.Console       ← Terminal UI
tests/
└── TruCoNsole.Tests         ← xUnit
```