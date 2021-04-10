using System;

namespace NQueensGeneticAlgorithm.Models
{
    public class Solver
    {
        /// <summary>
        /// Método para resolver o problema
        /// </summary>
        /// <param name="n">O tamanho do problema das n-queens</param>
        /// <param name="temperature">Temperatura inicial</param>
        /// <param name="coolingRate">Taxa de resfriamento</param>
        /// <returns></returns>
        public int[,] Solve(int n, double temperature, double coolingRate)
        {
            var boardUtils = new Board();

            int[,] bestBoard = GeneratePopulateBoard(n);

            bestBoard = new int[,]
            {
               { 0, 1, 0, 0, },
               { 1, 0, 0, 0, },
               { 1, 0, 0, 0, },
               { 0, 0, 1, 0, }
            };

            int[,] nextBoard;
            int bestProbability = boardUtils.CalculateCostBoard(bestBoard);

            for (; temperature > 0 && bestProbability != 0; temperature = temperature - coolingRate)
            {
                nextBoard = boardUtils.GenerateNextBoard((int[,])bestBoard.Clone());

                int costBest = boardUtils.CalculateCostBoard(bestBoard);
                int costNext = boardUtils.CalculateCostBoard(nextBoard);

                double delta = costBest - costNext;

                // Aptidão
                double fitness = Math.Exp(delta / temperature);

                var random = new Random();

                Console.WriteLine($"Custo do melhor: {costBest}, custo do próximo: {costNext}, custo do delta: {delta}, fitness: {fitness}, temperatura: {temperature}");

                // Se delta for maior que zero significa que o estado gerado é melhor que o atual
                if (delta > 0)
                {
                    bestBoard = nextBoard;
                    bestProbability = costNext;
                }
                else if (random.Next(1) <= fitness)
                {
                    bestBoard = nextBoard;
                    bestProbability = costNext;
                }
            }

            return bestBoard;
        }

        /// <summary>
        /// Cria uma matriz com cada rainha em uma linha e em colunas aleatórias
        /// </summary>
        /// <param name="n">Tamanho do tabuleiro a ser gerado e também o número de rainhas no tabuleiro a ser posicionada</param>
        /// <returns>Retorna a matriz com as rainhas preenchidas aleatóriamente uma em cada linha</returns>
        private int[,] GeneratePopulateBoard(int n)
        {
            var boardInitial = new int[n, n];

            // Run lines
            for (int i = 0; i < n; i++)
            {
                var rand = new Random();

                int columnRandom = rand.Next(n);

                // 1 equals queen in position
                boardInitial[i, columnRandom] = 1;
            }

            return boardInitial;
        }
    }
}
