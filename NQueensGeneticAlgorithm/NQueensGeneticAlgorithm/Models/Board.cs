using System;

namespace NQueensGeneticAlgorithm.Models
{
    public class Board
    {
        public int CalculateCostBoard(int[,] board)
        {
            int costTotal = 0;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 1)
                    {
                        costTotal += SearchByQueensAttackingRow(board, i, j);
                        costTotal += SearchByQueensAttackingColumn(board, i, j);
                        costTotal += SearchByQueensAttackingDiagonal(board, i, j);
                        costTotal += SearchByQueensAttackingDiagonalReverse(board, i, j);
                    }
                }
            }

            // Uma rainha detecta a outra
            costTotal = costTotal / 2;

            return costTotal;
        }

        public int[,] GenerateNextBoard(int[,] board)
        {

            // Dados o estado atual do tabuleiro
            // Movimentar de forma aleatória as rainhas nas colunas, mantendo sempre as linhas
            for (int i = 0; i < board.GetLength(0); i++)
            {
                int colunaRainha = 0;
                for (int j = 0; j < board.GetLength(1); j++)
                {

                    if (board[i, j] == 1)
                    {
                        colunaRainha = j;
                    }

                }

                Random random = new Random();
                int novaColunaRainha = random.Next(board.GetLength(1));

                board[i, colunaRainha] = 0;
                board[i, novaColunaRainha] = 1;

            }

            return board;
        }

        private int SearchByQueensAttackingRow(int[,] board, int row, int column)
        {
            int countQueensAttacking = 0;

            for (int j = 0; j < board.GetLength(1); j++)
                if (board[row, j] == 1 && j != column)
                    countQueensAttacking++;

            return countQueensAttacking;
        }

        private int SearchByQueensAttackingColumn(int[,] board, int row, int column)
        {
            int countQueensAttacking = 0;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, column] == 1 && i != row)
                    countQueensAttacking++;
            }

            return countQueensAttacking;
        }

        private int SearchByQueensAttackingDiagonal(int[,] board, int row, int column)
        {
            int countQueensAttacking = 0;

            // Diagonal princial parte de cima
            for (int i = board.GetLength(0); i < board.GetLength(0); i--)
            {
                if (board[row - i, column - i] == 1 && i != row)
                    countQueensAttacking++;
            }

            // Diagonal princial parte de baixo
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[row + i, column + i] == 1 && i != row)
                    countQueensAttacking++;
            }

            return countQueensAttacking;
        }

        private int SearchByQueensAttackingDiagonalReverse(int[,] board, int row, int column)
        {
            int countQueensAttacking = 0;

            // Diagonal secundaria parte de cima
            for (int i = board.GetLength(0); i < board.GetLength(0); i--)
            {
                if (board[row - i, column + i] == 1 && i != row)
                    countQueensAttacking++;
            }

            // Diagonal secundaria parte de baixo
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[row + i, column - i] == 1 && i != row)
                    countQueensAttacking++;
            }

            return countQueensAttacking;
        }

        /// <summary>
        /// Verifica se é um posição valida
        /// </summary>
        /// <param name="maxColumn">Valor máximo permitido para a coluna</param>
        /// <param name="maxRow">Valor máximo permitido para a linha</param>
        /// <param name="column">valor da coluna a ser verificada</param>
        /// <param name="row">valor da linha a  ser verificada</param>
        /// <returns>true se for valida, false se for invalida a posição informada</returns>
        private bool PositionValid(int maxColumn, int maxRow, int column, int row)
        {
            bool columnValid = column >= 0 && column < maxColumn;
            bool rowValid = row >= 0 && row < maxRow;

            return columnValid && rowValid;
        }
    }
}
