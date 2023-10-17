# Processamento de Ofertas

Este é um programa em C# que processa uma lista de ofertas. Ele permite inserir, modificar e excluir ofertas, mantendo uma lista atualizada.

Ele foi feito como solução para o desafio Quero ser Intelitrader (https://github.com/intelitrader/quero-ser/tree/master)

## Como usar

1. Clone este repositório.
2. Abra o arquivo `Program.cs` em um editor de código.
3. Execute o programa.

## Entrada

A entrada para o programa é fornecida como uma string. Cada linha representa uma oferta e contém os seguintes campos:

- Posição: a posição da oferta na lista.
- Ação: a ação a ser realizada (0 para inserir, 1 para modificar, 2 para excluir).
- Valor: o valor da oferta.
- Quantidade: a quantidade da oferta.

Exemplo de entrada:<br >
12 <br >
1,0,15.4,50 <br >
2,0,15.5,50 <br >
2,2,0,0 <br >
2,0,15.4,10  <br >
3,0,15.9,30 <br >
3,1,0,20  <br >
4,0,16.50,200 <br >
5,0,17.00,100 <br >
5,0,16.59,20 <br >
6,2,0,0 <br >
1,2,0,0 <br >
2,1,15.6,0 <br >

## Saída

A saída do programa é uma lista atualizada de ofertas. Cada linha representa uma oferta e contém a posição, o valor e a quantidade da oferta.

Exemplo de saída:<br >
1,15.4,10 <br >
2,15.6,20 <br >
3,16.50,200 <br >
4,16.59,20\