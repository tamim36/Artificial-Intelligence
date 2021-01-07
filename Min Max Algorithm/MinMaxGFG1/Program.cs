using System;

namespace MinMaxGFG1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] scores = { 3, 5, 2, 9, 12, 5, 23, 23 };
            int n = scores.Length;
            int h = log2(n);
            var val = minimax(0, 0, true, scores, h);
            Console.WriteLine($"The h is {val}");
        }

        private static int log2(int n)
        {
            return (n == 1) ? 0 : 1 + log2(n/2);
        }

        private static int minimax(int depth, int nodeIndex, bool isMax, int []scores, int h)
        {
            if (depth == h)
                return scores[nodeIndex];

            if (isMax)
                return Math.Max(minimax(depth + 1, nodeIndex * 2, false, scores, h), minimax(depth + 1, nodeIndex * 2 + 1, false, scores, h));
            else
                return Math.Min(minimax(depth + 1, nodeIndex * 2, true, scores, h), minimax(depth + 1, nodeIndex * 2 + 1, true, scores, h));
        }
    }
}
