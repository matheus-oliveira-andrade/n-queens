# N-Queens

Receber número de rainhas

Gerar o tabuleiro com o número de rainhas (posicionar cada rainha em uma linha do tabuleiro)

Calcular a temperatura inicial do estado gerado

Enquanto a temperatura for maior que a tolerância e o custo do estado atual for maior que zero
	** reduzir a temperatura

Gerar o próximo estado

Calcular o custo do próximo estado
	O próximo estado será gerado com base no fato de que cada rainha está em uma linha diferente da outra, sendo necessário apenas gerar aleatóriamente um valor para a coluna e movendo apenas as rainhas no tabuleiro no eixo Y e nunca no eixo X, pois  dentre todas as soluções finais possíveis nenhuma tem uma solução em que exista mais de uma rainha na mesma linha, devido ao fato de uma rainha poder se mover em todos os quadrados na mesma linha

realizar o calculo do delta 
	Custo do estado atual - custo do próximo estado 

realizar o calculo da probabilidade 
	expoente de o valor de delta divido pela temperatura 

Gerar um valor aleatório

Se o valor gerado aleatoriamente for menor que a probabilidade do estado atual então
o estado atual deve ser o próximo estado gerado

ou então se o valor gerado aleatóriamente for menor ou igual a probabilidade então o estado atual deve ser o próximo estado gerado


LÓGICA MOVIMENTOS PARA VALIDAÇÃO RAINHA EM POSIÇÃO DE ATAQUE
--------------------------------------------------------------------

- Para andar na diagonal principal para cima 
	- -1 na linha e na coluna
- Para andar na diagonal princial para baixo 
	- +1 na linha e na coluna

- Para andar na diagonal secundaria para cima
	- +1 na coluna e -1 na linha
- Para andar na diagonal secundaria para baixo
	- -1 na coluna e +1 na linha

- Andar para os lados 
	 - para cima | Linha - 1, Coluna
	 - para direita | Linha, Coluna + 1
	 - para baixo | Linha + 1, Coluna
	 - para esquerda | Linha, Coluna - 1


# Referências

https://en.wikipedia.org/wiki/Eight_queens_puzzle

https://en.wikipedia.org/wiki/Simulated_annealing#Pseudocode

https://towardsdatascience.com/simulated-annealing-and-the-eight-queen-problem-10f737edbb7e

http://modelai.gettysburg.edu/2016/pyconsole/ex3/index.html#:~:text=The%20N%2Dqueens%20problem%20is,queens%20problem%20using%20simulated%20annealing

https://sites.google.com/site/tecprojalgoritmos/problemas/Problema-das-oito-rainhas

https://www.datagenetics.com/blog/august42012/

https://github.com/nb256/8queens_simulated_annealing/blob/master/8queens_simulated/Program.cs

https://github.com/selimfirat/ai-n-queens/blob/cf7ab4bd8bd01d2c95046b6d430f1f1191f8b571/src/SolverUtils.java#L35
