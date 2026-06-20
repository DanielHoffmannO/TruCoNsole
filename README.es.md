🌐 [Português](README.md) | [English](README.en.md)

# 🃏 TruCoNsole

Juego de Truco Paulista en la terminal — contra un bot con IA simple.

## Tech Stack

- .NET 9 / Console App
- Arquitectura DDD (Domain, Application, Console)
- xUnit

## Cómo Jugar

```bash
dotnet run --project src/TruCoNsole.Console
```

## Reglas

- Truco Paulista simplificado (1v1 contra bot)
- Baraja de 40 cartas (sin 8, 9, 10)
- El primero en llegar a 12 puntos gana
- Se puede pedir Truco (3, 6, 9, 12 puntos)
- El bot decide si acepta o se retira

## Tests

```bash
dotnet test
```

## Arquitectura

```
src/
├── TruCoNsole.Domain        ← Entidades, Enums, Interfaces (DDD)
├── TruCoNsole.Application   ← Services (BaralhoService, JogoService)
└── TruCoNsole.Console       ← UI en la terminal
tests/
└── TruCoNsole.Tests         ← xUnit
```