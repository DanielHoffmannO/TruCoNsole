ðŸŒ [English](README.en.md) | [EspaÃ±ol](README.es.md)

# ðŸƒ TruCoNsole

[![.NET CI](https://github.com/DanielHoffmannO/TruCoNsole/actions/workflows/dotnet.yml/badge.svg)](https://github.com/DanielHoffmannO/TruCoNsole/actions/workflows/dotnet.yml)
![.NET 9](https://img.shields.io/badge/.NET-9.0-purple)
![xUnit](https://img.shields.io/badge/tests-xUnit-blue)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

> Truco Paulista no terminal â€” desafie um bot com IA.

## ðŸŽ® Gameplay

```
â”Œâ”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”
â”‚       BOT: [?]  [?]  [?]     â”‚
â”‚                               â”‚
â”‚      Mesa:  4â™¦   Qâ™           â”‚
â”‚                               â”‚
â”‚      VocÃª:  7â™¥   Aâ™£   3â™¦     â”‚
â”œâ”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”¤
â”‚  Placar: VocÃª 6 x 3 Bot      â”‚
â”‚  Truco! Vale 3               â”‚
â””â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”˜
```

Jogue cartas, peÃ§a truco e blefe atÃ© chegar a 12 pontos!

## ðŸ› ï¸ Tech Stack

| Tecnologia | Uso |
|---|---|
| .NET 9 | Runtime & SDK |
| C# | Linguagem |
| Console App | Interface no terminal |
| xUnit | Testes automatizados |
| GitHub Actions | CI/CD |

## ðŸš€ Como Jogar

```bash
# Clone o repositÃ³rio
git clone https://github.com/DanielHoffmannO/TruCoNsole.git
cd TruCoNsole

# Execute o jogo
dotnet run --project src/TruCoNsole.Console
```

### Controles

- Escolha a carta pelo nÃºmero exibido
- `T` â€” Pedir Truco
- `A` â€” Aceitar truco
- `R` â€” Recusar truco (correr)

## ðŸ“œ Regras

- **Baralho:** 40 cartas (sem 8, 9, 10 e coringas)
- **Objetivo:** Primeiro a **12 pontos** vence a partida
- **Rodada:** Melhor de 3 â€” cada jogador joga 1 carta por vez
- **Truco:** Pode pedir para aumentar a aposta:
  - Normal â†’ **Truco** (3 pontos)
  - Truco â†’ **Seis** (6 pontos)
  - Seis â†’ **Nove** (9 pontos)
  - Nove â†’ **Doze** (12 pontos)
- **Manilhas:** Definidas pela carta virada (vira), seguindo a ordem do Truco Paulista

## ðŸ§ª Testes

```bash
dotnet test
```

Cobertura de testes com xUnit:

- `PartidaTests` â€” LÃ³gica de partida e pontuaÃ§Ã£o
- `JogoServiceTests` â€” Fluxo de jogo e regras
- `BaralhoServiceTests` â€” Embaralhamento e distribuiÃ§Ã£o de cartas

## ðŸ—ï¸ Arquitetura

Projeto organizado com **DDD (Domain-Driven Design)**:

```
src/
â”œâ”€â”€ TruCoNsole.Domain/          # NÃºcleo do domÃ­nio
â”‚   â”œâ”€â”€ Entities/               # Carta, Jogador, Partida, Rodada
â”‚   â”œâ”€â”€ Enums/                  # Naipe, Valor, StatusPartida
â”‚   â””â”€â”€ Interfaces/             # Contratos de serviÃ§os
â”‚
â”œâ”€â”€ TruCoNsole.Application/     # Camada de aplicaÃ§Ã£o
â”‚   â””â”€â”€ Services/               # JogoService, BaralhoService, BotService
â”‚
â””â”€â”€ TruCoNsole.Console/         # Interface do terminal
    â””â”€â”€ MesaRenderer.cs         # RenderizaÃ§Ã£o ASCII da mesa

tests/
â””â”€â”€ TruCoNsole.Tests/           # Testes unitÃ¡rios (xUnit)
```

## ðŸ“„ LicenÃ§a

Este projeto estÃ¡ sob a licenÃ§a [MIT](LICENSE).

## ðŸ‘¤ Autor

**Daniel Hoffmann** â€” [@DanielHoffmannO](https://github.com/DanielHoffmannO)
