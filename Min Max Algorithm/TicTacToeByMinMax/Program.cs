using System;
using System.Threading;

namespace TicTacToeByMinMax
{
    class Program
    {
        class Move
        {
            public int row, col, val;
        }
        static char player = 'x', opponent = 'y';

        static bool isMovesLeft(char[,] board)
        {
            for (int row=0; row<3; row++)
            {
                for (int col=0; col<3; col++)
                {
                    if (board[row, col] == '_')
                        return true;
                }
            }
            return false;
        }

        static int evaluate(char[,] b)
        {
            for (int row = 0; row < 3; row++)
            {
                if (b[row, 0] == b[row, 1] && b[row, 1] == b[row, 2])
                {
                    if (b[row, 0] == player)
                        return 10;
                    else if (b[row, 0] == opponent)
                        return -10;
                }
            }

            for (int col = 0; col < 3; col++)
            {
                if (b[0, col] == b[1, col] && b[1, col] == b[2, col])
                {
                    if (b[0, col] == player)
                        return 10;
                    else if (b[0, col] == opponent)
                        return -10;
                }
            }

            if (b[0, 0] == b[1, 1] && b[1, 1] == b[2, 2])
            {
                if (b[0, 0] == player)
                    return +10;
                else if (b[0, 0] == opponent)
                    return -10;
            }

            if (b[0, 2] == b[1, 1] && b[1, 1] == b[2, 0])
            {
                if (b[0, 2] == player)
                    return +10;
                else if (b[0, 2] == opponent)
                    return -10;
            }

            return 0;
        }

        static int minimax(char[,] board, int depth, bool isMax)
        {
            int score = evaluate(board);
            if (score == 10)
                return score - depth;

            if (score == -10)
                return score + depth;

            if (!isMovesLeft(board))
                return 0;

            if (isMax)
            {
                int best = -1000;

                for (int row=0; row<3; row++)
                {
                    for (int col=0; col<3; col++)
                    {
                        if (board[row, col] == '_')
                        {
                            board[row, col] = player;
                            best = Math.Max(best, minimax(board, depth + 1, !isMax));
                            board[row, col] = '_';
                        }
                    }
                }
                return best;
            }

            else
            {
                int best = 1000;

                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (board[row, col] == '_')
                        {
                            board[row, col] = opponent;
                            best = Math.Min(best, minimax(board, depth + 1, !isMax));
                            board[row, col] = '_';
                        }
                    }
                }
                return best;
            }
        }

        static Move findBestMove(char[,] board)
        {
            Move bestMove = new Move();
            bestMove.val = -1000;
            bestMove.row = -1;
            bestMove.col = -1;

            for (int i=0; i<3; i++)
            {
                for (int j=0; j<3; j++)
                {
                    if (board[i,j] == '_')
                    {
                        board[i, j] = player;
                        int moveVal = minimax(board, 0, false);
                        board[i, j] = '_';

                        if (moveVal > bestMove.val)
                        {
                            bestMove.row = i;
                            bestMove.col = j;
                            bestMove.val = moveVal;
                        }
                    }
                }
            }

            Console.WriteLine($"The value of the best move is: {bestMove.val} ");
            return bestMove;
        }

        static void printBoard(char[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{board[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            char[,] board = {{ '_', '_', '_' },
                             { '_', '_', '_' },
                             { '_', '_', '_' }};

            int row, col;
            Move bestMove;
            Move opponentMove;

            printBoard(board);

            while (isMovesLeft(board))
            {
                row = Convert.ToInt32(Console.ReadLine()) - 1;
                col = Convert.ToInt32(Console.ReadLine()) - 1;
                board[row, col] = opponent;
                printBoard(board);

                if (!isMovesLeft(board))
                    break;
                
                Thread.Sleep(800);
                Console.WriteLine();
                bestMove = findBestMove(board);
                board[bestMove.row, bestMove.col] = player;
                printBoard(board);
                Thread.Sleep(800);

                if (bestMove.val == 10)
                    break;
            }
        }
    }
}
