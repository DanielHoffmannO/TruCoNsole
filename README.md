🌐 [English](README.en.md) | [Español](README.es.md)

# 🃏 TruCoNsole

[![.NET CI](https://github.com/DanielHoffmannO/TruCoNsole/actions/workflows/dotnet.yml/badge.svg)](https://github.com/DanielHoffmannO/TruCoNsole/actions/workflows/dotnet.yml)
![.NET 9](https://img.shields.io/badge/.NET-9.0-purple)
![xUnit](https://img.shields.io/badge/tests-xUnit-blue)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

> Truco Paulista no terminal — desafie um bot com IA.

## 🎮 Gameplay

```
┌───────────────────────────────┐
│       BOT: [?]  [?]  [?]     │
│                               │
│      Mesa:  4♦   Q♠          │
│                               │
│      Você:  7♥   A♣   3♦     │
├───────────────────────────────┤
│  Placar: Você 6 x 3 Bot      │
│  Truco! Vale 3               │
└───────────────────────────────┘
```

Jogue cartas, peça truco e blefe até chegar a 12 pontos!

## 🛠️ Tech Stack

| Tecnologia | Uso |
|---|---|
| .NET 9 | Runtime & SDK |
| C# | Linguagem |
| Console App | Interface no terminal |
| xUnit | Testes automatizados |
| GitHub Actions | CI/CD |

## 🚀 Como Jogar

```bash
# Clone o repositório
git clone https://github.com/DanielHoffmannO/TruCoNsole.git
cd TruCoNsole

# Execute o jogo
dotnet run --project src/TruCoNsole.Console
```

### Controles

- Escolha a carta pelo número exibido
- `T` — Pedir Truco
- `A` — Aceitar truco
- `R` — Recusar truco (correr)

## 📜 Regras

- **Baralho:** 40 cartas (sem 8, 9, 10 e coringas)
- **Objetivo:** Primeiro a **12 pontos** vence a partida
- **Rodada:** Melhor de 3 — cada jogador joga 1 carta por vez
- **Truco:** Pode pedir para aumentar a aposta:
  - Normal → **Truco** (3 pontos)
  - Truco → **Seis** (6 pontos)
  - Seis → **Nove** (9 pontos)
  - Nove → **Doze** (12 pontos)
- **Manilhas:** Definidas pela carta virada (vira), seguindo a ordem do Truco Paulista

## 🧪 Testes

```bash
dotnet test
```

Cobertura de testes com xUnit:

- `PartidaTests` — Lógica de partida e pontuação
- `JogoServiceTests` — Fluxo de jogo e regras
- `BaralhoServiceTests` — Embaralhamento e distribuição de cartas

## 🏗️ Arquitetura

Projeto organizado com **DDD (Domain-Driven Design)**:

```
src/
├── TruCoNsole.Domain/          # Núcleo do domínio
│   ├── Entities/               # Carta, Jogador, Partida, Rodada
│   ├── Enums/                  # Naipe, Valor, StatusPartida
│   └── Interfaces/             # Contratos de serviços
│
├── TruCoNsole.Application/     # Camada de aplicação
│   └── Services/               # JogoService, BaralhoService, BotService
│
└── TruCoNsole.Console/         # Interface do terminal
    └── MesaRenderer.cs         # Renderização ASCII da mesa

tests/
└── TruCoNsole.Tests/           # Testes unitários (xUnit)
```

## 📄 Licença

Este projeto está sob a licença [MIT](LICENSE).

## 👤 Autor

**Daniel Hoffmann** — [@DanielHoffmannO](https://github.com/DanielHoffmannO)
