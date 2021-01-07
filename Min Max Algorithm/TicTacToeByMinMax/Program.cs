using System;

namespace TicTacToeByMinMax
{
    class Program
    {
        class Move
        {
            public int row, col;
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
            if (score == 10 || score == -10)
                return score;

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
                            board[row, col] = player;
                            best = Math.Min(best, minimax(board, depth + 1, !isMax));
                            board[row, col] = '_';
                        }
                    }
                }
                return best;
            }
        }

        static int findBestMove(char[,] board)
        {
            return 2;
        }

        static void Main(string[] args)
        {
            char[,] board = {{ 'x', 'o', 'x' },
                     { 'o', 'o', 'x' },
                     { '_', '_', '_' }};


        }
    }
}
