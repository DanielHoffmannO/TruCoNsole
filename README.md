# TruConsole - Jogo de Cartas no terminal em C#

Descrição do Projeto
O TruConsole é um jogo de cartas desenvolvido em C# que simula o famoso jogo de Truco. Ele inclui um sistema de tabuleiro, jogadores automatizados e interação com o usuário através da console. O projeto é uma implementação do jogo de Truco brasileiro, onde dois jogadores (usuário e computador) competem em partidas para ganhar pontos.

Índice
1. [Instalação](#instalação)
2. [Como Funciona](#como-funciona)
3. [Uso](#uso)
4. [Vídeo do Projeto Funcionando](#vídeo-do-projeto-funcionando)
5. [Créditos](#créditos)

## Instalação
Para executar o TruConsole, você precisará ter o seguinte configurado:

- Visual Studio ou qualquer outro ambiente de desenvolvimento C#.
- Clone este repositório em sua máquina local.
- Compile e execute o projeto.

## Como Funciona
O TruConsole segue as regras tradicionais do jogo de Truco brasileiro. [Regras](https://www.dicionariopopular.com/como-jogar-truco/).

### Estrutura do Projeto
O projeto é estruturado em classes, incluindo [Board](https://github.com/DanielHoffmannO/TruCoNsole/blob/main/src/core/TruCoNsole.Domain/Entity/Board.cs) (tabuleiro), [Player](https://github.com/DanielHoffmannO/TruCoNsole/blob/main/src/core/TruCoNsole.Domain/Entity/Player.cs) (jogador), e [Deck](https://github.com/DanielHoffmannO/TruCoNsole/blob/main/src/core/TruCoNsole.Domain/Entity/Deck.cs) (baralho). A lógica do jogo está contida principalmente na classe `Board`, onde as interações e decisões são gerenciadas.

### Lógica de Negócios
A lógica do jogo envolve a escolha de cartas, a decisão de "aceitar o truco" e o cálculo dos pontos com base nas regras do Truco. As interações entre o usuário e o computador são processadas através da console.

## Uso
Após a instalação, siga estas instruções para usar o TruConsole:

1. Execute o projeto no ambiente de desenvolvimento.
2. Siga as instruções exibidas na console para interagir com o jogo.
3. Jogue rodadas de Truco contra o computador, fazendo escolhas estratégicas.

### Exemplo de Uso:

- Escolha cartas para jogar durante sua vez.
- Aceite ou recuse desafios de truco.
- Ganhe rodadas para acumular pontos.

## Vídeo do Projeto Funcionando
https://github.com/DanielHoffmannO/TruCoNsole/assets/102805477/7d75f8c6-0cb1-4f35-9d8b-aec268480b2d

## Créditos
[Este projeto foi desenvolvido como um jogo de cartas interativo em C# e segue as regras tradicionais do Truco brasileiro.](https://www.youtube.com/watch?v=uo9stTDwAik&ab_channel=MayLeone)https://www.youtube.com/watch?v=uo9stTDwAik&ab_channel=MayLeone
